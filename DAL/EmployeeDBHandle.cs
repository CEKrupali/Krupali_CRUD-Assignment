using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Krupali_CRUD_Assignment.Models;

namespace Krupali_CRUD_Assignment.DAL
{
    public class EmployeeDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["Conn"].ToString();
            con = new SqlConnection(constring);
        }

        #region Employee

        #region Add Employee
        // **************** ADD NEW EMPLOYEE *********************
        public int AddEmployee(Employee smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("SP_CRUDEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", smodel.Name);
            cmd.Parameters.AddWithValue("@Email", smodel.Email);
            cmd.Parameters.AddWithValue("@Designation", smodel.Designation);
            cmd.Parameters.AddWithValue("@Type", "I");

            con.Open();
            int id = 0;

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    id = (int)rdr["id"];
                }
            }

            con.Close();
            return id;
            //if (id >= 1)
            //    return true;
            //else
            //    return false;
        }
        #endregion

        #region View Employee
        // ********** VIEW EMPLOYEE DETAILS ********************
        public List<Employee> GetEmployee()
        {
            connection();
            List<Employee> employeeList = new List<Employee>();

            SqlCommand cmd = new SqlCommand("SP_CRUDEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Type", "S");

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                employeeList.Add(
                    new Employee
                    {
                        EmpId = Convert.ToInt32(dr["EmpId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Email = Convert.ToString(dr["Email"]),
                        Designation = Convert.ToString(dr["Designation"])
                    });
            }
            return employeeList;
        }
        #endregion

        #region View Employee by Id
        // ********** VIEW EMPLOYEE DETAILS ********************
        public List<Employee> GetEmployeeById(int EmpId)
        {
            connection();
            List<Employee> employeeList = new List<Employee>();

            SqlCommand cmd = new SqlCommand("SP_CRUDEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", EmpId);
            cmd.Parameters.AddWithValue("@Type", "E");

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                employeeList.Add(
                    new Employee
                    {
                        EmpId = Convert.ToInt32(dr["EmpId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Email = Convert.ToString(dr["Email"]),
                        Designation = Convert.ToString(dr["Designation"])
                    });
            }
            return employeeList;
        }
        #endregion

        #region Update Employee
        // ***************** UPDATE Employee DETAILS *********************
        public bool UpdateEmployee(Employee smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("SP_CRUDEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpId", smodel.EmpId);
            cmd.Parameters.AddWithValue("@Name", smodel.Name);
            cmd.Parameters.AddWithValue("@Email", smodel.Email);
            cmd.Parameters.AddWithValue("@Designation", smodel.Designation);
            cmd.Parameters.AddWithValue("@Type", "U");

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        #endregion

        #region Delete Employee
        // ********************** DELETE Employee *******************
        public bool DeleteEmployee(int EmpId)
        {
            connection();
            SqlCommand cmd = new SqlCommand("SP_CRUDEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpId", EmpId);
            cmd.Parameters.AddWithValue("@Type", "D");

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        #endregion

        #endregion


        #region Employee Detail
        #region Add Employee
        // **************** ADD NEW EMPLOYEEDtl *********************
        public bool AddEmployeeDtl(List<EmployeeDetial> model)
        {
            connection();

            foreach (var data in model)
            {
                SqlCommand cmd = new SqlCommand("SP_CRUDEmployeeDtl", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", data.EmpId);
                cmd.Parameters.AddWithValue("@FileName", data.FileName);
                cmd.Parameters.AddWithValue("@FilePath", data.FilePath);
                cmd.Parameters.AddWithValue("@Type", "I");

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                    return true;
                else
                    return false;
            }
            return true;
        }
        #endregion

        #region View Employee
        // ********** VIEW EMPLOYEE DETAILS ********************
        public List<EmployeeDetial> GetEmployeeDtl(int EmpId)
        {
            connection();
            List<EmployeeDetial> employeeList = new List<EmployeeDetial>();

            SqlCommand cmd = new SqlCommand("SP_CRUDEmployeeDtl", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", EmpId);
            cmd.Parameters.AddWithValue("@Type", "E");

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                employeeList.Add(
                    new EmployeeDetial
                    {
                        EmpDtlId = Convert.ToInt32(dr["EmpDtlId"]),
                        EmpId = Convert.ToInt32(dr["EmpId"]),
                        FileName = Convert.ToString(dr["FileName"]),
                        FilePath = Convert.ToString(dr["FilePath"])
                    });
            }
            return employeeList;
        }
        #endregion

        #region Add Employee
        // **************** UPDATE EMPLOYEEDtl *********************
        public bool UpdateEmployeeDtl(List<EmployeeDetial> model)
        {
            connection();

            foreach (var data in model)
            {
                SqlCommand cmd = new SqlCommand("SP_CRUDEmployeeDtl", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", data.EmpId);
                cmd.Parameters.AddWithValue("@FileName", data.FileName);
                cmd.Parameters.AddWithValue("@FilePath", data.FilePath);
                cmd.Parameters.AddWithValue("@Type", "U");

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                    return true;
                else
                    return false;
            }
            return true;
        }
        #endregion

        #region Delete Employee
        // ********************** DELETE Employee Details *******************
        public bool DeleteEmployeeDtl(int EmpDtlId)
        {
            connection();
            SqlCommand cmd = new SqlCommand("SP_CRUDEmployeeDtl", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpDtlId", EmpDtlId);
            cmd.Parameters.AddWithValue("@Type", "D");

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        #endregion

        #region Delete Employee
        // ********************** DELETE Employee Details *******************
        public bool DeleteEmployeeDtlbyEmpId(int EmpId)
        {
            connection();
            SqlCommand cmd = new SqlCommand("SP_CRUDEmployeeDtl", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpId", EmpId);
            cmd.Parameters.AddWithValue("@Type", "C");

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        #endregion

        #endregion
    }
}