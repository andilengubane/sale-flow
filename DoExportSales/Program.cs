using BusinessLogic;
using ExportService;

namespace DoExportSales
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] campaignsToExport = Campaign.GetCampaignsToExport(); 

            for (int i = 0; i < campaignsToExport.Length; i++)
            {
                switch (campaignsToExport[i])
                {
                    case "EDCNWF":
                        //EDCNWF.DoExport();
                        break;
                    case "EDCWEL":
                        //EDCWEL.DoExport();
                        break;
                    case "EDCUP3":
                        //EDCUP3.DoExport();
                        break;
                    case "FNBFUN3":
                        //FNBFUN3.DoExport();
                        break;
                    case "FNBFUN4":
                        //FNBFUN4.DoExport();
                        break;
                    case "FNBAD":
                        FNBAD.DoExport();
                        break;
                    case "FNBADU":
                        //FNBADU.DoExport();
                        break;
                    case "FNBDPPC2":
                        //FNBDPPC2.DoExport();
                        break;
                    case "FNBDPPC3":
                        //FNBDPPC3.DoExport();
                        break;
                    case "FNBDPPCL":
                        //FNBDPPCL.DoExport();
                        break;
                    case "RCUNITRA":
                         //RCUNITRA.DoExport(); 
                        break;
                    case "RCWESBAD":
                        //RCWESBAD.DoExport();
                        break;
                    case "RCWESTBA":
                        //RCWESTBA.DoExport();
                        break;
                    case "RCWESNTU":
                        //RCWESNTU.DoExport();
                        break;
                    case "RCAUDC":
                        //RCAUDC.DoExport();
                        break;
                    case "RCVWDC":
                        //RCVWDC.DoExport();
                        break;
                    case "RCNEDD":
                        //RCNEDD.DoExport();
                        break;
                    case "QCMSBNK":
                        //QCMSBNK.DoExport();
                        break;
                    case "QCRTA":
                        //QCRTA.DoExport();
                        break;
                    case "RCABSA4":
                        RCABSA4.DoExport();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
