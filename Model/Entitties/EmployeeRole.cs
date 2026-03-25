namespace EmployeeManagement.Model.Entitties
{
    public class EmployeeRole
    {
        public int EmployeeRoleId { get; set; }
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
        public int Deleted { get; set; } = 0;

        public Employee Employee { get; set; }
        public Role Role { get; set; }
    }
}
