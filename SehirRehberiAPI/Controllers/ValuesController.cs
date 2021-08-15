using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SehirRehberiAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ValuesController : ControllerBase
    {
        private DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("getall")]
        public async Task<ActionResult>  GetValues()
        {
            var values =  await _context.Values.ToListAsync();
            return Ok(values);
        }

        [HttpGet("getid")]
        public async Task<ActionResult> GetId(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(v => v.Id == id);
            return Ok(value);
        }

    }
}
