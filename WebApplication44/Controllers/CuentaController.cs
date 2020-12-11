using backend.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication44.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication44.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("*")]
    public class CuentaController : ControllerBase
    {
        private readonly AppDbContext context;

        public CuentaController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<ValuesController1>
        
        [HttpGet]
        public IEnumerable<Cuenta> Get()
        {
            return context.cuenta.ToList();
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        public Cuenta Get(int id)
        {
            var cuenta= context.cuenta.FirstOrDefault(cu=>cu.AccountNumber==id);
            if(cuenta != null)
            {
                return cuenta;
            }
            else
            {
                return null;
            }
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public ActionResult Post([FromBody] Cuenta cuenta)
        {
            int val1 = 0;
            int val2 = 0;
            int val3 = 0; 
            if( cuenta.AccountType !=1 && cuenta.AccountType != 2)
            {
                val1 = 0;
            }
            if (cuenta.AccountType == 2)
            {
                if (cuenta.Saldo > 200)
                {
                    val2 = 1;
                }
            }      
                
             
            try
            {
               if(val2==1 && val1 == 1) { 
                    context.cuenta.Add(cuenta);
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

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cuenta cuenta)
        {
            if (cuenta.Saldo < 100)
            {
                cuenta.Status1 = "bloqueada";
            }
            var cuenta2 = context.cuenta.FirstOrDefault(cu => cu.AccountNumber == id);
            if (cuenta.Status1 == "Bloqueado" && cuenta.Saldo != cuenta2.Saldo)
            {
                    return BadRequest();
            }
            else
            {
                context.Entry(cuenta).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
        
           
        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var cuenta = context.cuenta.FirstOrDefault(cu => cu.AccountNumber == id);
                context.cuenta.Remove(cuenta);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
        }
    }
}
