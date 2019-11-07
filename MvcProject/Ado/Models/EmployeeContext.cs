using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Ado.Models
{
    public class EmployeeContext
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

        public int DeleteEmploeeById(int? Id)
        {
            SqlCommand cmd = new SqlCommand("sp_DeleteEmployeeById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@EmpId", Id);
            object i = cmd.ExecuteNonQuery();
            int result = Convert.ToInt32(i);
            con.Close();
            return result;
        }

    }
}