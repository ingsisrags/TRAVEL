using Application.Library.Interfaces;
using Domain.Library.Configuration.Dtos.Input;
using Domain.Library.Configuration.Dtos.Output;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DistributedServices.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialService _editorialService;
        public EditorialController(IEditorialService  editorialService)
        {
            _editorialService = editorialService;
        }
        
        // GET: api/<BookController>

        [HttpGet]
        public async Task<IEnumerable<EditorialOutput>> Get()
        {
            return await _editorialService.GetAll();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<EditorialOutput> Get(int id)
        {
            return await _editorialService.GetById(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<EditorialOutput> Post([FromBody] CreateEditorialInput  input)
        {
            return await _editorialService.Create(input);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
