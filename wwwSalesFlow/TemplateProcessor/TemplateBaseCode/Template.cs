using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace wwwSalesFlow.TemplateProcessor
{
    public class Template : ITemplatePlan
    {
        private string _bodyHtml;
        private List<KeyValuePair<string, string>> _imageCids;
        private AlternateView _mailView;

        public string GetTemplateBodyHtml()
        {
            return _bodyHtml;
        }

        public void SetTemplateBodyHtml(string bodyHtml)
        {
            _bodyHtml = bodyHtml;
        }

        public List<KeyValuePair<string, string>> GetTemplateImageCids()
        {
            return _imageCids;
        }

        public void SetTemplateImageCids(List<KeyValuePair<string, string>> imageCids)
        {
            _imageCids = imageCids;
        }

        public AlternateView GetAlternativeViewForMail()
        {
            return _mailView;
        }

        public void SetAlternativeViewForMail(AlternateView mailView)
        {
            _mailView = mailView;
        }
    }
}