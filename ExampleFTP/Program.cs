using System;
using Renci.SshNet;
using System.IO;

namespace ExampleFTP
{
    class Program
    {
        static void Main(string[] args)
        {
            ListFiles();   
        }

        private static void ListFiles()
        {
            String host = "192.168.1.171";
            String username = "pumarola77";
            String password = "perico01";

            String pathRemoteDirectory;
            String remoteDirectory = "/";
            String pathLocalFile;

            try
            {

                var client = new SftpClient(host, 2222, username, password);
                client.Connect();

                if (client.IsConnected)
                {
                    // LLegir directori amb els fitxers

                    var sftpClient = client.ListDirectory(remoteDirectory);

                    foreach (var contingut in sftpClient)
                    {
                        
                        if ( contingut.Name.Contains("DELNOT"))
                        {
                            pathLocalFile = "C:/Users/Bazinga/Proves/" + contingut.Name;
                            pathRemoteDirectory = remoteDirectory +  contingut.Name;
                            
                            using (Stream fileStream = File.OpenWrite(pathLocalFile))
                            {
                                client.DownloadFile(pathRemoteDirectory, fileStream);
                            }
                        }
                    }
                    
                    client.Disconnect();

                    //Lectura dels Fitxers d'un Directori. Utilitzant Pattern.
                    DirectoryInfo di = new DirectoryInfo("C:/Users/Bazinga/Proves");                    
                    foreach (var fi in di.GetFiles("*DELNOT*"))
                    {
                        //Tractament Fitxer DELNOT
                        pathLocalFile = "C:/Users/Bazinga/Proves/" + fi;
                        TractamentDELNOT.LecturaDELNOT(pathLocalFile);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception has been caught " + e.ToString());
            }
        }
    }

}