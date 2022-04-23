using System.Data;

namespace DotNet_Design_Patterns_Vol2.Chapter_03.TableModule
{
    public class DbManager
    {
        protected DataTable dt;
        protected DbManager(DataSet ds, string tableName) => dt = ds.Tables[tableName];
    }
    public class RollCall : DbManager
    {
        public RollCall(DataSet ds) : base(ds, "rollcalls") { }
        public double GetWorkingHoursSummary(int employeeId)
        {
            if (employeeId == 1) return 100;
            else throw new ArgumentException("کارمند یافت نشد");
        }
    }
    public class Employee : DbManager
    {
        public Employee(DataSet ds) : base(ds, "employees") { }

        public DataRow this[int employeeId] => dt.Select($"Id = {employeeId}")[0];

        public double CalculateWorkingHours(int employeeId)
        {
            var employee = this[employeeId];
            var workingHours = new RollCall(dt.DataSet).GetWorkingHoursSummary(employeeId);
            if (employee["Position"] == "CEO")
                workingHours *= 1.2;
            return workingHours;
        }
    }
}
