using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Controllers
{
    public class AppointmentController : Controller
    {
        static String conString = "Data Source=HOBBIT\\SQLEXPRESS;Initial Catalog=clinic;Integrated Security=True;Encrypt=False";
        SqlConnection sqlConnection = new SqlConnection(conString);
        List<String> poliklinik = new List<string>();
        List<DateTime> saat = new List<DateTime>();


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewApp()
        {

            DataSet ds = new DataSet();
            string query = "SELECT * FROM hasta";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = sqlConnection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds);
                }
            }




       


            string query2 = "select poliklinik from poliklinik ";

            sqlConnection.Open();
            SqlCommand cmd2 = new SqlCommand(query2, sqlConnection);
            SqlDataReader reader = cmd2.ExecuteReader();

            while (reader.Read())
            {
                poliklinik.Add(reader["poliklinik"].ToString());


            }
            reader.Close();
           
            ViewBag.Poliklinik = new SelectList(poliklinik);
            ViewBag.Saat = new SelectList(saat);

            return View(ds);
        }
     
     
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Export()
        {
            return View();
        }
        public IActionResult Close()
        {
            return View();
        }
    }
}
