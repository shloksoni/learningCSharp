using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CoreCodeCamp.Data.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace CoreCodeCamp.Controllers
{
  [Route("api/[controller]")]
  public class ValuesController  : ControllerBase
  {
        private IHashMapRepository _HashMapRepository;

        public ValuesController(IHashMapRepository hashMapRepository)
        {
            _HashMapRepository = hashMapRepository;
            

        }

        [HttpGet("{id}")]
        public string Get(string id)

    {
            if (id != null)
                return _HashMapRepository.GetValue(id);
            else return "keyNUll";
    }
        [HttpPost]
        public IActionResult Post([FromBody] Req req)
        {
            if(_HashMapRepository.ContainsKey(req.key))
                return Conflict("Already Exisits");
            else
            {
                _HashMapRepository.AddKey(req.key, req.value);
                return Ok("Added");
            }
        }

        public IActionResult Patch([FromBody] Req req)
        {
            if (! _HashMapRepository.ContainsKey(req.key))
                return NotFound("Key Does Not exisit");
            else
            {
                _HashMapRepository.AddKey(req.key, req.value);
                return Ok("Updated");
            }
        }
        public IActionResult Delete([FromBody] Req req)
        {
            if (!_HashMapRepository.ContainsKey(req.key))
                return NotFound("Key Does Not exisit");
            else
            {
                _HashMapRepository.DeleteKey(req.key);
                return Ok("Deleted");
            }
        }

    }
    public class Req
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}
