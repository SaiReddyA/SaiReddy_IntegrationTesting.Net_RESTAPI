namespace SaiReddy_IntegrationRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentRepo _agentRepository;

        public AgentController(IAgentRepo agentRepository)
        {
            _agentRepository = agentRepository;
        }

        [HttpGet("GetAllAgents")]
        public ActionResult GetAllAgents()
        {
            var agents = _agentRepository.GetAllAgents();
            return Ok(agents);
        }

        [HttpGet("GetAgentById/{id}")]
        public ActionResult GetAgentById(int id)
        {
            var agent = _agentRepository.GetAgentById(id);
            if (agent == null)
                return NotFound();

            return Ok(agent);
        }

        [HttpPost("AddAgent")]
        public IActionResult AddAgent([FromBody] Agent agent)
        {
            _agentRepository.AddAgent(agent);
            return CreatedAtAction(nameof(GetAgentById), new { id = agent.AgentId }, agent);
        }

        [HttpPut("UpdateAgent")]
        public IActionResult UpdateAgent([FromBody] Agent agent)
        {
            _agentRepository.UpdateAgent(agent);
            return NoContent();
        }

        [HttpDelete("DeleteAgent/{id}")]
        public IActionResult DeleteAgent(int id)
        {
            _agentRepository.DeleteAgent(id);
            return NoContent();
        }
    }
}
