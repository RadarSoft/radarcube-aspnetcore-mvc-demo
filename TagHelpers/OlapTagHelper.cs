using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using RadarSoft.RadarCube.Controls.TagHelpers;
using RadarSoft.RadarCube.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace radarcube_aspnetcore_mvc_demo.TagHelpers
{
    public class OlapTagHelper : MOlapAnalysisTagHelper
    {
        public OlapTagHelper(IHttpContextAccessor httpContextAccessor, IHostingEnvironment hosting) :
        //public OlapTagHelper(HttpContext httpContext, IHostingEnvironment hosting) :
            base(httpContextAccessor, hosting)
        {
            ID = "Olap1";
            AddResourceStrings("Resources/Resources.en.resx", new CultureInfo("en-US"));
        }

        public override void Init()
        {
            base.Init();
            LinesInPage = 5;
            PivotingBehavior = PivotingBehavior.RadarCube;
            //BeginUpdate();
            //PivotingFirst(Dimensions.FindHierarchy("[Product].[Category]"), LayoutArea.laRow);
            //PivotingFirst(Dimensions.FindHierarchy("[Date].[Fiscal Year]"), LayoutArea.laColumn);
            //PivotingFirst(Dimensions.FindHierarchy("[Customer].[Customer Geography]"), LayoutArea.laRow);
            //Pivoting(Measures.Find("[Measures].[Internet Sales-Unit Price]"), LayoutArea.laRow, null);
            //var m = Measures.Find("[Measures].[UnitPrice]");
            //Pivoting(m);
            //EndUpdate();
        }
    }
}
