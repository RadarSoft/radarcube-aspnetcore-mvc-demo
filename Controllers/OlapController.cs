using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using radarcube_aspnetcore_mvc_demo.TagHelpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;

namespace radarcube_aspnetcore_mvc_demo.Controllers
{
    public class OlapController : Controller
    {
        IHttpContextAccessor _httpContextAccessor;
        IHostingEnvironment _hosting;
        public OlapController(IHttpContextAccessor httpContextAccessor, IHostingEnvironment hosting)
        //public OlapController(IHostingEnvironment hosting)
        {
            _httpContextAccessor = httpContextAccessor;
            _hosting = hosting;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult CallbackHandler(string olapcallbackarg, string data, IFormFile file)
        {
            var olapAnalysis = new OlapTagHelper(_httpContextAccessor, _hosting);

            if (!string.IsNullOrEmpty(olapcallbackarg))
                return Json(olapAnalysis.DoCallback(olapcallbackarg, data));

            if (file != null)
                return Json(olapAnalysis.LoadSettings(file));

            return null;
        }

        [HttpPost]
        public IActionResult ExportHandler(string olapexportarg)
        {
            var olapAnalysis = new OlapTagHelper(_httpContextAccessor, _hosting);
            return olapAnalysis.DoExport(olapexportarg);
        }
    }
}