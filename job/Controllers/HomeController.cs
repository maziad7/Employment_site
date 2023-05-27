using job.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace job.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());

        }
        [Authorize]
        public ActionResult GetJobsByUser()
        {
            var UserId = User.Identity.GetUserId();
            var Jobs = db.ApplyForJobs.Where(a => a.UserId == UserId);
            return View(Jobs.ToList());
        }
        [Authorize]
        public ActionResult DetailsOfJob(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }
        public ActionResult Details(int JobId)
        {
            var job = db.Jobs.Find(JobId);
            if (job==null)
            {
                return HttpNotFound();
            }
            Session["JobId"] = JobId;
            return View(job);
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            var role = db.ApplyForJobs.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(ApplyForJob job)
        {

            // TODO: Add update logic here

            if (ModelState.IsValid)
            {
                job.ApplyDate = DateTime.Now;
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetJobsByUser");
            }
            return View(job);

        }
        public ActionResult Delete(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(ApplyForJob role)
        {
            try
            {
                // TODO: Add delete logic here
                var myRole = db.ApplyForJobs.Find(role.Id);
                db.ApplyForJobs.Remove(myRole);
                db.SaveChanges();
                return RedirectToAction("GetJobByUser");
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        public ActionResult GetJobsByPublisher()
        {
            var UserID = User.Identity.GetUserId();
            var Job = from app in db.ApplyForJobs
                      join job in db.Jobs
                      on app.JobId equals job.Id
                      where job.User.Id==UserID
                      select app;
            var grouped = from j in Job
                          group j by j.job.JobTitle
                        into gr
                          select new JobsViewModels
                          {
                              JobTitle = gr.Key,
                              Items = gr
                          };
            return View(grouped.ToList());
        }
        public ActionResult About()
        {
            ViewBag.Message = "وصف عام حول الموقع ";

            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Messagecontact = "تم عملية الاتصال بنجاح";
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContectModel contact)
        {
            var mail = new MailMessage();
            var loginInfo = new NetworkCredential("joboffers748@gmail.com", "7410190mk");
            mail.From = new MailAddress(contact.Email);
            mail.To.Add(new MailAddress("joboffers748@gmail.com"));
            mail.Subject = contact.Subject;
            mail.IsBodyHtml = true;
            var body = "اسم المرسل :" + contact.Name + "<br>" +
                "بريد المرسل :" + contact.Email + "<br>" +
                "عنوان الرسالة :" + contact.Subject + "<br>" +
                "نص الرسالة :<b>" + contact.Message + "</b>";
            mail.Body = body;

            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(mail);
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Apply(string Message)
        {
            var UserId = User.Identity.GetUserId();
            var JobId = (int)Session["JobId"];
            var check = db.ApplyForJobs.Where(a => a.JobId == JobId && a.UserId == UserId).ToList();
            if (check.Count<1)
            {
                var job = new ApplyForJob();
                job.JobId = JobId;
                job.UserId = UserId;
                job.Message = Message;
                job.ApplyDate = DateTime.Now;
                db.ApplyForJobs.Add(job);
                db.SaveChanges();
                ViewBag.Result = "تمت اضافة بنجاح !";
            }
            else
            {
                ViewBag.Result = "المعذرة لقد سبق وتقدمت الى نفس الوظيفة!";
            }
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string searchName)
        {
            var result = db.Jobs.Where(a => a.JobTitle.Contains(searchName) 
            ||a.JobContent.Contains(searchName)
            ||a.Category.CategoryName.Contains(searchName)
            ||a.Category.CategoryDescription.Contains(searchName)
            ).ToList();
            return View(result);

        }

        public ActionResult Call_us()
        {
            return View();
        }
    }
}