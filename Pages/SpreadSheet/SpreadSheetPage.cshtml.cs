using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace USAIDICANBLAZOR.Pages.SpreadSheet
{
    public class SpreadSheetPageModel : PageModel
    {
        public void OnGet(string filename)
        {
            //string webRootPath = _iweb.WebRootPath;

            //string path = "";
            //path = Path.Combine(webRootPath, "DODESCLab.xlsx");
            //ViewData["DefaultData"] = path;
            ViewData["filename"] = filename;
        }
    }
}
