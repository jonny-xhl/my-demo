using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jonny.AllDemo.TongNanLIS.TongNanLis;
using System.Text;

namespace Jonny.AllDemo.TongNanLIS
{
    public partial class Index : System.Web.UI.Page
    {
        private static IWSYXLisservice lisservice = new IWSYXLisservice();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(GetLis());
        }

        private string GetLis()
        {
            var input = @"<LIS><RequestCode>PrintLisReport</RequestCode><RequestOptions><BeginDate>2020-03-08 17:14:36</BeginDate><EndDate>2020-04-09 17:14:40</EndDate><PatientNo>2004000170</PatientNo></RequestOptions></LIS>";
            var v = lisservice.Execute2(input);
            return v;
        }

    }
}