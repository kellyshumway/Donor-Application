using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donor.Models;

namespace Donor.Controllers
{
    public class DonorController : Controller
    {
        DonorDAL donorDAL = new DonorDAL();
        public IActionResult Index()
        {
            List<DonorInfo> donorList = new List<DonorInfo>();
            donorList = donorDAL.GetAllDonors().ToList();
            return View(donorList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] DonorInfo objDonor)
        {
            if(ModelState.IsValid)
            {
                donorDAL.AddDonor(objDonor);
                return RedirectToAction("Index");
            }
            return View(objDonor);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DonorInfo donor = donorDAL.GetDonorByID(id);

            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind] DonorInfo objDonor)
        {
            if (id == null)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                donorDAL.UpdateDonor(objDonor);
                RedirectToAction("Donor");
            }
            return View(objDonor);
        }
    }
}
