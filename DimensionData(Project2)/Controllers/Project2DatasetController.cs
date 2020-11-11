using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DimensionData_Project2_.Data;
using DimensionData_Project2_.Models;

namespace DimensionData_Project2_.Controllers
{
    public class Project2DatasetController : Controller
    {
        private readonly DimensionDataContext _context;

        public Project2DatasetController(DimensionDataContext context)
        {
            _context = context;
        }

        // GET: Project2Dataset
        public async Task<IActionResult> Index()
        {
            return View(await _context.Project2Dataset.ToListAsync());
        }

        // GET: Project2Dataset/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project2Dataset = await _context.Project2Dataset
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (project2Dataset == null)
            {
                return NotFound();
            }

            return View(project2Dataset);
        }

        // GET: Project2Dataset/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Project2Dataset/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Age,Attrition,BusinessTravel,DailyRate,Department,DistanceFromHome,Education,EducationField,EmployeeCount,EmployeeNumber,EnvironmentSatisfaction,Gender,HourlyRate,JobInvolvement,JobLevel,JobRole,JobSatisfaction,MaritalStatus,MonthlyIncome,MonthlyRate,NumCompaniesWorked,Over18,OverTime,PercentSalaryHike,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] Project2Dataset project2Dataset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project2Dataset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project2Dataset);
        }

        // GET: Project2Dataset/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project2Dataset = await _context.Project2Dataset.FindAsync(id);
            if (project2Dataset == null)
            {
                return NotFound();
            }
            return View(project2Dataset);
        }

        // POST: Project2Dataset/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Age,Attrition,BusinessTravel,DailyRate,Department,DistanceFromHome,Education,EducationField,EmployeeCount,EmployeeNumber,EnvironmentSatisfaction,Gender,HourlyRate,JobInvolvement,JobLevel,JobRole,JobSatisfaction,MaritalStatus,MonthlyIncome,MonthlyRate,NumCompaniesWorked,Over18,OverTime,PercentSalaryHike,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] Project2Dataset project2Dataset)
        {
            if (id != project2Dataset.EmployeeNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project2Dataset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Project2DatasetExists(project2Dataset.EmployeeNumber))
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
            return View(project2Dataset);
        }

        // GET: Project2Dataset/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project2Dataset = await _context.Project2Dataset
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (project2Dataset == null)
            {
                return NotFound();
            }

            return View(project2Dataset);
        }

        // POST: Project2Dataset/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var project2Dataset = await _context.Project2Dataset.FindAsync(id);
            _context.Project2Dataset.Remove(project2Dataset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Project2DatasetExists(string id)
        {
            return _context.Project2Dataset.Any(e => e.EmployeeNumber == id);
        }
    }
}
