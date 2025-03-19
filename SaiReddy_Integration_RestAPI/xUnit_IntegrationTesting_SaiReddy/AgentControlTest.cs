using Microsoft.AspNetCore.Mvc;
using Moq;
using SaiReddy_IntegrationRestAPI.Controllers;
using SaiReddy_IntegrationRestAPI.Repo;
using SaiReddy_IntegrationRestAPI;

namespace xUnit_IntegrationTesting_SaiReddy
{
    public class AgentControlTest
    {
        private readonly Mock<IAgentRepo> _mockRepo;
        private readonly AgentController _controller;

        public AgentControlTest()
        {
            _mockRepo = new Mock<IAgentRepo>();
            _controller = new AgentController(_mockRepo.Object);
        }

        [Fact]
        public void GetAllAgents_ShouldReturnAgentsList()
        {
            // Arrange
            var mockAgents = new List<Agent>
        {
            new Agent { AgentId = 1, AgentName = "Sai Reddy", PhoneNumber = "8978924981", LoginId = 1, AgentCommission = 40000, CustomerCount = 4, IsActive = true, CreatedBy = "sai@gmail.com", CreatedDate = DateTime.Now }
        };

            _mockRepo.Setup(repo => repo.GetAllAgents()).Returns(mockAgents);

            // Act
            var result = _controller.GetAllAgents() as OkObjectResult;
            var agents = result.Value as List<Agent>;

            // Assert
            Assert.NotNull(agents);
            Assert.Single(agents);
            Assert.Equal("Sai Reddy", agents[0].AgentName);
        }

        [Fact]
        public void GetAgentById_ShouldReturnAgent_WhenAgentExists()
        {
            // Arrange
            var mockAgent = new Agent { AgentId = 1, AgentName = "Sai Reddy", PhoneNumber = "8978924981", LoginId = 1, AgentCommission = 40000, CustomerCount = 4, IsActive = true, CreatedBy = "sai@gmail.com", CreatedDate = DateTime.Now };

            _mockRepo.Setup(repo => repo.GetAgentById(1)).Returns(mockAgent);

            // Act
            var result = _controller.GetAgentById(1) as OkObjectResult;
            var agent = result.Value as Agent;

            // Assert
            Assert.NotNull(agent);
            Assert.Equal(1, agent.AgentId);
        }

        [Fact]
        public void GetAgentById_ShouldReturnNotFound_WhenAgentDoesNotExist()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetAgentById(It.IsAny<int>())).Returns((Agent)null);

            // Act
            var result = _controller.GetAgentById(99);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
