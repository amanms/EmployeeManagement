namespace EmployeeManagement.Model.Entitties
{
    public class Role
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; } 

        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
        public bool IsDeleted { get; set; } 

        public ICollection<EmployeeRole> EmployeeRoles { get; set; } = new List<EmployeeRole>();

    }
}
