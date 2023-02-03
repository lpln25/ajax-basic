using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        public static List<Person> dataBase = new List<Person>();
        public PersonController()
        {
            if (dataBase.Count == 0)
            {
                dataBase.Add(new Person { Name = "Ali", Family = "Hoseini", Age = 22 });
                dataBase.Add(new Person { Name = "Mohsen", Family = "Alavi", Age = 14 });
                dataBase.Add(new Person { Name = "Shiva", Family = "Sotodeh", Age = 25 });
            }
        }

        [HttpGet]
        public Person Get()
        {
            return dataBase[0];
        }

        [HttpGet("GetAll")]
        public IEnumerable<Person> GetAllData()
        {
            return dataBase;
        }


        [HttpPost("Create")]
        public string Create(IFormCollection formcollection)
        {
            Person person = new Person();
            person.Name = formcollection["name"];
            person.Family = formcollection["family"];
            person.Age = int.Parse(formcollection["age"]);

            dataBase.Add(person);
            return "successfully add";
        }


        [HttpDelete("DeletePerson")]
        public JsonResult DeletePerson(IFormCollection formcollection)
        {
            string name = formcollection["name"];
            Person p = dataBase.Where(x => x.Name == name).FirstOrDefault();
            if (p != null)
                dataBase.Remove(p);

            return Json(p);
        }

    }
}
