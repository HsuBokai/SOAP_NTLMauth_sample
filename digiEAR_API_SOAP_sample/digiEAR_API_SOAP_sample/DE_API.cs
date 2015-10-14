using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace digiEAR_API_SOAP_sample
{
    class DE_API
    {
        string site;
        string userName;
        string password;

        public DE_API(string s = "localhost", string u = "digiEARuser", string p = "1234")
        {
            site = s;
            userName = u;
            password = p;
        }

        public int digiEAR_indexAllowed()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string ret_str = CallWebService("http://" + site + "/digiEARservices/DEindex.asmx", "digiEAR_indexAllowed", parameters, new NetworkCredential(userName, password, site));
            if (ret_str == "")
            {
                return -1;
            }
            else
            {
                XmlDocument res_doc = new XmlDocument();
                res_doc.LoadXml(ret_str);
                return Convert.ToInt32(res_doc.DocumentElement.GetElementsByTagName("digiEAR_indexAllowedResult").Item(0).InnerText);
            }
        }

        public string digiEAR_indexOpenHandle(string acoName, out int hIndex)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("acoName", acoName);
            string ret_str = CallWebService("http://" + site + "/digiEARservices/DEindex.asmx", "digiEAR_indexOpenHandle", parameters, new NetworkCredential(userName, password, site));
            if (ret_str == "")
            {
                hIndex = 0;
                return "web_services_error";
            }
            else
            {
                XmlDocument res_doc = new XmlDocument();
                res_doc.LoadXml(ret_str);
                hIndex = System.Int32.Parse(res_doc.DocumentElement.GetElementsByTagName("ihIndex").Item(0).InnerText);
                return res_doc.DocumentElement.GetElementsByTagName("digiEAR_indexOpenHandleResult").Item(0).InnerText;
            }
        }

        public string digiEAR_index(string medFile, string acoName, string patDir, int hIndex)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("freshFile", medFile);
            parameters.Add("acoName", acoName);
            parameters.Add("targetDir", patDir);
            parameters.Add("ihStream", hIndex.ToString());
            string ret_str = CallWebService("http://" + site + "/digiEARservices/DEindex.asmx", "digiEAR_index", parameters, new NetworkCredential(userName, password, site));
            if (ret_str == "")
            {
                return "web_services_error";
            }
            else
            {
                XmlDocument res_doc = new XmlDocument();
                res_doc.LoadXml(ret_str);
                return res_doc.DocumentElement.GetElementsByTagName("digiEAR_indexResult").Item(0).InnerText;
            }
        }

        public string digiEAR_indexCloseHandle(int hIndex)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ihIndex", hIndex.ToString());
            string ret_str = CallWebService("http://" + site + "/digiEARservices/DEindex.asmx", "digiEAR_indexCloseHandle", parameters, new NetworkCredential(userName, password, site));
            if (ret_str == "")
            {
                return "web_services_error";
            }
            else
            {
                XmlDocument res_doc = new XmlDocument();
                res_doc.LoadXml(ret_str);
                return res_doc.DocumentElement.GetElementsByTagName("digiEAR_indexCloseHandleResult").Item(0).InnerText;
            }
        }


        public string digiEAR_searchOpenHandle(out int ihSearch)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string ret_str = CallWebService("http://" + site + "/digiEARservices/DEsearch.asmx", "digiEAR_searchOpenHandle", parameters, new NetworkCredential(userName, password, site));
            if (ret_str == "")
            {
                ihSearch = 0;
                return "web_services_error";
            }
            else
            {
                XmlDocument res_doc = new XmlDocument();
                res_doc.LoadXml(ret_str);
                ihSearch = System.Int32.Parse(res_doc.DocumentElement.GetElementsByTagName("ihSearch").Item(0).InnerText);
                return res_doc.DocumentElement.GetElementsByTagName("digiEAR_searchOpenHandleResult").Item(0).InnerText;
            }
        }


        public DataSet digiEAR_search(int maxResults, DataSet searchDS, int hSearch)
        {
            string xsd = "";
            using (StringWriter sw = new StringWriter())
            {
                searchDS.WriteXml(sw, XmlWriteMode.WriteSchema);
                xsd = sw.ToString();
            }
            XmlDocument xsd_doc = new XmlDocument();
            xsd_doc.LoadXml(xsd);
            string schema = xsd_doc.GetElementsByTagName("xs:schema").Item(0).OuterXml;
            string diffgram = "";
            using (StringWriter sw = new StringWriter())
            {
                searchDS.WriteXml(sw, XmlWriteMode.DiffGram);
                diffgram = sw.ToString();
            }
            string final = "<searchDS>" + schema + "\n" + diffgram.Insert(139, " xmlns=\"\"") + "</searchDS>";
            //MessageBox.Show(final);
            
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("imaxResults", maxResults.ToString());
            parameters.Add("", final);
            parameters.Add("ihSearch", hSearch.ToString());
            string ret_str = CallWebService("http://" + site + "/digiEARservices/DEsearch.asmx", "digiEAR_search2", parameters, new NetworkCredential(userName, password, site));
            //string ret_str = "";
            DataSet hitDS = new DataSet();
            if (ret_str == "")
            {
                return hitDS;
            }
            else
            {
                XmlDocument res_doc = new XmlDocument();
                res_doc.LoadXml(ret_str);
                string ret_xsd = res_doc.DocumentElement.GetElementsByTagName("digiEAR_search2Result").Item(0).OuterXml;
                using (StringReader SR = new StringReader(ret_xsd))
                {
                    hitDS.ReadXml(SR);
                }
                return hitDS;
            }
        }

        public string digiEAR_searchCloseHandle(int hSearch)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ihSearch", hSearch.ToString());
            string ret_str = CallWebService("http://" + site + "/digiEARservices/DEsearch.asmx", "digiEAR_searchCloseHandle", parameters, new NetworkCredential(userName, password, site));
            if (ret_str == "")
            {
                return "web_services_error";
            }
            else
            {
                XmlDocument res_doc = new XmlDocument();
                res_doc.LoadXml(ret_str);
                return res_doc.DocumentElement.GetElementsByTagName("digiEAR_searchCloseHandleResult").Item(0).InnerText;
            }
        }

        private static string CallWebService(string url, string action, Dictionary<string, string> parameters, NetworkCredential nc)
        {
            string xmlns = "http://cyberasiatech.com/digiEAR/XmlWebServices/";
            string Out = String.Empty;
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Headers.Add("SOAPAction", xmlns + action);
                webRequest.ContentType = "text/xml;charset=\"utf-8\"";
                webRequest.Accept = "text/xml";
                webRequest.Method = "POST";

                CredentialCache myCredCache = new CredentialCache();
                //myCredCache.Add(new Uri(Url), "Negotiate", (NetworkCredential)CredentialCache.DefaultCredentials);
                myCredCache.Add(new Uri(url), "Negotiate", nc);

                // Set the username and the password.
                webRequest.Credentials = myCredCache;
                // This property must be set to true for Kerberos authentication.
                webRequest.PreAuthenticate = true;
                // Keep the connection alive.
                webRequest.KeepAlive = true;
                webRequest.UnsafeAuthenticatedConnectionSharing = true;
                webRequest.UserAgent = "Upload Test";
                webRequest.AllowWriteStreamBuffering = false;
                webRequest.Timeout = 10000;

                webRequest.AllowWriteStreamBuffering = true;

                XmlDocument soapEnvelopeXml = CreateSoapEnvelope(xmlns, action, parameters);
                InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

                
                HttpWebResponse WResponse = (HttpWebResponse)webRequest.GetResponse();
                // Read your response data here.
                System.IO.Stream ReceiveStream = WResponse.GetResponseStream();
                using (System.IO.StreamReader sr = new System.IO.StreamReader(ReceiveStream, Encoding.UTF8))
                {
                    Out = sr.ReadToEnd();
                }
                // Close all streams.
                WResponse.Close();
                
                /*
                // begin async call to web request.
                IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

                // suspend this thread until call is complete. You might want to
                // do something usefull here like update your UI.
                asyncResult.AsyncWaitHandle.WaitOne();

                // get the response from the completed web request.
                using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
                {
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        Out = rd.ReadToEnd();
                    }
                }
                 * */
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(string.Format("HTTP_ERROR :: The second HttpWebRequest object has raised an Argument Exception as 'Connection' Property is set to 'Close' :: {0}", ex.Message));
            }
            catch (WebException ex)
            {
                MessageBox.Show(string.Format("HTTP_ERROR :: WebException raised! :: {0}", ex.Message));
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("HTTP_ERROR :: Exception raised! :: {0}", ex.Message));
            }
            return Out;
        }

        private static XmlDocument CreateSoapEnvelope(string xmlns, string action, Dictionary<string, string> parameters)
        {
            XmlDocument soapEnvelop = new XmlDocument();

            string namespaces = "http://schemas.xmlsoap.org/soap/envelope/";
            XmlElement env = soapEnvelop.CreateElement("soap", "Envelope", namespaces);
            env.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            env.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            env.SetAttribute("xmlns:soap", namespaces);

            //XmlNodeList body = soapEnvelop.GetElementsByTagName("soap:Body");
            XmlElement body = soapEnvelop.CreateElement("soap", "Body", namespaces);
            XmlElement aa = soapEnvelop.CreateElement(action);
            aa.SetAttribute("xmlns", xmlns);
            foreach (KeyValuePair<string, string> entry in parameters)
            {
                if (entry.Key != "")
                {
                    XmlElement pp = soapEnvelop.CreateElement(entry.Key);
                    pp.InnerText = entry.Value;
                    aa.AppendChild(pp);
                }
                else
                {
                    XmlDocumentFragment fragment = soapEnvelop.CreateDocumentFragment();
                    fragment.InnerXml = entry.Value;
                    aa.AppendChild(fragment);
                }
            }
            body.AppendChild(aa);
            env.AppendChild(body);
            soapEnvelop.AppendChild(env);

            return soapEnvelop;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        private static string xmlDocument_to_string(XmlDocument xmlDoc)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (XmlTextWriter tx = new XmlTextWriter(sw))
                {
                    xmlDoc.WriteTo(tx);
                    return sw.ToString();
                }
            }
        }

    }
}
