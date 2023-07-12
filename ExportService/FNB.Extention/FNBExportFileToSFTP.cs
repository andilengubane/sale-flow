using System;
using System.IO;
using Renci.SshNet;

namespace ExportService.FNB.Extention
{
    public class FNBExportFileToSFTP
    {
        public static void UplaodFileToSftp(string fileUploadWithbankingDetails)
        {
            string destinationpath = @"/home/roadret";

            //TODO : change sftp credintials

            //sftp2_result = upload_file_sftp('192.168.80.200'
            //                     , 'fnbdppcl'
            //                     , localpath
            //                     , '/home/fnbdppcl/OUT/%s' % filename
            //                     , '/root/.ssh/afe_service.key'
            //                     , '+7+OOKjbdKh46Dwn')

            using (SftpClient client = new SftpClient("sftp.bytes.co.za", 22, "roadret", "Roadcover123"))
            {
                client.Connect();
                client.ChangeDirectory(destinationpath);
                using (FileStream fileStream = new FileStream(fileUploadWithbankingDetails, FileMode.Open))
                {
                    client.BufferSize = 4 * 1024;
                    client.UploadFile(fileStream, Path.GetFileName(fileUploadWithbankingDetails));
                }
            }
        }
    }
}
