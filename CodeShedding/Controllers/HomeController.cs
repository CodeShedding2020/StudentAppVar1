using CodeShedding.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CodeShedding.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        string EndpointUrl;
        private string PrimaryKey;
        private DocumentClient client;
        public HomeController()
        {
            EndpointUrl = "https://pitoriuniversity.documents.azure.com:443/";
            PrimaryKey = "wuD0m7z9Ys8HnhWsvdkUC4NDW1Dyb07uhO3EGMTlbjaJAxgMqnwmnpbFtXAfq8XDuloyaR4oArfaUQZH1Nmm4g==";
            client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
        }
     

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public async Task<ActionResult> Index(string searchString)
        {
            await client.CreateDatabaseIfNotExistsAsync(new Database { Id = "ToDoList" });

            await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("ToDoList"),
                new DocumentCollection { Id = "Items" });


            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };


            if (!String.IsNullOrEmpty(searchString))
            {

                IQueryable<Student> search = this.client.CreateDocumentQuery<Student>(
          UriFactory.CreateDocumentCollectionUri("ToDoList", "Items"), queryOptions)
          .Where(student => student.Student_Number.ToUpper().Contains(searchString.ToUpper())
               || student.First_Name.ToUpper().Contains(searchString.ToUpper()) || student.Last_Name.ToUpper().Contains(searchString.ToUpper()) && student.Status == true);
                return View(search);
            }


            return View(this.client.CreateDocumentQuery<Student>(
                    UriFactory.CreateDocumentCollectionUri("ToDoList", "Items"), queryOptions)
                    .Where(f => f.Status == true));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Student student)
        {

            await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri("ToDoList", "Items"), student);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(string id)
        {
            await this.client.DeleteDocumentAsync(UriFactory.CreateDocumentUri("ToDoList", "Items", id));
            return RedirectToAction("Index");
        }
    }
}