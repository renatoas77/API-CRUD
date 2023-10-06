using Aplicativo_de_cadastro_crud.Context;
using Aplicativo_de_cadastro_crud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Aplicativo_de_cadastro_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Persons
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var list = await _context.Persons.ToListAsync();

            if (list.Any<Person>())
            {
                return await _context.Persons.ToListAsync();
            }
            return NotFound();

        }

        // GET: api/Person
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(p => p.PersonId == id);

            if (person == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(person);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Person>> UpdatePerson(int id, Person person)
        {
            if (person == null || person.PersonId != id)
            {
                return BadRequest();
            }

            var result = await _context.Persons.AsNoTracking().FirstOrDefaultAsync(p => p.PersonId == id);
            if (result == null)
            {
                return NotFound();
            }

            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(person);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            var person = await _context.Persons.AsNoTracking().FirstOrDefaultAsync(p => p.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Remove(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }
    }
}
