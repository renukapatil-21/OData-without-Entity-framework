using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataWithoutEF.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ODataWithoutEF.Controllers
{ 
    public class StudentsController : ODataController
    {
        ContextDb db = new ContextDb();

        [EnableQuery]
        
        public IEnumerable<Student> Get()
        {
            return db.GetStudent();
        }

        [EnableQuery]
        [HttpGet(nameof(GetById))]
        public IEnumerable<Student> GetById(int Id)
        {
            var result = db.GetStudent().Where(model => model.Id == Id);
            
            return result;
        }

        [EnableQuery]
        public void Post([FromBody] Student obj)
        {
            if (ModelState.IsValid == true)
            {
                db.Add(obj);
            }
            else
            {

            }
        }

        [EnableQuery]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student obj)
        {
            if (ModelState.IsValid == true)
            {
                db.Edit(id, obj);
            }
        }

        [EnableQuery]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (ModelState.IsValid == true)
            {
                db.DeleteStudent(id);
            }
        }

    }
}
