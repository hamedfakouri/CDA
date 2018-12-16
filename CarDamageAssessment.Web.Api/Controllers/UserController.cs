using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDamageAssessment.ApplicationCore.Entities;
using CarDamageAssessment.ApplicationCore.Interfaces.Repositories;
using CarDamageAssessment.Infrastructure.Data.Repositories;
using CarDamageAssessment.Web.Api.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDamageAssessment.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    [Authorize(Roles = "member")]

    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository; 
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {

            return null;
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserCreateViewModel value)
        {


           
           
            var user = new User();

          
            long userId;
            long.TryParse(value.sub, out userId);
            var existedUser = _userRepository.GetById(userId);
           
            user.Id = userId;
            user.Email = value.given_name;


            _userRepository.Add(user);
            return Ok(user);
        }

    }
}