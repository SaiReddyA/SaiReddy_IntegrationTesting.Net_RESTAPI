namespace SaiReddy_IntegrationRestAPI.Repo
{
    public class AgentRepository : IAgentRepo
    {
        private readonly string _connectionString;

        public AgentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Agent> GetAllAgents()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Agent>("SELECT * FROM Agents").ToList();
            }
        }

        public Agent GetAgentById(int agentId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.QueryFirstOrDefault<Agent>("SELECT * FROM Agents WHERE AgentId = @AgentId", new { AgentId = agentId });
            }
        }

        public void AddAgent(Agent agent)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO Agents (AgentName, PhoneNumber, LoginId, AgentCommission, CustomerCount, IsActive, CreatedBy, CreatedDate, ModifiedBy)
                           VALUES (@AgentName, @PhoneNumber, @LoginId, @AgentCommission, @CustomerCount, @IsActive, @CreatedBy, @CreatedDate, @ModifiedBy)";
                db.Execute(sql, agent);
            }
        }

        public void UpdateAgent(Agent agent)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Agents SET 
                            AgentName = @AgentName, 
                            PhoneNumber = @PhoneNumber, 
                            LoginId = @LoginId, 
                            AgentCommission = @AgentCommission, 
                            CustomerCount = @CustomerCount, 
                            IsActive = @IsActive, 
                            ModifiedBy = @ModifiedBy 
                           WHERE AgentId = @AgentId";
                db.Execute(sql, agent);
            }
        }

        public void DeleteAgent(int agentId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute("DELETE FROM Agents WHERE AgentId = @AgentId", new { AgentId = agentId });
            }
        }
    }
}
