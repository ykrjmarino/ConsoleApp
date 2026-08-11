namespace EmployeeProject.Employee
{
    public class Get
    {
        public List<Employee> All()
        {
            using var db = new AppDb();
            return db.Employees.ToList();
        }
    }
}