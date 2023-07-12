using System.IO;
using Renci.SshNet;

namespace ExportService.RoadCover.Extensions
{
    public class ExportFileToSFTP
    {
        public static void UplaodFileToSftp(string fileUploadWithbankingDetails, string fileUploadWithNoBankingDetails, string destinationpath)
        {
            using (SftpClient client = new SftpClient("sftp.bytes.co.za", 22, "roadret", "Roadcover123"))
            {
                client.Connect();
                client.ChangeDirectory(destinationpath);
                using (FileStream fileStream = new FileStream(fileUploadWithbankingDetails, FileMode.Open))
                {
                    client.BufferSize = 4 * 1024;
                    client.UploadFile(fileStream, Path.GetFileName(fileUploadWithbankingDetails));
                }

                using (FileStream fileStream = new FileStream(fileUploadWithNoBankingDetails, FileMode.Open))
                {
                    client.BufferSize = 4 * 1024;
                    client.UploadFile(fileStream, Path.GetFileName(fileUploadWithNoBankingDetails));
                }
            }
        }

        public static void UplaodRCABSA4ToSFTP(string fileUploadWithbankingDetails, string sfptPath)
        {
            using (SftpClient client = new SftpClient("sftp.roadcover.co.za", 22, "RcBytes File drop", "ZUqgZ2M7"))
            {
                client.Connect();
                client.ChangeDirectory(sfptPath);
                using (FileStream fileStream = new FileStream(fileUploadWithbankingDetails, FileMode.Open))
                {
                    client.BufferSize = 4 * 1024;
                    client.UploadFile(fileStream, Path.GetFileName(fileUploadWithbankingDetails));
                }
            }
        }
    }
}
