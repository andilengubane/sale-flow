using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace wwwSalesFlow.TemplateProcessor
{
    public class RCABSAOnePagerTemplate : ITemplateBuilder
    {
        private Template _template;

        public RCABSAOnePagerTemplate()
        {
            _template = new Template();
        }

        public void BuildImageCids()
        {
            string headerPath = HttpContext.Current.Server.MapPath("~/TemplateProcessor/EmailTemplates/RoadCover/Absa/header.png");
            string footerPath = HttpContext.Current.Server.MapPath("~/TemplateProcessor/EmailTemplates/RoadCover/Absa/footer.jpg");

            List<KeyValuePair<string, string>> imageCids = new List<KeyValuePair<string, string>>();
            KeyValuePair<string, string> headerImageCidPaths = new KeyValuePair<string, string>("header", headerPath);
            KeyValuePair<string, string> footerImageCidPaths = new KeyValuePair<string, string>("footer", footerPath);

            imageCids.Add(headerImageCidPaths);
            imageCids.Add(footerImageCidPaths);

            _template.SetTemplateImageCids(imageCids);
        }

        public void BuildBodyHtml()
        {
            string filePath = HttpContext.Current.Server.MapPath("~/TemplateProcessor/EmailTemplates/RoadCover/Absa/roadcover_absa.html");
            string html = File.ReadAllText(filePath);

            _template.SetTemplateBodyHtml(html);
        }

        public void BuildAlternativeView()
        {
            AlternateView htmlAlternateView = AlternateView.CreateAlternateViewFromString(_template.GetTemplateBodyHtml(), null, MediaTypeNames.Text.Html);

            foreach (KeyValuePair<string, string> imageCid in _template.GetTemplateImageCids())
            {
                LinkedResource lr = new LinkedResource(imageCid.Value);
                lr.ContentId = imageCid.Key;
                htmlAlternateView.LinkedResources.Add(lr);
            }

            _template.SetAlternativeViewForMail(htmlAlternateView);
        }

        public Template GetTemplate()
        {
            return _template;
        }
    }
}