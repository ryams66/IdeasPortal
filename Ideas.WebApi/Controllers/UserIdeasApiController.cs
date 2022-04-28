using Ideas.WebApi.Models;
using Ideas.WebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ideas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserIdeasApiController : ControllerBase
    {
        IRepository ideaRepository;
        public UserIdeasApiController(IRepository _ideaRepository)
        {
            ideaRepository = _ideaRepository;
        }
        [HttpGet]
        [Route("GetIdeasByDate")]
        public async Task<IActionResult> GetIdeasByDate()
        {
            try
            {
                var ideas = await ideaRepository.GetIdeasByDate();
                if (ideas == null)
                {
                    return NotFound();
                }

                return Ok(ideas);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetIdeasByLikes")]
        public async Task<IActionResult> GetIdeasByLikes()
        {
            try
            {
                var ideas = await ideaRepository.GetIdeasBylikes();
                if (ideas == null)
                {
                    return NotFound();
                }

                return Ok(ideas);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("AddIdea")]
        public async Task<IActionResult> AddIdea([FromBody] IdeaBox ideaModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ideaId = await ideaRepository.AddIdea(ideaModel);
                    if (ideaId > 0)
                    {
                        return Ok(ideaId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] Userdetail userModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = await ideaRepository.AddUser(userModel);
                    if (userId > 0)
                    {
                        return Ok(userId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpGet]
        [Route("GetIdea")]
        public async Task<IActionResult> GetIdea(int? ideaId)
        {
            if (ideaId == null)
            {
                return BadRequest();
            }

            try
            {
                var idea = await ideaRepository.GetIdeaDetail(ideaId);

                if (idea == null)
                {
                    return NotFound();
                }

                return Ok(idea);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateIdea/{ideaid:int}")]
        public async Task<IActionResult> UpdateIdea(int? ideaid, [FromBody] IdeaBox idea)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ideaid != idea.IdeaId)
                    {
                        return BadRequest();

                    }
                    await ideaRepository.UpdateIdea(ideaid, idea);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
        [HttpPut("UpdateIdeaLikes/{ideaid:int}")]

        public async Task<IActionResult> UpdateIdeaLikes(int? ideaid, [FromBody] IdeaBox idea)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ideaid != null && ideaid != idea.IdeaId)
                    {
                        return BadRequest();

                    }
                    await ideaRepository.UpdateIdeaLikes(ideaid, idea);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpDelete("DeleteIdea/{ideaId:int}")]

        public async Task<IActionResult> DeleteIdea(int? ideaId)
        {
            int result = 0;

            if (ideaId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await ideaRepository.DeleteIdea(ideaId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}
