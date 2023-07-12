using System;
using System.IO;
using Renci.SshNet;

namespace ExportService.Edcon.Extensions
{
    public class EdconService
    {
        public static bool IsAllDigits(string input)
        {
            foreach (char data in input)
            {
                if (!char.IsDigit(data))
                    return false;
            }
            return true;
        }

        public static string StringPeding(string input, int number)
        {
            int numberOfCharactors = number - input.Length;
            return input + String.Empty.PadRight(numberOfCharactors, ' ');
        }

        public static void UplaodFileToSftp(string productFiles, string detailsFiles)
        {
            string destinationpath = @"/home/roadret";
            using (SftpClient client = new SftpClient("sftp.bytes.co.za", 22, "roadret", "Roadcover123"))
            {
                client.Connect();
                client.ChangeDirectory(destinationpath);
                using (FileStream fileStream = new FileStream(productFiles, FileMode.Open))
                {
                    client.BufferSize = 4 * 1024;
                    client.UploadFile(fileStream, Path.GetFileName(productFiles));
                }

                using (FileStream fileStream = new FileStream(detailsFiles, FileMode.Open))
                {
                    client.BufferSize = 4 * 1024;
                    client.UploadFile(fileStream, Path.GetFileName(detailsFiles));
                }
            }
        }
    }
}
