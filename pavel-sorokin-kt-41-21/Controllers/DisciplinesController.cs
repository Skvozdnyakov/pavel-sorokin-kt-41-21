using pavel_sorokin_kt_41_21.Filters.DisciplineFilters;
using pavel_sorokin_kt_41_21.Interfaces.DisciplinesInterfaces;
using pavel_sorokin_kt_41_21.Models;
using Microsoft.AspNetCore.Mvc;
using pavel_sorokin_kt_41_21.Database;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace pavel_sorokin_kt_41_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisciplinesController : ControllerBase
    {
        private readonly ILogger<DisciplinesController> _logger;
        private readonly IDisciplineService _disciplineService;
        StudentDbContext _context;
        public DisciplinesController(ILogger<DisciplinesController> logger, IDisciplineService disciplineService, StudentDbContext context)
        {
            _logger = logger;
            _disciplineService = disciplineService;
            _context = context;
        }

        //äîáàâëåíèå
        [HttpPost("AddDiscipline", Name = "AddDiscipline")]
        public IActionResult CreateDiscipline([FromBody] DisciplineAddFilter filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var discipline = new Discipline();
            discipline.DisciplineName = filter.DisciplineName;
            discipline.Direction = filter.Direction;
            discipline.IsDeleted = false;

            _context.Set<Discipline>().Add(discipline);
            _context.SaveChanges();
            return Ok(discipline);
        }

        [HttpPut("EditDiscipline")]
        public IActionResult UpdateDiscipline(int id, [FromBody] DisciplineAddFilter filter)
        {
            var UpdDiscipline = _context.Set<Discipline>().FirstOrDefault(g => g.DisciplineId == id);

            if (UpdDiscipline == null)
            {
                return NotFound();
            }

            UpdDiscipline.DisciplineName = filter.DisciplineName;
            UpdDiscipline.Direction = filter.Direction;
            UpdDiscipline.IsDeleted = filter.IsDeleted;

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("GetDisciplinesByDirection")]
        public async Task<IActionResult> GetDisciplinesByDirectionAsync(DisciplineDirectionFilter filter, CancellationToken cancellationToken = default)
        {
            var disciplines = await _disciplineService.GetDisciplinesByDirectionAsync(filter, cancellationToken);

            return Ok(disciplines);
        }


        [HttpPost("GetDisciplinesIsDeleted")]
        public async Task<IActionResult> GetDisciplinesByExistAsync(DisciplineDeletedFilter filter, CancellationToken cancellationToken = default)
        {
            var disciplines = await _disciplineService.GetDisciplinesIsDeletedAsync(filter, cancellationToken);

            return Ok(disciplines);
        }

        [HttpDelete("DeleteDiscipline")]
        public IActionResult DeleteGroup(int id)
        {
            var existingDiscipline = _context.Set<Discipline>().FirstOrDefault(g => g.DisciplineId == id);

            if (existingDiscipline == null)
            {
                return NotFound();
            }
            //_context.Set<Discipline>().Remove(existingDiscipline);
            existingDiscipline.IsDeleted = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}