namespace Multy
{
    /// <summary>
    /// Main class of the project.
    /// </summary>
    class EntryPoint
    {
        public static object MessageBox { get; private set; }

        /// <summary>
        /// Main method downloads all exe files from "ftp.vet.bg.ac.rs/pub/internet/Acrobat_reader".
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var a = new FTPDownloader("ftp.vet.bg.ac.rs/pub/internet/Acrobat_reader");
            a.DownloadAllFiles();
        }            
    }
}