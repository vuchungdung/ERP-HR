using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Recruitment.Interface;
using Services.Recruitment.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Recruitment.Controllers
{
    [ApiController]
    [Route("/api/recruitment/employee")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("insert")]
        [Authorize]
        public async Task<ResponseModel> Insert([FromForm] EmployeeViewModel model)
        {
            var response = await _employeeService.Insert(model);
            return response;
        }

        [Route("get-list")]
        [HttpPost]
        [Authorize]
        public async Task<ResponseModel> GetList([FromBody] FilterModel model)
        {
            var response = await _employeeService.GetList(model);
            return response;
        }

        [Route("update")]
        [HttpPut]
        [Authorize]
        public async Task<ResponseModel> Update([FromForm] EmployeeViewModel model)
        {
            var response = await _employeeService.Update(model);
            return response;
        }

        [Route("delete")]
        [HttpDelete]
        [Authorize]
        public async Task<ResponseModel> Delete([FromQuery] int id)
        {
            var response = await _employeeService.Delete(id);
            return response;
        }

        [Route("item")]
        [HttpGet]
        [Authorize]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _employeeService.Item(id);
            return response;
        }
    }
}
