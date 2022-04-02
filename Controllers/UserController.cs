using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryAppConversion.DataAccess;
using Models;
using Services;

namespace InventoryAppConversionDN5.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private CompaniesController _companiesController;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
            _companiesController = new CompaniesController(context);
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users
                .Include(u => u.Role)
                .Include(ua => ua.Company)
                .ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Email == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Email,Active,FirstName,LastName,Password,RegistrationKey,Salt")] User user)
        public async Task<IActionResult> Create(string Email, string Password, bool Active, string FirstName, string LastName, string Company)
        {            
            string saltToStore;
            string encryptedPassword = PasswordService.encryptPassword(Password, out saltToStore);
            Console.WriteLine($"Encrypted password is: {encryptedPassword}");

            Random rnd = new Random();
            Company userCompany;
            Company found = _context.Companys.FirstOrDefault(c => c.CompanyName == Company);
            
            if(found == null)
            {
                userCompany = new Company(rnd.Next(100, 999), Company);
                try
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(userCompany);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to add company");
                    Console.WriteLine(ex.ToString());
                }
            } else
            {
                Console.WriteLine($"The database search result found: {found.CompanyName}");
                userCompany = found;
            }
           
            User user = new User(Email, Active, FirstName, LastName, encryptedPassword, saltToStore, userCompany, null);
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email,Active,FirstName,LastName,Password,RegistrationKey,Salt")] User user)
        {
            if (id != user.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Email))
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
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Email == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Email == id);
        }
    }
}
