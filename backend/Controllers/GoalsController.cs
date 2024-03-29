﻿using backend.DTO;
using backend.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoalsController : Controller
    {
        private readonly IGoalsRepository _goalRepository;
        private readonly IUserRepository _userRepository;
        public GoalsController(
            IGoalsRepository goalRepository,
            IUserRepository userRepository)
        {
            _goalRepository = goalRepository;
            _userRepository = userRepository;
        }
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            string token = Request.Headers["Authorization"].ToString();
            var user = _userRepository.GetUserEmailByToken(token);

            var result = await _goalRepository.GetAllGoals(user.Id);

            return Ok(result);
        }

        [HttpGet]
        [Route("goals/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _goalRepository.GetGoalById(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] GoalsDTO goal)
        {
            var result = await _goalRepository.CreateGoal(goal);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        //[HttpPut]
        //[Route("modify/{id}")]
        //public IActionResult ModifyById([FromBody])
        //{

        //}

        //[HttpDelete]
        //[Route("delete/{id}")]
        //public IActionResult DeleteById([FromBody])
        //{

        //}

    }
}
