using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doanqlchdt.DAO;
using Doanqlchdt.DTO;

namespace Doanqlchdt.BUS
{
    internal class nhanvienbus {
        private nhanviendao employeeDAO = new nhanviendao();
        public List<nhanviendto> GetNhanVien()
        {
            return employeeDAO.GetNhanVien();
        }

        public void AddEmployee(nhanviendto employee)
        {
            employeeDAO.AddEmployee(employee);
        }

        public void UpdateEmployee(nhanviendto employee)
        {
            employeeDAO.UpdateEmployee(employee);
        }

        public ArrayList SearchEmployeeByID(string keyword)
        {
            return employeeDAO.SearchEmployeeByID(keyword);
        }

        public ArrayList SearchEmployeeByName(string keyword)
        {
            return employeeDAO.SearchEmployeeByName(keyword);
        }
        public ArrayList SearchEmployeeByPhoneNumber(string keyword)
        {
            return employeeDAO.SearchEmployeeByPhoneNumber(keyword);
        }

        public List<string> LoadMaTK()
        {
            return employeeDAO.LoadMaTK();
        }

        public void ChangeStateHidden(nhanviendto employee)
        {
            employeeDAO.ChangeStateHidden(employee);
        }

        public void ChangeStateCurrent(nhanviendto employee)
        {
            employeeDAO.ChangeStateCurrent(employee);
        }
    }
}
