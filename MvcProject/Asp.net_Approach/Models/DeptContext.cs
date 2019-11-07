using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Asp.net_Approach.Models
{
    public class DeptContext
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

        public List<DeptModel> GetDept()
        {
            SqlCommand cmd = new SqlCommand("sp_GetDept", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<DeptModel> list = new List<DeptModel>();
            foreach(DataRow dr in dt.Rows)
            {
                DeptModel dept = new DeptModel();
                dept.DeptId = Convert.ToInt32(dr[0]);
                dept.DeptCode = dr[1].ToString();
                dept.DeptName = dr[2].ToString();
                dept.Location = dr[3].ToString();
                list.Add(dept);
            }
            return list;
        }
        public int SaveDeptDetails(DeptModel dept)
        {
            SqlCommand cmd = new SqlCommand("sp_SaveDept", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@DeptCode", dept.DeptCode);
            cmd.Parameters.AddWithValue("@DeptName", dept.DeptName);
            cmd.Parameters.AddWithValue("@Location", dept.Location);
            object i = cmd.ExecuteScalar();
            int result = Convert.ToInt32(i);
            con.Close();
            return result;
        }
        public DeptModel GetDeptDetailsById(int? Id)
        {
            SqlCommand cmd = new SqlCommand("sp_GetDeptById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DeptId", Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DeptModel dept = new DeptModel();
            foreach (DataRow dr in dt.Rows)
            {
                dept.DeptId = Convert.ToInt32(dr[0]);
                dept.DeptCode = dr[1].ToString();
                dept.DeptName = dr[2].ToString();
                dept.Location = dr[3].ToString();
            }
            return dept;
        }
        public int UpdateDeptDetails(DeptModel dept)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateDept", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@DeptId", dept.DeptId);
            cmd.Parameters.AddWithValue("@DeptCode", dept.DeptCode);
            cmd.Parameters.AddWithValue("@DeptName", dept.DeptName);
            cmd.Parameters.AddWithValue("@Location", dept.Location);
            object i = cmd.ExecuteNonQuery();
            int result = Convert.ToInt32(i);
            con.Close();
            return result;
        }
        public int DeleteDeptDetailsById(int? Id)
        {
            SqlCommand cmd = new SqlCommand("sp_DeleteDeptById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@DeptId", Id);
            object i = cmd.ExecuteNonQuery();
            int result = Convert.ToInt32(i);
            con.Close();
            return result;
        }
    }
}