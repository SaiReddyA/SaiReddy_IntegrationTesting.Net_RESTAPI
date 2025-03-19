namespace SaiReddy_IntegrationRestAPI
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Department { get; set; }
        public string? Position { get; set; }
    }
    public class Agent
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public string PhoneNumber { get; set; }
        public int LoginId { get; set; }
        public decimal AgentCommission { get; set; }
        public int CustomerCount { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }

}
