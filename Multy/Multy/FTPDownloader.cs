using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Multy
{
    /// <summary>
    /// Class for downloadinag files from ftp hosts.
    /// </summary>
    class FTPDownloader
    {
        private string Request { get; set; }

        /// <summary>
        /// Constructor initializes fields.
        /// </summary>
        /// <param name="request">Request</param>
        public FTPDownloader(string request)
        {
            this.Request = request;
        }

        /// <summary>
        /// Downloads all files from directory.
        /// </summary>
        public void DownloadAllFiles()
        {
            string[] files = GetFileList();

            foreach (string file in files)
            {
                Thread myThread = new Thread(new ParameterizedThreadStart(Download));
                myThread.Start(file);
            }
        }

        /// <summary>
        /// Returns list of file names in directory.
        /// </summary>
        /// <returns></returns>
        public string[] GetFileList()
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            WebResponse response = null;
            StreamReader reader = null;
            try
            {
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + Request + "/"));
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                response = reqFTP.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();

                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }

                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                return result.ToString().Split('\n');
            }

            catch (Exception ex)
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (response != null)
                {
                    response.Close();
                }

                downloadFiles = null;
                return downloadFiles;
            }
        }

        /// <summary>
        /// Downloads file with required name.
        /// </summary>
        /// <param name="fileName"></param>
        private void Download(object fileName)
        {
            var file = (string)fileName;
            try
            {
                string uri = "ftp://" + Request + "/" + file;
                Uri serverUri = new Uri(uri);
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + Request + "/" + file));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                using (FileStream writeStream = new FileStream(file, FileMode.Create))
                {
                    int Length = 2048;
                    Byte[] buffer = new Byte[Length];
                    int bytesRead = responseStream.Read(buffer, 0, Length);

                    while (bytesRead > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                        bytesRead = responseStream.Read(buffer, 0, Length);
                    }
                }

                reader.Close();
                response.Close();
            }

            catch (WebException wEx)
            {
                Console.WriteLine(wEx.Message, "Download Error");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Download Error");
            }
        }
    }
}
