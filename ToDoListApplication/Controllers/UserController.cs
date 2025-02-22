using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ToDoListApplication.Data;
using ToDoListApplication.Models;
using ToDoListApplication.ViewModels;

namespace ToDoListApplication.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();

        [HttpGet]   
        public IActionResult Loging()
        {
            return View();
        }
      
        [HttpPost]
        public IActionResult Index(string userName)
        {
            var user = dbContext.Users.First(u => u.Name == userName);
            var lists = dbContext.MyLists.Where(l => l.UserId == user.Id);
            ViewData["User"] = user;
            return View(lists.ToList());
        }
        [HttpGet]
        public IActionResult Create(int id)  
        {
            var user = dbContext.Users.First(u => u.Id == id);

            return View(user);
        }
        [HttpPost]
        public IActionResult Create(ListFromUser list)
        {
            var user = dbContext.Users.Where(u => u.Id == list.UserId).First();

            var newList = new MyList();
            DateTime dateTime = list.DeadlineDate.ToDateTime(list.DeadlineTime); 
            if(list is not null)
            {
                newList.Title = list.Title;
                newList.Description = list.Description;
                newList.Deadline = dateTime;
                newList.UserId = list.UserId;
                dbContext.Add(newList);
                dbContext.SaveChanges();
                return RedirectToAction("Loging");
            }
            else
            {
                return View("NotFound");
            }
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {

            var list = dbContext.MyLists.Include(u=>u.User).FirstOrDefault(i=>i.Id == id);
            if (list != null) 
            { 
                return View(list);
            }
            else
            {
                return View("NotFound");
            }
        }
        [HttpPost]
        public IActionResult Edit(MyList list,int UserId , int Id) 
        {
            var listDb = dbContext.MyLists.FirstOrDefault(l=>l.Id == Id);
            if (listDb != null) 
            {
                listDb.Title = list.Title;
                listDb.Description = list.Description;
                listDb.UserId = UserId;
                listDb.Deadline = list.Deadline;
            }
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Loging));
        }
        public IActionResult Delete(int Id)
        {
            var listDb = dbContext.MyLists.FirstOrDefault(e => e.Id == Id);

            if (listDb != null)
            {
                dbContext.MyLists.Remove(listDb);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Loging));
            }
            else 
            { 
            return RedirectToAction("NotFoundPage", "Home");

            }

        }
    }
}
