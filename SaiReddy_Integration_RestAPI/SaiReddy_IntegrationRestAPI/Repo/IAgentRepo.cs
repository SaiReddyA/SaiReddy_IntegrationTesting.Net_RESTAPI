namespace SaiReddy_IntegrationRestAPI.Repo
{
    public interface IAgentRepo
    {
        List<Agent> GetAllAgents();
        Agent GetAgentById(int agentId);
        void AddAgent(Agent agent);
        void UpdateAgent(Agent agent);
        void DeleteAgent(int agentId);
    }
}
