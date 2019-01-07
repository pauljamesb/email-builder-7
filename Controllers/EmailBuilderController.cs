using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNCT5.Data;
using Microsoft.AspNetCore.Mvc;

namespace Eb7.Controllers
{
        public class EB7 : Controller
        {
        
                private readonly ApplicationDbContext _db;
                public EB7(ApplicationDbContext db)
                {
                        _db = db;
                }
                
                public IActionResult Index()
                {       
                        return View(_db.EmailsDb.ToList());
                }
                
                
                // Create actions
                public IActionResult CreateEmail()
                {
                        return View();
                }
                
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> CreateEmail(Email email)
                {
                        if(ModelState.IsValid)
                        {
                                _db.Add(email);
                                await _db.SaveChangesAsync();
                                return RedirectToAction("Index");
                        }
                        return View(email);
                }
        
        }
}
