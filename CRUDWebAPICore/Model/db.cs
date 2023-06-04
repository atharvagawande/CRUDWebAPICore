using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CRUDWebAPICore.Model;
using System.Data;

namespace CRUDWebAPICore.Model
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-MDAP5DH\\MSSQLSERVER01;Initial Catalog=CsharpSpace;Integrated Security=True");
        public string EmployeeOpt(Employee emp)
        {
            string msg = string.Empty;
            
            try
            {
                SqlCommand com = new SqlCommand("Sp_Employee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", emp.ID);
                com.Parameters.AddWithValue("Email", emp.Email);
                com.Parameters.AddWithValue("@Emp_Name", emp.Emp_Name);
                com.Parameters.AddWithValue("@Designation", emp.Designation);
                com.Parameters.AddWithValue("@type", emp.type);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "SUCCESS";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return msg;
        }

        //GET Record
        public DataSet EmployeeGet(Employee emp, out string msg)
        {
             msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("Sp_Employee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", emp.ID);
                com.Parameters.AddWithValue("Email", emp.Email);
                com.Parameters.AddWithValue("@Emp_Name", emp.Emp_Name);
                com.Parameters.AddWithValue("@Designation", emp.Designation);
                com.Parameters.AddWithValue("@type", emp.type);

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";
                
                

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
           

            return ds;
        }

    }
}
