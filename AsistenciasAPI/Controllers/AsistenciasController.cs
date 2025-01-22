using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsistenciasAPI.Models;
using AsistenciasShared;

[Route("api/[controller]")]
[ApiController]
public class AsistenciasController : ControllerBase
{
    private readonly AsistenciasContext _context;

    public AsistenciasController(AsistenciasContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<AsistenciaDTO>>> GetAsistencias()
    {
        var Lista = await _context.Asistencias.ToListAsync();

        if (Lista == null)
        {
            return NotFound();
        }
        return Ok(Lista);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AsistenciaDTO>> GetAsistencia(int id)
    {
        var asistencia = await _context.Asistencias.FindAsync(id);

        if (asistencia == null)
        {
            return NotFound();
        }

        return Ok(asistencia);
    }

    [HttpPost]
    public async Task<ActionResult<AsistenciaDTO>> PostAsistencia(Asistencia asistencia)
    {
        _context.Asistencias.Add(asistencia);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAsistencia), new { id = asistencia.Id }, asistencia);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsistencia(int id, AsistenciaDTO asistencia)
    {
        if (id != asistencia.Id)
        {
            return BadRequest();
        }

        _context.Entry(asistencia).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AsistenciaExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsistencia(int id)
    {
        var asistencia = await _context.Asistencias.FindAsync(id);

        if (asistencia == null)
        {
            return NotFound();
        }

        _context.Asistencias.Remove(asistencia);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AsistenciaExists(int id)
    {
        return _context.Asistencias.Any(e => e.Id == id);
    }
}

