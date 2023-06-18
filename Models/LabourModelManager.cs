using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LabourManagementApp.Models
{
    public class LabourModelManager
    {
        string con = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        public /*List<LabourViewModel>*/DataSet GetLabours()
        {
            using(SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("getlabours", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet dataset = new DataSet();
                da.Fill(dataset);
                return dataset;
                //cn.Open();
                //SqlDataReader reader = cmd.ExecuteReader();
                //List<LabourViewModel> labours = new List<LabourViewModel>();
                //while (reader.Read())
                //{
                //    LabourViewModel labour = new LabourViewModel();
                //    labour.Lid = Convert.ToInt32(reader["lid"]);
                //    labour.Fname = reader["fname"].ToString();
                //    labour.Lname = reader["lname"].ToString();
                //    labour.Age = Convert.ToInt32(reader["age"]);
                //    labour.Bg = reader["bg"].ToString();
                //    labour.Number = Convert.ToInt64(reader["number"]);
                //    labours.Add(labour);
                //}
                //return labours;
            }
            //SqlConnection cn = new SqlConnection(con); 
            //SqlCommand cmd = new SqlCommand("select *from Labour", cn);
            //cn.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            //List<Labour> labours = new List<Labour>();
            //while (reader.Read())
            //{
            //    Labour labour = new Labour();
            //    labour.Lid = Convert.ToInt32(reader["lid"]);
            //    labour.Fname = reader["fname"].ToString();
            //    labour.Lname = reader["lname"].ToString();
            //    labour.Age = Convert.ToInt32(reader["age"]);
            //    labour.Bg = reader["bg"].ToString();
            //    labour.Number = Convert.ToInt64(reader["number"]);
            //    labours.Add(labour);
            //}
            //return labours;
        }

        public LabourViewModel GetLabourById(int id)
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                //SqlCommand cmd = new SqlCommand($"select *from Labour where lid={id}", cn);
                SqlCommand cmd = new SqlCommand("getlabourbyid", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@lid", id);
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                LabourViewModel labour = new LabourViewModel();
                if (reader.Read())
                {
                    labour.Lid = Convert.ToInt32(reader["lid"]);
                    labour.Fname = reader["fname"].ToString();
                    labour.Lname = reader["lname"].ToString();
                    labour.Gender = reader["gender"].ToString();
                    labour.Age = Convert.ToInt32(reader["age"]);
                    labour.Bg = reader["bg"].ToString();
                    labour.Number = Convert.ToInt64(reader["number"]);
                }
                return labour;
            }
            //SqlCommand cmd = new SqlCommand($"select *from Labour where lid={id}", cn);
            //cn.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            //LabourViewModel labour = new LabourViewModel();
            //if (reader.Read())
            //{
            //    labour.Lid = Convert.ToInt32(reader["lid"]);
            //    labour.Fname = reader["fname"].ToString();
            //    labour.Lname = reader["lname"].ToString();
            //    labour.Age = Convert.ToInt32(reader["age"]);
            //    labour.Bg = reader["bg"].ToString();
            //    labour.Number = Convert.ToInt64(reader["number"]);
            //}
            //return labour;
        }

        public int CreateLabour(LabourViewModel labour)
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                //string qry = string.Format("insert into labour(fname,lname,age,bg,number) values('{0}','{1}','{2}','{3}','{4}')", labour.Fname, labour.Lname, labour.Age, labour.Bg, labour.Number);
                SqlCommand cmd = new SqlCommand("insertlabour", cn);
                cmd.Parameters.AddWithValue("@fname", labour.Fname);
                cmd.Parameters.AddWithValue("@lname", labour.Lname);
                cmd.Parameters.AddWithValue("@gender", labour.Gender);
                cmd.Parameters.AddWithValue("@age", labour.Age);
                cmd.Parameters.AddWithValue("@bg", labour.Bg);
                cmd.Parameters.AddWithValue("@number", labour.Number);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                int insertedRow = cmd.ExecuteNonQuery();
                cn.Close();
                return insertedRow;
            }
        }

        public int UpdateLabour(LabourViewModel labour)
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                //string qry = string.Format("update labour set fname='{0}',lname='{1}',age={2},bg='{3}',number={4} where lid={5}", labour.Fname, labour.Lname, labour.Age, labour.Bg, labour.Number, labour.Lid);
                SqlCommand cmd = new SqlCommand("updatelabour", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@lid", labour.Lid);
                cmd.Parameters.AddWithValue("@fname", labour.Fname);
                cmd.Parameters.AddWithValue("@lname", labour.Lname);
                cmd.Parameters.AddWithValue("@gender", labour.Gender);
                cmd.Parameters.AddWithValue("@age", labour.Age);
                cmd.Parameters.AddWithValue("@bg", labour.Bg);
                cmd.Parameters.AddWithValue("@number", labour.Number);
                cn.Open();
                int updatedRow = cmd.ExecuteNonQuery();
                cn.Close();
                return updatedRow;
            }
        }

        public int DeleteLabour(int id)
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                //string qry = string.Format("delete from labour where lid = {0}", id);
                SqlCommand cmd = new SqlCommand("deletelabour", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@lid", id);
                cn.Open();
                int deletedRow = cmd.ExecuteNonQuery();
                cn.Close();
                return deletedRow;
            }
        }

        public List<Bg> Getbgs()
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                //SqlCommand cmd = new SqlCommand("select *from bg1", cn);
                SqlCommand cmd = new SqlCommand("bglist1", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Bg> bgs = new List<Bg>();
                while (reader.Read())
                {
                    Bg bg = new Bg();
                    bg.id = Convert.ToInt32(reader["bid"]);
                    bg.name = reader["bgname"].ToString();
                    bgs.Add(bg);
                }
                return bgs;
            }
        }

        public List<Gender> GetGender()
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                //SqlCommand cmd = new SqlCommand("select *from bg1", cn);
                SqlCommand cmd = new SqlCommand("getgender", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Gender> gs = new List<Gender>();
                while (reader.Read())
                {
                    Gender g = new Gender();
                    g.id = Convert.ToInt32(reader["id"]);
                    g.name = reader["name"].ToString();
                    gs.Add(g);
                }
                return gs;
            }
        }
    }
}