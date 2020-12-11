using backend.Context;
using backend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication44.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext context;

        // GET: api/<Clientes>
        public ClienteController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return context.clientes.ToList();
        }

        // GET api/<Clientes>/5
        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            var cliente = context.clientes.FirstOrDefault(cl=>cl.ClientNumber == id);
            return cliente;
        }

        // POST api/<Clientes>
        [HttpPost]
        public ActionResult Post([FromBody] Cliente  cliente)
        {
            try
            {
                if (context.clientes.FirstOrDefault(cl => cl.Identity1 == cliente.Identity1) != null)
                {
                    context.clientes.Add(cliente);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
              
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // PUT api/<Clientes>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cliente cliente)
        {
            int identidad = cliente.Identity1;
            int identificador = cliente.ClientNumber;

            if (context.clientes.FirstOrDefault(cl=>cl.Identity1 == identidad) != null && context.clientes.FirstOrDefault(cl => cl.ClientNumber == identificador)==null)
            {
                context.Entry(cliente).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<Clientes>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var clientela = context.clientes.FirstOrDefault(cl => cl.ClientNumber == id);
            if(clientela != null)
            {
                context.clientes.Remove(clientela);
                return Ok();
            }
            else {
                return BadRequest();
            }
        }
    }
}
