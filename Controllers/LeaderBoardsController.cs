using LeaderBoards.Data;
using LeaderBoards.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace LeaderBoards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderBoardsController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();

        [HttpGet]
        public IEnumerable<Leader> Get()
        {
            return _dbContext.Leaders;
        }


        [HttpGet("{id}")]
        public ActionResult<Leader> Get(int id)
        {
            Leader? _leader = _dbContext.Leaders.FirstOrDefault(lead => lead.Id == id);

            if (_leader == null)
            {
                return NotFound();
            }

            return _leader;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Leader leader)
        {
            _dbContext.Leaders.Add(leader);
            _dbContext.SaveChanges();

            return Created("/api/leaderboards", leader);
        }

        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] Leader leaderObj)
        {
            Leader? leader = _dbContext.Leaders.FirstOrDefault<Leader>(lead => lead.Id == id);

            if (leader == null)
            {
                return NotFound();
            }

            leader.Name = leaderObj.Name;
            leader.Points = leaderObj.Points;
            leader.Email = leaderObj.Email;
            leader.Description = leaderObj.Description;

            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Leader? leader = _dbContext.Leaders.FirstOrDefault<Leader>(lead => lead.Id == id);

            if (leader == null)
            {
                return NotFound();
            }

            _dbContext.Leaders.Remove(leader);
            _dbContext.SaveChanges();

            return Accepted();
        }
    }
}
