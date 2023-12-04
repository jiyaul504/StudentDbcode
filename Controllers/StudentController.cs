using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentDbcode.Models;
using System.Globalization;
using System.Text;

namespace StudentDbcode.Controllers
{
    public class StudentController : Controller
    {
        private readonly SampleDbContext _context;

        public StudentController(SampleDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {


            return View(await _context.TblStudents.ToListAsync());
        }
        
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblStudent = await _context.TblStudents
                .FirstOrDefaultAsync(m => m.StudentGid == id);
            if (tblStudent == null)
            {
                return NotFound();
            }

            return View(tblStudent);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewData["PlaceofBirth"] = new SelectList(_context.TblCountries.ToList(), "CountryId" ,"CountryName");
            ViewData["Nationality"] = new SelectList(_context.TblCountries.ToList(), "CountryId", "CountryName");
            ViewData["Gender"] = new SelectList(_context.TblGenders.ToList(), "GenderId", "Gender");
            ViewData["Tblldtype"] = new SelectList(_context.TblIdtypes.ToList(), "IdtypeId", "Idtype");

            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentGid,StudentName,PlaceofBirth,Nationality,DateofBirth,Idtype,Idnumber,Gender,Phone,FullAddress,IsActive,MDate,MDateTime,CountryID,CountryName")] TblStudent tblStudent)
        {
            Guid id = Guid.NewGuid();
            
            tblStudent.StudentGid = id.ToString();
            tblStudent.MDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            tblStudent.MDateTime = DateTime.Now;
            _context.Add(tblStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
            return View(tblStudent);
        }

        

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblStudent = await _context.TblStudents.FindAsync(id);
            if (tblStudent == null)
            {
                return NotFound();
            }
            return View(tblStudent);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentGid,StudentName,PlaceofBirth,Nationality,DateofBirth,Idtype,Idnumber,Gender,Phone,FullAddress,IsActive,MDate,MDateTime,CountryID,CountryName")] TblStudent tblStudent)
        {
            if (id != tblStudent.StudentGid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblStudentExists(tblStudent.StudentGid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblStudent);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblStudent = await _context.TblStudents
                .FirstOrDefaultAsync(m => m.StudentGid == id);
            if (tblStudent == null)
            {
                return NotFound();
            }

            return View(tblStudent);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblStudent = await _context.TblStudents.FindAsync(id);
            if (tblStudent != null)
            {
                _context.TblStudents.Remove(tblStudent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblStudentExists(string id)
        {
            return _context.TblStudents.Any(e => e.StudentGid == id);
        }

        public IActionResult Export()
        {
            var students = _context.TblStudents.ToList();
            var csv = new StringBuilder();
            csv.AppendLine("Id,FirstName,LastName,Age,Grade,Address,Email"); // CSV header

            foreach (var student in students)
            {
                csv.AppendLine($"{student.StudentGid},{student.StudentName},{student.Gender},{student.Nationality},{student.FullAddress},{student.PlaceofBirth}");
            }

            return File(Encoding.UTF8.GetBytes(csv.ToString()), "text/csv", "students.csv");
        }

        // Import action
        [HttpPost]
        public IActionResult Import(IFormFile file)
        {
            using (var stream = new StreamReader(file.OpenReadStream()))
            using (var csvReader = new CsvHelper.CsvReader(stream, CultureInfo.InvariantCulture))
            {
                while (csvReader.Read())
                {
                    var record = csvReader.GetRecord<TblStudent>();
                    _context.TblStudents.Add(record);
                }

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
