using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class StudentApiController : ControllerBase
{
    private readonly MvcUniversityContext _context;

    public StudentApiController(MvcUniversityContext context)
    {
        _context = context;
    }

    // GET: api/StudentApi
    public async Task<ActionResult<IEnumerable<Student>>> getStudents()
    {
        Console.WriteLine("list all");

        return await _context.Students.OrderBy(e => e.FirstName).ToListAsync();
    }

    // GET: api/StudentApi/
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> getStudent(int id)
    {
        Console.WriteLine("list one");

        //TODO: faire jointure pour récupérer les données des Enrollments
        var student = await _context.Students.Where(s => s.Id == id)
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .SingleOrDefaultAsync();
        // Soit récupère une seule valeur ou envoie la valeur par défaut si 
        // l'identification ne correspond à rien dans la base de données

        if (student == null)
        {
            return NotFound();
        }

        return student;
    }

    // POST: api/StudentApi
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetStudent", new { id = student.Id }, student);
    }

    // Returns true if a student with specified id already exists
    private bool StudentExist(int id)
    {
        return _context.Students.Any(t => t.Id == id);
    }

    // DELETE: api/StudentApi/
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        Console.WriteLine("delete");
        var student = await _context.Students.FindAsync(id);
        if (student == null)
            return NotFound();

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
