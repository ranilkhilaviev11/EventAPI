
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using EventAPI.Models;
using EventAPI.Repository;

namespace EventAPI.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly ParticipantRepository participantRepository;
        public ParticipantController(IConfiguration configuration)
        {
            participantRepository = new ParticipantRepository(configuration);
        }
        public IActionResult Index()
        {
            return View(participantRepository.FindAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        // POST: Participant/Create
        [HttpPost]
        public IActionResult Create(Participant cust)
        {
            if (ModelState.IsValid)
            {
                participantRepository.Add(cust);
                return RedirectToAction("Index");
            }
            return View(cust);

        }

        // GET: /Participant/Edit/1
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Participant obj = participantRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        // POST: /Participant/Edit   
        [HttpPost]
        public IActionResult Edit(Participant obj)
        {

            if (ModelState.IsValid)
            {
                participantRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET:/Participant/Delete/1
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            participantRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}