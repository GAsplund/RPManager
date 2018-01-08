using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Threading;

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
            string packFileSelection = @"%APPDATA%\.minecraft\resourcepacks\FaIaLaEaNaAaMaE.zip".Replace("FaIaLaEaNaAaMaE", packFileName).Replace("%APPDATA%", appDataLocation);
            if (File.Exists(packFileSelection))
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
            string packFileSelection = @"%APPDATA%\.minecraft\resourcepacks\FaIaLaEaNaAaMaE.zip".Replace("FaIaLaEaNaAaMaE", packFileName).Replace("%APPDATA%", appDataLocation);
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
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
                //return "hi";
            }
        }

        public static void downloadPack(string downloadlink, string packFileName)
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    Uri uri = new Uri(downloadlink);
                    string appDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ManagerForm.DownloadProgressCallback);
                    webClient.DownloadFile(uri, @"%APPDATA%\.minecraft\resourcepacks\FaIaLaEaNaAaMaE.zip".Replace("FaIaLaEaNaAaMaE", packFileName).Replace("%APPDATA%", appDataLocation));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        public static void removePack(string packFileName)
        {
            string appDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            File.Delete(@"%APPDATA%\.minecraft\resourcepacks\FaIaLaEaNaAaMaE.zip".Replace("FaIaLaEaNaAaMaE", packFileName).Replace("%APPDATA%", appDataLocation)); }

    }
}
