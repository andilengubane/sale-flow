using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wwwSalesFlow.TemplateProcessor
{
    public interface ITemplateBuilder
    {
        void BuildImageCids();
        void BuildBodyHtml();
        void BuildAlternativeView();
        Template GetTemplate();

    }
}
