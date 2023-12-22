using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Web_Api_User_Management.Entities;

namespace Web_Api_User_Management.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> _users = new List<User>
        {
            new User { UserId = 1, UserName = "JohnDoe", UserAddress = "123 Main St", Age = 25, Job = "Developer" },
            new User { UserId = 2, UserName = "Brett", UserAddress = "456 Oak St", Age = 30, Job = "Designer" },
            // Add more initial users as needed
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _users.FirstOrDefault(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User newUser)
        {
            if (newUser == null)
            {
                return BadRequest("Invalid user data");
            }

            // Zorunlu alan kontrolü
            if (string.IsNullOrEmpty(newUser.UserName))
            {
                return BadRequest("UserName is required");
            }

            _users.Add(newUser);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User updatedUser)
        {
            var existingUser = _users.FirstOrDefault(u => u.UserId == id);

            if (existingUser == null)
            {
                return NotFound();
            }

            // Zorunlu alan kontrolü
            if (string.IsNullOrEmpty(updatedUser.UserName))
            {
                return BadRequest("UserName is required");
            }

            existingUser.UserName = updatedUser.UserName;
            existingUser.UserAddress = updatedUser.UserAddress;
            existingUser.Age = updatedUser.Age;
            existingUser.Job = updatedUser.Job;

            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] User updatedUser)
        {
            var existingUser = _users.FirstOrDefault(u => u.UserId == id);

            if (existingUser == null)
            {
                return NotFound();
            }

            // Zorunlu alan kontrolü
            if (!string.IsNullOrEmpty(updatedUser.UserName))
            {
                existingUser.UserName = updatedUser.UserName;
            }
            if (!string.IsNullOrEmpty(updatedUser.UserAddress))
            {
                existingUser.UserAddress = updatedUser.UserAddress;
            }
            if (updatedUser.Age > 0)
            {
                existingUser.Age = updatedUser.Age;
            }
            if (!string.IsNullOrEmpty(updatedUser.Job))
            {
                existingUser.Job = updatedUser.Job;
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            _users.Remove(user);

            return NoContent();
        }
    }
}
