using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using construction.Models;
using construction.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace contractor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsService _cs;
        public ContractorsController(ContractorsService cs)
        {
            _cs = cs;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Contractor>> Get()
        {
            try
            {
                var contract = _cs.Get();
                return Ok(contract);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Contractor> Get(int id)
        {
            try
            {
                var contract = _cs.Get(id);
                return Ok(contract);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Contractor>> Create([FromBody] Contractor newContractor)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                newContractor.CreatorId = userInfo.Id;
                Contractor contractor = _cs.Create(newContractor);
                return Ok(contractor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Contractor>> Remove(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _cs.Remove(id, userInfo.Id);
                return Ok("Deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}