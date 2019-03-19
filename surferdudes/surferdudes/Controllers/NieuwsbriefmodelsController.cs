using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using surferdudes.Models;

namespace surferdudes.Controllers
{
    public class NieuwsbriefmodelsController : Controller
    {
        private readonly surferdudesContext _context;

        public NieuwsbriefmodelsController(surferdudesContext context)
        {
            _context = context;
        }

        // GET: Nieuwsbriefmodels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nieuwsbriefmodel.ToListAsync());
        }

        // GET: Nieuwsbriefmodels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nieuwsbriefmodel = await _context.Nieuwsbriefmodel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nieuwsbriefmodel == null)
            {
                return NotFound();
            }

            return View(nieuwsbriefmodel);
        }

        // GET: Nieuwsbriefmodels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nieuwsbriefmodels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Voornaam,Achternaam,Geslacht,Land,Email")] Nieuwsbriefmodel nieuwsbriefmodel)
        {
            if (ModelState.IsValid)
            {
                string bericht = ". Bedankt voor het aanmelden, vanaf nu ontvangt u wekelijks onze nieuwsbrief, afmelden kan door te mailen naar dit emailadres.";
                string to = nieuwsbriefmodel.Email;
                string from = "surfdudes2019@gmail.com";
                string subject = "Nieuwsbrief";
                string body = @"Geachte" + " " + nieuwsbriefmodel.Voornaam + " " + nieuwsbriefmodel.Achternaam + bericht;
                MailMessage message = new MailMessage(from, to, subject, body);

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("surfdudes2019@gmail.com", "project2019");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                client.Send(message);


                _context.Add(nieuwsbriefmodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nieuwsbriefmodel);
        }

        // GET: Nieuwsbriefmodels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nieuwsbriefmodel = await _context.Nieuwsbriefmodel.FindAsync(id);
            if (nieuwsbriefmodel == null)
            {
                return NotFound();
            }
            return View(nieuwsbriefmodel);
        }

        // POST: Nieuwsbriefmodels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Voornaam,Achternaam,Geslacht,Land,Email")] Nieuwsbriefmodel nieuwsbriefmodel)
        {
            if (id != nieuwsbriefmodel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nieuwsbriefmodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NieuwsbriefmodelExists(nieuwsbriefmodel.ID))
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
            return View(nieuwsbriefmodel);
        }

        // GET: Nieuwsbriefmodels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nieuwsbriefmodel = await _context.Nieuwsbriefmodel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nieuwsbriefmodel == null)
            {
                return NotFound();
            }

            return View(nieuwsbriefmodel);
        }

        // POST: Nieuwsbriefmodels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nieuwsbriefmodel = await _context.Nieuwsbriefmodel.FindAsync(id);
            _context.Nieuwsbriefmodel.Remove(nieuwsbriefmodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NieuwsbriefmodelExists(int id)
        {
            return _context.Nieuwsbriefmodel.Any(e => e.ID == id);
        }
    }
}
