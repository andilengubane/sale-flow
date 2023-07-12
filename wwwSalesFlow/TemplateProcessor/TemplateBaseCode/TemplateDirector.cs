using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wwwSalesFlow.TemplateProcessor
{
    public class TemplateDirector
    {
        private ITemplateBuilder templateBuilder;

        public TemplateDirector(ITemplateBuilder templateBuilder)
        {
            this.templateBuilder = templateBuilder;
        }

        public Template GetTemplate()
        {
            return templateBuilder.GetTemplate();
        }

        public void BuildTemplate()
        {
            templateBuilder.BuildImageCids();
            templateBuilder.BuildBodyHtml();
            templateBuilder.BuildAlternativeView();
        }
    }
}