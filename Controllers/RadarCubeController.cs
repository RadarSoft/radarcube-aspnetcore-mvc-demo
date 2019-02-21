using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using radarcube_aspnetcore_mvc_demo.TagHelpers;

namespace radarcube_aspnetcore_mvc_demo.Controllers
{
    public class RadarCubeController : Controller
    {
        IHttpContextAccessor _httpContextAccessor;
        IHostingEnvironment _hosting;
        public RadarCubeController(IHttpContextAccessor httpContextAccessor, IHostingEnvironment hosting)
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
            var olapAnalysis = new RadarCubeTagHelper(_httpContextAccessor, _hosting);

            if (!string.IsNullOrEmpty(olapcallbackarg))
                return Json(olapAnalysis.DoCallback(olapcallbackarg, data));

            if (file != null)
                return Json(olapAnalysis.LoadSettings(file));

            return null;
        }

        [HttpPost]
        public IActionResult ExportHandler(string olapexportarg)
        {
            var olapAnalysis = new RadarCubeTagHelper(_httpContextAccessor, _hosting);
            return olapAnalysis.DoExport(olapexportarg);
        }
    }
}