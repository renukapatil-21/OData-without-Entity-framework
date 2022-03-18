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
            return db.GetStudent().ToList();
        }

        [HttpGet(nameof(GetById))]
        public IEnumerable<Student> GetById(int Id)
        {
            db.GetStudent().Where(model => model.Id == Id).FirstOrDefault();
            
            return default;
        }
       
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

        // PUT api/<EmpController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student obj)
        {
            if (ModelState.IsValid == true)
            {
                db.Edit(id, obj);
            }
        }

        // DELETE api/<EmpController>/5
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
