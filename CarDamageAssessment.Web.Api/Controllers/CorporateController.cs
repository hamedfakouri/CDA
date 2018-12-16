using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarDamageAssessment.ApplicationCore.Entities;
using CarDamageAssessment.ApplicationCore.Interfaces.Repositories;
using CarDamageAssessment.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDamageAssessment.Web.Api.Controllers
{
  [Produces("application/json")]
  [Route("api/corporates")]
  [Authorize(Roles = "member")]

    public class CorporateController : Controller
  {

    private readonly ICorporateRepository _carRepository;

    private IAuthorizationService _authorization;
    public CorporateController(ICorporateRepository carRepository, IAuthorizationService authorizationService)
    {

      _carRepository = carRepository;
      _authorization = authorizationService;
    }

    // GET: api/Car
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
      //var allowed = await _authorization.AuthorizeAsync(User, "userRole");
      var identity = User.Identity as ClaimsIdentity;
      return Ok();

    }

    // GET: api/Car/5
    [HttpGet("{id}", Name = "Get")]
    public IActionResult Get(int id)
    {
     // var item = _carRepository.GetById(id);
      return Ok();
           
    }

    // POST: api/Car
    [HttpPost]
    public IActionResult Post([FromBody]Corporate value)
    {

      var corporate = new Corporate();
      corporate.Name = "asd";
      corporate.OwnerId = 1;
     
      _carRepository.Add(corporate);
      return Ok(corporate);
    }


        // PUT: api/Car/5
        [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]object value)
    {


      if (ModelState.IsValid == false)
        return BadRequest("");

      var item = _carRepository.GetById(id);

      if (item == null)
        return NotFound();

      //item.Name = value.Name;
       
      return Ok();

    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {

    }
  }
}
