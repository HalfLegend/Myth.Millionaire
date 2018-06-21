using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myth.Millionaire.Forms.UI.Pages.CreditMasterDetail
{

    public class CreditMasterDetailPageMenuItem
    {
        public CreditMasterDetailPageMenuItem()
        {
            TargetType = typeof(CreditMasterDetailPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}