using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wwwSalesFlow.TemplateProcessor
{
    public interface ITemplatePlan
    {
        void SetTemplateImageCids(List<KeyValuePair<string, string>> imageCids);
        void SetTemplateBodyHtml(string bodyHtml);
        void SetAlternativeViewForMail(AlternateView mailView);
    }
}
