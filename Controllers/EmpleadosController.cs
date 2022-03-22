using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BiometricoApi.Entities;
using BiometricoApi.Services;

namespace BiometricoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly BiometricoDbContext _context;

        public EmpleadosController(BiometricoDbContext context)
        {
            _context = context;
        }
        // GET: api/Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }


        // GET: api/Empleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(Guid id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }


        // GET: /Buscar/Nombre/Marco%20Antonio%20Cantero%20C.
        //[HttpGet("/Buscar/Nombre/{nombreCompleto}")]
        //public async Task<ActionResult<Empleado>> BuscarNombre(string nombreCompleto)
        //{
        //    var empleado = await _context.Empleados.FirstOrDefaultAsync(x => x.NombreCompleto == nombreCompleto);

        //    if (empleado == null)
        //    {
        //        return NotFound();
        //    }

        //    return empleado;
        //}


        //[HttpPost("/Buscar/huella")]
        //public async Task<ActionResult<Empleado>> BuscarHuella(Huella huella)
        //{

        //    var empleado = await _context.Empleados.FirstOrDefaultAsync(x => x.Huella == huella.HuellaDactilar);

        //    if (empleado == null)
        //    {
        //        return NotFound();
        //    }

        //    return empleado;

        //}



        // PUT: api/Empleados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(Guid id, Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Empleados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleado", new { id = empleado.Id }, empleado);
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(Guid id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoExists(Guid id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }


    }

    //public class Huella
    //{
    //    public byte[] HuellaDactilar { get; set; }
    //}
}
