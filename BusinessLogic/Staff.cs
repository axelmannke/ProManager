using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mk.DBConnector;

namespace BusinessLogic
{
    public class Staff
    {
        public long IdStaff;
        public Department Department;
        public string Name;
        public string Surname;

        public Staff(long IdStaff, long IdDepartment, string Surname, string Name)
        {
            this.IdStaff = IdStaff;
            this.Name = Name;
            this.Surname = Surname;

            this.Department = new Department(IdDepartment);
        }

        public Staff(DataRow row)
        {
            this.IdStaff = long.Parse(row[0].ToString());
            this.Name = row[2].ToString();
            this.Surname = row[3].ToString();

            this.Department = new BusinessLogic.Department(long.Parse(row[1].ToString()));
        }

        public override string ToString()
        {
            return this.Surname + ", " + this.Name;
        }
    }
}
