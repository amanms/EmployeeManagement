namespace EmployeeManagement.Model.Entitties
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } 

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Deleted { get; set; } = 0;

        public ICollection<EmployeeRole> EmployeeRoles { get; set; } = new List<EmployeeRole>();

    }
}
