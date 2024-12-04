namespace DTO.Models
{
    public class DepartmentDTO
    {
        public string DepartmentName { get; set; }
        public int DepartmentNumber { get; set; }
        public DepartmentDTO()
        {

        }
        public DepartmentDTO(string departmentName, int departmentNumber)
        {
            this.DepartmentName = departmentName;
            this.DepartmentNumber = departmentNumber;
        }
    }
}
