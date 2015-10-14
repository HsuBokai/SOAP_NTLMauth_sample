namespace digiEAR_API_SOAP_sample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.media_path = new System.Windows.Forms.TextBox();
            this.import_medias = new System.Windows.Forms.Button();
            this.term_file = new System.Windows.Forms.TextBox();
            this.select_term_file = new System.Windows.Forms.Button();
            this.search_btn = new System.Windows.Forms.Button();
            this.select_output_path = new System.Windows.Forms.Button();
            this.output_path = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.clear_list_box = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.Password_tb = new System.Windows.Forms.TextBox();
            this.userName_tb = new System.Windows.Forms.TextBox();
            this.serverSite_tb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.result_grid_view = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.result_grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(582, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // media_path
            // 
            this.media_path.Location = new System.Drawing.Point(125, 21);
            this.media_path.Name = "media_path";
            this.media_path.Size = new System.Drawing.Size(451, 27);
            this.media_path.TabIndex = 1;
            this.media_path.Text = "C:\\DigiEarData\\Media\\2011CNN";
            // 
            // import_medias
            // 
            this.import_medias.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.import_medias.Location = new System.Drawing.Point(620, 22);
            this.import_medias.Name = "import_medias";
            this.import_medias.Size = new System.Drawing.Size(98, 23);
            this.import_medias.TabIndex = 2;
            this.import_medias.Text = "Index";
            this.import_medias.UseVisualStyleBackColor = true;
            this.import_medias.Click += new System.EventHandler(this.import_medias_Click);
            // 
            // term_file
            // 
            this.term_file.Location = new System.Drawing.Point(125, 21);
            this.term_file.Name = "term_file";
            this.term_file.Size = new System.Drawing.Size(451, 27);
            this.term_file.TabIndex = 3;
            this.term_file.Text = "C:\\Users\\cal\\Desktop\\bokai\\terms\\term_1.txt";
            // 
            // select_term_file
            // 
            this.select_term_file.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.select_term_file.Location = new System.Drawing.Point(582, 19);
            this.select_term_file.Name = "select_term_file";
            this.select_term_file.Size = new System.Drawing.Size(32, 23);
            this.select_term_file.TabIndex = 4;
            this.select_term_file.Text = "...";
            this.select_term_file.UseVisualStyleBackColor = true;
            this.select_term_file.Click += new System.EventHandler(this.select_term_file_Click);
            // 
            // search_btn
            // 
            this.search_btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.search_btn.Location = new System.Drawing.Point(620, 61);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(98, 23);
            this.search_btn.TabIndex = 5;
            this.search_btn.Text = "Search";
            this.search_btn.UseVisualStyleBackColor = true;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // select_output_path
            // 
            this.select_output_path.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.select_output_path.Location = new System.Drawing.Point(582, 61);
            this.select_output_path.Name = "select_output_path";
            this.select_output_path.Size = new System.Drawing.Size(32, 23);
            this.select_output_path.TabIndex = 6;
            this.select_output_path.Text = "...";
            this.select_output_path.UseVisualStyleBackColor = true;
            this.select_output_path.Click += new System.EventHandler(this.select_output_path_Click);
            // 
            // output_path
            // 
            this.output_path.Location = new System.Drawing.Point(125, 58);
            this.output_path.Name = "output_path";
            this.output_path.Size = new System.Drawing.Size(451, 27);
            this.output_path.TabIndex = 7;
            this.output_path.Text = "C:\\Users\\cal\\Desktop\\bokai\\output";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.media_path);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.import_medias);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(21, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 63);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Index";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Media Folder :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.term_file);
            this.groupBox2.Controls.Add(this.select_term_file);
            this.groupBox2.Controls.Add(this.output_path);
            this.groupBox2.Controls.Add(this.search_btn);
            this.groupBox2.Controls.Add(this.select_output_path);
            this.groupBox2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(21, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(739, 95);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Output Folder :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Term Set File :";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(21, 319);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(614, 112);
            this.listBox1.TabIndex = 13;
            // 
            // clear_list_box
            // 
            this.clear_list_box.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.clear_list_box.Location = new System.Drawing.Point(641, 319);
            this.clear_list_box.Name = "clear_list_box";
            this.clear_list_box.Size = new System.Drawing.Size(98, 23);
            this.clear_list_box.TabIndex = 13;
            this.clear_list_box.Text = "Clear";
            this.clear_list_box.UseVisualStyleBackColor = true;
            this.clear_list_box.Click += new System.EventHandler(this.clear_list_box_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.login_btn);
            this.groupBox3.Controls.Add(this.Password_tb);
            this.groupBox3.Controls.Add(this.userName_tb);
            this.groupBox3.Controls.Add(this.serverSite_tb);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(21, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(739, 126);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Login";
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(620, 86);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(98, 26);
            this.login_btn.TabIndex = 2;
            this.login_btn.Text = "Login";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // Password_tb
            // 
            this.Password_tb.Location = new System.Drawing.Point(125, 86);
            this.Password_tb.Name = "Password_tb";
            this.Password_tb.PasswordChar = '*';
            this.Password_tb.Size = new System.Drawing.Size(451, 27);
            this.Password_tb.TabIndex = 1;
            this.Password_tb.Text = "1234";
            // 
            // userName_tb
            // 
            this.userName_tb.Location = new System.Drawing.Point(125, 54);
            this.userName_tb.Name = "userName_tb";
            this.userName_tb.Size = new System.Drawing.Size(451, 27);
            this.userName_tb.TabIndex = 1;
            this.userName_tb.Text = "digiEARuser";
            // 
            // serverSite_tb
            // 
            this.serverSite_tb.Location = new System.Drawing.Point(125, 21);
            this.serverSite_tb.Name = "serverSite_tb";
            this.serverSite_tb.Size = new System.Drawing.Size(451, 27);
            this.serverSite_tb.TabIndex = 1;
            this.serverSite_tb.Text = "localhost";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Password      :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "User Name    :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Server Site    :";
            // 
            // result_grid_view
            // 
            this.result_grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.result_grid_view.Location = new System.Drawing.Point(21, 447);
            this.result_grid_view.Name = "result_grid_view";
            this.result_grid_view.RowTemplate.Height = 24;
            this.result_grid_view.Size = new System.Drawing.Size(614, 264);
            this.result_grid_view.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 732);
            this.Controls.Add(this.result_grid_view);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.clear_list_box);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "DigiEAR Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.result_grid_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox media_path;
        private System.Windows.Forms.Button import_medias;
        private System.Windows.Forms.TextBox term_file;
        private System.Windows.Forms.Button select_term_file;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Button select_output_path;
        private System.Windows.Forms.TextBox output_path;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button clear_list_box;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Password_tb;
        private System.Windows.Forms.TextBox userName_tb;
        private System.Windows.Forms.TextBox serverSite_tb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.DataGridView result_grid_view;
    }
}

