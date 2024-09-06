namespace Backend_Developer_test.DTOs
{
    public class EmployeeDTO
    {
        public int EmpNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public DateTime HireDate { get; set; }
        public float Salary { get; set; }
        public float? Comm { get; set; }
        public int DeptNo { get; set; }
    }
}
