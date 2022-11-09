using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace USAIDICANBLAZOR.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpreedSheetApi : ControllerBase
    {
        // GET: api/<SpreedSheetApi>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SpreedSheetApi>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SpreedSheetApi>
        [HttpPost]
        public IActionResult Post(/*[FromBody] */IFormCollection openRequest)
        {
            OpenRequest open = new OpenRequest();
            open.File = openRequest.Files[0];
            return Content(Workbook.Open(open));
        }

        [HttpPost]
        [Route("PostSave")]
        public IActionResult PostSave(SaveSettings saveSettings, string customParams)
        {
            return Workbook.Save(saveSettings);
        }

        // PUT api/<SpreedSheetApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpreedSheetApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
