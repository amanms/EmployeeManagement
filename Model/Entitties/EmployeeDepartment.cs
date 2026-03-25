namespace EmployeeManagement.Model.Entitties
{
    public class EmployeeDepartment
    {
        public int EmployeeDepartmentId { get; set; }
        public int? EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
        public bool IsDeleted { get; set; } 

        public Employee Employee { get; set; }  
        public Department Department { get; set; }

    }
}
