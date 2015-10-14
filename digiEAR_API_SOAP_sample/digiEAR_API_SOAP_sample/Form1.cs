using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace digiEAR_API_SOAP_sample
{
    public partial class Form1 : Form
    {
        DE_API de_api = new DE_API();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.media_path.Text = this.folderBrowserDialog1.SelectedPath;
            }   
        }

        private void import_medias_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.media_path.Text)) return;

            if (de_api.digiEAR_indexAllowed() < 0) return;
            this.listBox1.Items.Add("index_allow_ok");

            DirectoryInfo di = new DirectoryInfo(this.media_path.Text);
            try
            {
                foreach (var fi in di.EnumerateFiles())
                {
                    if (fi.Extension == ".wmv" || fi.Extension == ".wav" || fi.Extension == ".mp3" || fi.Extension == ".wma")
                    {
                        index(fi.DirectoryName, fi.Name);
                    }
                }
            }
            catch (DirectoryNotFoundException DirNotFound) {
                this.listBox1.Items.Add(DirNotFound.Message);
            }
            catch (UnauthorizedAccessException UnAuthDir) {
                this.listBox1.Items.Add(UnAuthDir.Message);
            }
            catch (PathTooLongException LongPath) {
                this.listBox1.Items.Add(LongPath.Message);
            }
        }


        private void index(string dir_path, string file_name)
        {
            int hIndex = 0;
            try
            {
                //
                // get a “indexing handle”(hIndex) for given acoustic model
                // from server for "indexing"
                //
                string acoName = "Aco_Tele_NAEnglish";
                string iError = de_api.digiEAR_indexOpenHandle(acoName, out hIndex);
                if (iError != "DE_SUCCESS") throw (new ApplicationException("digiEAR_indexOpenHandle" + iError.ToString()));
                if (hIndex == 0) throw (new ApplicationException("Unable to get handle: " + iError));
                this.listBox1.Items.Add("hIndex = " + hIndex.ToString());

                //
                // Start indexing for the given media file, acoustic model
                // the .pat file and media file will be moved to patDir after
                // indexing
                //
                string medFile = dir_path + "\\" + file_name;
                string patDir = dir_path;
                this.listBox1.Items.Add("medFile = " + medFile);
                this.listBox1.Items.Add("patDir = " + patDir);

                iError = de_api.digiEAR_index(medFile, acoName, patDir, hIndex);
                if (iError != "DE_SUCCESS") throw (new ApplicationException("digiEAR_index" + iError.ToString()));

                Thread.Sleep(3000);

                // close the handle
                //
                iError = de_api.digiEAR_indexCloseHandle(hIndex);
                this.listBox1.Items.Add(iError.ToString());

                this.listBox1.Items.Add("index end !!");

            }
            catch (Exception e1)
            {
                this.listBox1.Items.Add(e1.Message);
                if (0 < hIndex) de_api.digiEAR_indexCloseHandle(hIndex);
            }
        }

        private void add_pat_file(DataTable patDT, string patFilePath)
        {
            DataRow workRow = patDT.NewRow();
            workRow["Pat"] = patFilePath;
            patDT.Rows.Add(workRow);
        }

        private void add_term(DataTable queryDT, int minScore, string term)
        {
            DataRow workRow = queryDT.NewRow();
            workRow["MinScore"] = minScore;
            workRow["QueryTerm"] = term;
            queryDT.Rows.Add(workRow);
        }

        private void select_term_file_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.term_file.Text = this.openFileDialog1.FileName;
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.media_path.Text)) return;
            if (!File.Exists(this.term_file.Text)) return;
            if (!Directory.Exists(this.output_path.Text)) return;

            if (de_api.digiEAR_indexAllowed() < 0) return;
            
            //
            // searchDS is part of input
            // hitDS is the result of "search"
            //
            DataSet searchDS = new DataSet("SearchDS");
            DataSet hitDS = new DataSet("HitDS");
            int hSearch = 0;

            try
            {
                //
                // prepare DataTable patDT
                //
                DataTable patDT = searchDS.Tables.Add("PatDT");
                patDT.Columns.Add("Pat", typeof(string));
                DirectoryInfo di = new DirectoryInfo(this.media_path.Text);
                try
                {
                    foreach (var fi in di.EnumerateFiles())
                    {
                        if (fi.Extension == ".wmv" || fi.Extension == ".wav" || fi.Extension == ".mp3" || fi.Extension == ".wma")
                        {
                            string patFilePath = fi.FullName + ".pat";
                            if (!File.Exists(patFilePath)) 
                            {
                                index(fi.DirectoryName, fi.Name);
                            }
                            add_pat_file(patDT, patFilePath);
                        }
                    }
                }
                catch (DirectoryNotFoundException DirNotFound)
                {
                    Console.WriteLine("(0)", DirNotFound.Message);
                }
                catch (UnauthorizedAccessException UnAuthDir)
                {
                    Console.WriteLine("(0)", UnAuthDir.Message);
                }
                catch (PathTooLongException LongPath)
                {
                    Console.WriteLine("(0)", LongPath.Message);
                }

                //
                // prepare DataTable queryDT
                //
                DataTable queryDT = searchDS.Tables.Add("QueryDT");
                queryDT.Columns.Add("MinScore", typeof(int));
                queryDT.Columns.Add("QueryTerm", typeof(string));
                String[] terms = File.ReadAllText(this.term_file.Text).Split('\n');
                foreach (var term in terms)
                {
                    //Console.WriteLine("{0}", term);
                    char[] separators = { ',', '"' };
                    String[] components = term.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    if (components.Length >= 2)
                    {
                        add_term(queryDT, Convert.ToInt32(components[1]), components[0]);
                    }
                }

                //
                // max. # of hits to be returned from server: maxResults
                //
                int maxResults = 100;
                string deError = "DE_SUCCESS";
                //
                // get a "handle" (hSearch) from server for "search"
                //
                deError = de_api.digiEAR_searchOpenHandle(out hSearch);
                if (deError != "DE_SUCCESS") throw (new ApplicationException("digiEAR_searchOpenHandle :" + deError.ToString()));
                if (hSearch == 0) throw (new ApplicationException("Unable to get handle: " + deError));
                this.listBox1.Items.Add("hSearch = " + hSearch.ToString());
                //
                // request Web Service
                //
                hitDS = de_api.digiEAR_search(maxResults, searchDS, hSearch);
                //
                // close the handle
                //
                deError = de_api.digiEAR_searchCloseHandle(hSearch);
                if (deError != "DE_SUCCESS") throw (new ApplicationException("digiEAR_searchCloseHandle :" + deError.ToString()));
                this.listBox1.Items.Add("Status: " + deError.ToString());


                result_grid_view.DataSource = hitDS.Tables["HitDT"];

                string output = string.Empty;
                output += "key word, media file name, starting time, ending time, score \n";
                if (0 < hitDS.Tables.Count)
                {
                    for (int i = 0; i < hitDS.Tables["HitDT"].Rows.Count; ++i)
                    {
                        
                        output += hitDS.Tables["HitDT"].Rows[i][4].ToString() + ", ";
                        string pat_name = hitDS.Tables["HitDT"].Rows[i][1].ToString();
                        output += pat_name.Substring(0, pat_name.Length - 4) + ", ";
                        output += hitDS.Tables["HitDT"].Rows[i][2].ToString() + ", ";
                        output += hitDS.Tables["HitDT"].Rows[i][3].ToString() + ", ";
                        output += hitDS.Tables["HitDT"].Rows[i][0].ToString() + "\n";
                        
                        /*
                        for (int j = 0; j < hitDS.Tables["HitDT"].Columns.Count; ++j)
                        {
                            output += hitDS.Tables["HitDT"].Rows[i][j].ToString();
                            output += ",";
                        }
                        output += "\n";                        
                         * */
                        
                    }
                }
                else
                {
                    this.listBox1.Items.Add("No Search Results");
                }
                this.listBox1.Items.Add(output);
                File.WriteAllText(this.output_path.Text + "/result.csv", output);
                
                this.listBox1.Items.Add("search end !!");

            }
            catch (Exception e1)
            {
                //txbxMessage.Text = e1.Message;
                this.listBox1.Items.Add(e1.Message);
                //if (0 < hSearch) ws.digiEAR_searchCloseHandle(hSearch);
            }

            //
            // dispose DataSet's
            //
            searchDS.Dispose();
            hitDS.Dispose();
            //ws.Dispose();
        }

        private void select_output_path_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                this.output_path.Text = this.folderBrowserDialog2.SelectedPath;
            }
        }

        private void clear_list_box_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            de_api = new DE_API(this.serverSite_tb.Text, this.userName_tb.Text, this.Password_tb.Text);
        }
    }
}
