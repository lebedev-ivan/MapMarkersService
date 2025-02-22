using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/markers")]
[ApiController]
public class MarkersController : ControllerBase
{
    private readonly AppDbContext _context;

    public MarkersController(AppDbContext context)
    {
        _context = context;
    }

    // Получение всех меток
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Marker>>> GetMarkers()
    {
        return await _context.Markers.ToListAsync();
    }

    // Добавление новой метки
    [HttpPost]
    public async Task<ActionResult<Marker>> PostMarker(Marker marker)
    {
        if (marker == null || string.IsNullOrWhiteSpace(marker.Name))
        {
            return BadRequest("Некорректные данные.");
        }

        _context.Markers.Add(marker);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMarkers), new { id = marker.Id }, marker);
    }
}
