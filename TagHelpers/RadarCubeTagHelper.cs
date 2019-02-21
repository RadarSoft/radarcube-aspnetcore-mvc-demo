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

namespace radarcube_aspnetcore_mvc_demo.TagHelpers
{
    public class RadarCubeTagHelper : MOlapAnalysisTagHelper
    {
        public RadarCubeTagHelper(IHttpContextAccessor httpContextAccessor, IHostingEnvironment hosting) : 
            base(httpContextAccessor, hosting)
        {
            ID = "OlapAnalysis1";
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
            //var m = Measures.Find("[Measures].[Internet Sales Count]");
            //Pivoting(m);
            //EndUpdate();


        }

        //private void Activate()
        //{
        //    SqlConnectionStringBuilder csBuilder = new SqlConnectionStringBuilder();
        //    csBuilder.DataSource = "http://localhost/OLAP/msmdpump.dll";
        //    csBuilder.InitialCatalog = @"AdventureWorksDW2012Multidimensional-SE";
        //    csBuilder.ConnectTimeout = 30;
        //    //csBuilder.UserID = "sa";
        //    //csBuilder.Password = "admin@123";

        //    //Data Source=http://localhost/OLAP/msmdpump.dll;Initial Catalog="Analysis Services Tutorial";Connect Timeout=30
        //    string cs = csBuilder.ConnectionString;

        //    ConnectionString = cs;
        //    CubeName = "AdventureWorks";

        //    if (Active)
        //        Active = false;

        //    Active = true;
        //}
    }
}
