using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Identity.Model.Infastructure;
using Identity.Model.ViewModel;

namespace Identity.Controllers
{
    public class UserSettingViewModelsController : Controller
    {


        public UserSettingViewModelsController()
        {

        }

        // GET: UserSettingViewModels
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: UserSettingViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            return View();
        }

        // GET: UserSettingViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserSettingViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,FirstName,MiddleName,LastName,Number,Street,City,Email,PhoneNumber,TwoFactorEnabled")] UserSettingViewModel userSettingViewModel)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction(nameof(Index));
            }
            return View(userSettingViewModel);
        }

        // GET: UserSettingViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            return View();
        }

        // POST: UserSettingViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,FirstName,MiddleName,LastName,Number,Street,City,Email,PhoneNumber,TwoFactorEnabled")] UserSettingViewModel userSettingViewModel)
        {
            if (id != userSettingViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(userSettingViewModel);
        }

        // GET: UserSettingViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            return View();
        }

        // POST: UserSettingViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            return RedirectToAction(nameof(Index));
        }


    }
}
