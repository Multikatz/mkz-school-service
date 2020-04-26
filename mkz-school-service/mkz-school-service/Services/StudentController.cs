using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mkz_school_service.Models;
using mkz_school_service.Models.Communication;

namespace mkz_school_service.Services
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        public JsonResult GetAll()
        {
            List<SC_STUDENT> students = DataAccess.StudentAccess.GetAll();

            return new JsonResult(students);
        }

        public JsonResult CreateOrUpdate(SC_STUDENT student)
        {
            ResponseBase responseBase = DataAccess.StudentAccess.CreateOrUpdate(student);

            return new JsonResult(responseBase);
        }
    }
}