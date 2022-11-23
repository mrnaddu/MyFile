namespace EmployeeApi.Models
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public string Email { get; set;}

        public long Salary { get; set; }

        public long phone { set; get; }

        public string department { set; get; }
    }
}
