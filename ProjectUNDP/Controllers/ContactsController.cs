using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactUNDPModels;
using MyContactManagerData;
using Microsoft.AspNetCore.Authorization;

namespace ProjectUNDP.Controllers
{
    public class ContactsController : Controller

    {

        private readonly MyContactManagerDBContext _context;
        //  private static List<State> _allStates;
        // private static List<Country> _allCountries;

        //   private static SelectList _statesData;
        //  private static SelectList _countriesData;*/



        public ContactsController(MyContactManagerDBContext context)
        {
            _context = context;
            /*   _allStates = Task.Run(() => _context.States.ToListAsync()).Result;
          //     _allCountries = Task.Run(() => _context.CountryName.ToListAsync()).Result;
               _statesData = new SelectList(_allStates, "Id", "Abbreviation");
            //   _countriesData = new SelectList(_allCountries, "Id", "CountryName");*/
        }

        private async Task UpdateStateAndResetModalState(Contact contact)
        {
            ModelState.Clear();
            var state = await _context.States.SingleOrDefaultAsync(x => x.Id == contact.StateId);
            contact.State = state;
            TryValidateModel(contact);
        }


        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            var contacts = _context.Contacts.Include(c => c.CountryName).Include(c => c.State);
            return View(await contacts.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.CountryName)
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.CountryName, "Id", "CountryName");
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Abbreviation");
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhonePrimary,PhoneSecondary,Birthday,StreetAddress1,StreetAddress2,City,CountryId,StateId,Zip,UserId")] Contact contact)
        {
            UpdateStateAndResetModalState(contact);
            if (ModelState.IsValid)
            {
                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.CountryName, "Id", "CountryName", contact.CountryId);
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Abbreviation", contact.StateId);
            return View(contact);
        }

        // GET: Contacts/Edit/5
       /* public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.CountryName, "Id", "CountryName", contact.CountryId);
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Abbreviation", contact.StateId);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhonePrimary,PhoneSecondary,Birthday,StreetAddress1,StreetAddress2,City,CountryId,StateId,Zip,UserId")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }
            UpdateStateAndResetModalState(contact);
            if (ModelState.IsValid)
            {
                try
                {

                    _context.Contacts.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
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
            ViewData["CountryId"] = new SelectList(_context.CountryName, "Id", "CountryName", contact.CountryId);
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Abbreviation", contact.StateId);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.CountryName)
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contacts == null)
            {
                return Problem("Entity set 'MyContactManagerDBContext.Contacts'  is null.");
            }
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}



