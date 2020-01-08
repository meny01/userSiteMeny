using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSite.Models;
using UserSite.Services;

namespace UserSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersService _service;
        public HomeController(IUsersService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var model = _service.GetUsers();
            return View(model);
        }
        /// <summary>
        /// update - get user 
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>PartialView</returns>
        public IActionResult Update(int id)
        {
            if(id == 0)
                return PartialView(); //for add

            var model = _service.GetForEdit(id.ToString());
            return PartialView(model); //for edit
        }

        /// <summary>
        /// update - edit or add users
        /// </summary>
        /// <returns>Redirect</returns>
        [HttpPost]
        public IActionResult Update(UsersViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             _service.Update(model);

            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// Delete - delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _service.DeleteUser(id.ToString());
            return Json("Success");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
