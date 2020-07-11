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
            EndpointUrl = "https://tast-students.documents.azure.com:443/";
            PrimaryKey = "KsqEnYnub6c1G9aMOhJ5W3o8UY5cMUY1GjkMoUWZ7uQsHeoscMFiJZ4JudHTQDqx9PxEBWoKGzIXnJSLlD1SsA==";
            client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
        }
        public ActionResult Index()
        {
            return View();
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
        public async Task<ActionResult> Student()
        {
            await client.CreateDatabaseIfNotExistsAsync(new Database { Id = "STDAMIN" });

            await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("STDAMIN"),
                new DocumentCollection { Id = "StudentsCollection" });


            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };


            IQueryable<Student> studentQuery = this.client.CreateDocumentQuery<Student>(
                    UriFactory.CreateDocumentCollectionUri("STDAMIN", "StudentsCollection"), queryOptions)
                    .Where(f => f.Status == true);

            return View(studentQuery);
        }

        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent(Student student)
        {

            await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri("STDAMIN", "StudentsCollection"), student);

            return RedirectToAction("Student");
        }

        public async Task<ActionResult> DeleteStudent(string documentId)
        {
            await this.client.DeleteDocumentAsync(UriFactory.CreateDocumentUri("STDAMIN", "StudentsCollection", documentId));
            return RedirectToAction("Student");
        }
    }
}