using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.ComponentModel;
using System.IO.Compression;

namespace GAsplund_s_WynnPack_Manager
{
    class FileManagement
    {
        public static string CreateMd5ForFolder(string path) // TOTALLY NOT COPIED FROM STACKOVERFLOW
        {
            // assuming you want to include nested folders
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)
                                 .OrderBy(p => p).ToList();

            MD5 md5 = MD5.Create();

            for (int i = 0; i < files.Count; i++)
            {
                string file = files[i];

                // hash path
                string relativePath = file.Substring(path.Length + 1);
                byte[] pathBytes = Encoding.UTF8.GetBytes(relativePath.ToLower());
                md5.TransformBlock(pathBytes, 0, pathBytes.Length, pathBytes, 0);

                // hash contents
                byte[] contentBytes = File.ReadAllBytes(file);
                if (i == files.Count - 1)
                    md5.TransformFinalBlock(contentBytes, 0, contentBytes.Length);
                else
                    md5.TransformBlock(contentBytes, 0, contentBytes.Length, contentBytes, 0);
            }

            return BitConverter.ToString(md5.Hash).Replace("-", "").ToLower();
        }

        public static bool CurrentPackIsInstalled(int packID, string packFileName)
        {
            string appDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string packFileSelection = appDataLocation + "\\.minecraft\\resourcepacks\\" + packFileName;
            string packFileSelection2 = appDataLocation + "\\.minecraft\\resourcepack_manager\\localcache\\" + packFileName + ".zip";
            if (Directory.Exists(packFileSelection) && File.Exists(packFileSelection2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CurrentPackIsOutdated(int packID, string packFileName, string packMD5)
        {
            string appDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string packFileSelection = appDataLocation + "\\.minecraft\\resourcepack_manager\\localcache\\" + packFileName + ".zip";
            if (File.Exists(packFileSelection))
            {
                        if (packMD5.ToUpper() == checkMD5(packFileSelection).ToUpper())
                        {
                            Console.WriteLine("Comparing " + packMD5.ToUpper() + " vs " + checkMD5(packFileSelection).ToString().ToUpper());
                            return false;
                        }
                        else
                        {
                            Console.WriteLine("Comparing " + packMD5 + " vs " + checkMD5(packFileSelection).ToString().ToUpper());
                            return true;
                        }

                    
                
            }
            else
            {
                return true;
            }
        }

        static string checkMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
                //return "hi";
            }
        }
        public static async Task downloadPack(string downloadlink, string packFileName)
        {
            string appDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    Uri uri = new Uri(downloadlink);
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    await webClient.DownloadFileTaskAsync(uri, appDataLocation + "\\.minecraft\\resourcepack_manager\\localcache\\" + packFileName + ".zip");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Directory.Exists(appDataLocation + "\\.minecraft\\resourcepacks\\" + packFileName)) { Directory.Delete(appDataLocation + "\\.minecraft\\resourcepacks\\" + packFileName, true); }
                ZipFile.ExtractToDirectory(appDataLocation + "\\.minecraft\\resourcepack_manager\\localcache\\" + packFileName + ".zip", appDataLocation + "\\.minecraft\\resourcepacks\\" + packFileName);
            }
        }

        private static void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var main = Application.OpenForms.OfType<ManagerForm>().First();
            main.statusProgressBar.Value = e.ProgressPercentage;
            if (e.ProgressPercentage > 0) { main.statusProgressBar.Value = e.ProgressPercentage - 1; }
        }

        private static void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var main = Application.OpenForms.OfType<ManagerForm>().First();
            main.statusProgressBar.Value = 0;
        }
        public static void removePack(string packFileName)
        {
            string appDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Directory.Delete(appDataLocation + "\\.minecraft\\resourcepacks\\" + packFileName, true);
        }

        public static void CheckForProgramData()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\resourcepack_manager\\localcache"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\resourcepack_manager\\localcache");
            }

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\resourcepack_manager\\localsettings"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\resourcepack_manager\\localsettings");
            }
        }

    }
}
