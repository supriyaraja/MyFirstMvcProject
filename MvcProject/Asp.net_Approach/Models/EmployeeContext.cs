using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Asp.net_Approach.Models
{
    public class EmployeeContext
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        public List<EmployeeModel> GetEmployeeDetails()
        {
            SqlCommand cmd = new SqlCommand("sp_GetEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<EmployeeModel> list = new List<EmployeeModel>();
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeModel emp = new EmployeeModel();
                emp.EmpId = Convert.ToInt32(dr[0]);
                emp.EmpName = Convert.ToString(dr[1]);
                emp.EmpSalary = Convert.ToInt32(dr[2]);
                list.Add(emp);
            }
            return list;
        }
        public int saveEmployeeDetails(EmployeeModel obj)
        {
            SqlCommand cmd = new SqlCommand("sp_SaveEmployeeDetails_Warriors", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@EmpName",obj.EmpName );
            cmd.Parameters.AddWithValue("@EmpSalary", obj.EmpSalary);
            object i = cmd.ExecuteScalar();
            int result = Convert.ToInt32(i);
            con.Close();
            return result;
        }
        public EmployeeModel GetEmployeeDetailsById(int? id)
        {
            SqlCommand cmd = new SqlCommand("sp_GetEmployeeById_Warriors", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            EmployeeModel emp = new EmployeeModel();
            foreach (DataRow dr in dt.Rows)
            {
                emp.EmpId = Convert.ToInt32(dr[0]);
                emp.EmpName = Convert.ToString(dr[1]);
                emp.EmpSalary = Convert.ToInt32(dr[2]);
            }
            return emp;
        }
        public int UpdateEmployeeDetailsById(EmployeeModel obj)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateEmployeeDetails_Warriors", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@EmpId", obj.EmpId);
            cmd.Parameters.AddWithValue("@EmpName", obj.EmpName);
            cmd.Parameters.AddWithValue("@EmpSalary", obj.EmpSalary);
            object i = cmd.ExecuteNonQuery();
            int result = Convert.ToInt32(i);
            con.Close();
            return result;
        }
        public int DeleteEmployeeDetailsById(int? id)
        {
            SqlCommand cmd = new SqlCommand("sp_DeleteEmployeeById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@EmpId", id);
            object i = cmd.ExecuteNonQuery();
            int result = Convert.ToInt32(i);
            con.Close();
            return result;
        }        
    }
}