using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Controllers
{
    public class VisitorsController : Controller
    {
        static String conString = "Data Source=HOBBIT\\SQLEXPRESS;Initial Catalog=clinic;Integrated Security=True;Encrypt=False";
        SqlConnection sqlConnection = new SqlConnection(conString);
       static int  ziyaretcikodu;



        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewVisitor()
        {
            return View();
        }


        [HttpPost]
        public IActionResult NewVisitor(string k)
        {
            sqlConnection.Open();
            string query1 = "INSERT INTO ziyaretci(ziyaretciTCNO,ziyaretciAdi,ziyaretciAdres) VALUES (@ziyaretciTCNO,@ziyaretciAdi,@ziyaretciAdres)";

            SqlCommand command1 = new SqlCommand(query1, sqlConnection);

          
            string kimlikNo = Request.Method == "POST" ? Request.Form["kimlikNo"] : string.Empty;
            string name = Request.Method == "POST" ? Request.Form["name"] : string.Empty;
            string adres = Request.Method == "POST" ? Request.Form["adres"] : string.Empty;
            string hastaAdi = Request.Method == "POST" ? Request.Form["hastaAdi"] : string.Empty;

            command1.Parameters.AddWithValue("@ziyaretciAdi", name);
            command1.Parameters.AddWithValue("@ziyaretciTCNO", kimlikNo);
            command1.Parameters.AddWithValue("@ziyaretciAdres", adres);
            command1.Parameters.AddWithValue("@hastaAdi", hastaAdi);

            command1.ExecuteNonQuery();

            DataSet ds = new DataSet();
            string query3 = "SELECT * from hasta where hastaAdi=@hastaAdi";
            using (SqlCommand cmd = new SqlCommand(query3))
            {
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@hastaAdi", hastaAdi);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds);
                }
            }

            DataSet ds1 = new DataSet();
            string query4 = "SELECT * from ziyaretci where ziyaretciAdi=@name";
            using (SqlCommand cmd = new SqlCommand(query4))
            {
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@name", name);
               
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds1);
                }
            }


         


            string query2 = "INSERT INTO hastaZiyaretci(hastaID,ziyaretciID,yakınlık,ziyaretTarih) VALUES (@hastaID,@ziyaretciID,@yakınlık,@ziyaretTarih)";

            SqlCommand command2 = new SqlCommand(query2, sqlConnection);

            string yakinlik = Request.Method == "POST" ? Request.Form["yakinlik"] : string.Empty;
            string ziyaretTarih = Request.Method == "POST" ? Request.Form["ziyaretTarih"] : string.Empty;
            DateTime Tarih=new DateTime();
            if(DateTime.TryParse(ziyaretTarih,out Tarih))
            {
                command2.Parameters.AddWithValue("@ziyaretTarih", Tarih);
            }
             
            //DateTime ? ziyaretTarih = Request.Method == "POST" && !string.IsNullOrEmpty(Request.Form["ziyaretTarih"]) ?
            //    DateTime.ParseExact(Request.Form["ziyaretTarih"], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture): null ;






            command2.Parameters.AddWithValue("@yakınlık", yakinlik);
           
            command2.Parameters.AddWithValue("@hastaID", ds.Tables[0].Rows[0]["hastaID"]);
            command2.Parameters.AddWithValue("@ziyaretciID", ds1.Tables[0].Rows[0]["ziyaretciID"]);

            command2.ExecuteNonQuery();


            return View();
         
        }
        [HttpGet]
        public IActionResult Edit()
        {


            DataSet ds = new DataSet();
            
            string query = "select ziyaretci.ziyaretciID , ziyaretciAdi,ziyaretciTCNO,ziyaretciAdres,hastaAdi,yakınlık,ziyaretTarih from hastaZiyaretci,ziyaretci,hasta " +
                "where hastaZiyaretci.ziyaretciID=ziyaretci.ziyaretciID and hasta.hastaID=hastaZiyaretci.hastaID";
           
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = sqlConnection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds);
                }
            }




            return View(ds);
        }
        [HttpPost]
        public RedirectResult Edit(string bos)
        {
            string kod = Request.Method == "POST" ? Request.Form["ziyaretcikodu"] : string.Empty;
            ziyaretcikodu = Int32.Parse(kod);




            return Redirect("../Visitors/EditRedirect");
        }

        [HttpGet]

        public IActionResult EditRedirect()
        {



            DataSet ds = new DataSet();
            string query = "select ziyaretci.ziyaretciID , ziyaretciAdi,ziyaretciTCNO,ziyaretciAdres,hastaAdi,yakınlık,ziyaretTarih from hastaZiyaretci,ziyaretci,hasta " +
                "where hastaZiyaretci.ziyaretciID=ziyaretci.ziyaretciID and hasta.hastaID=hastaZiyaretci.hastaID and ziyaretci.ziyaretciID=@ziyaretcikodu ";


            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = sqlConnection;
                cmd.Parameters.Add(new SqlParameter("@ziyaretcikodu", ziyaretcikodu));
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds);
                }
            }


            return View(ds);



        }
        [HttpPost]
        public IActionResult EditRedirect(string k)
        {
           
            sqlConnection.Open();
            string query = "UPDATE ziyaretci  SET ziyaretciAdi=@ziyaretciAdi,ziyaretciTCNO=@kimlikNo,ziyaretciAdres=@adres WHERE ziyaretciID=@ziyaretcikodu";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            string name = Request.Method == "POST" ? Request.Form["name"] : string.Empty;
            string kimlikNo = Request.Method == "POST" ? Request.Form["kimlikNo"] : string.Empty;
            string adres = Request.Method == "POST" ? Request.Form["adres"] : string.Empty;
          
          

            command.Parameters.AddWithValue("@ziyaretciAdi", name);
            command.Parameters.AddWithValue("@kimlikNo", kimlikNo);
            command.Parameters.AddWithValue("@adres", adres);
         
            command.Parameters.AddWithValue("@ziyaretcikodu", ziyaretcikodu);


            command.ExecuteNonQuery();

            string query2 = "UPDATE hastaZiyaretci  SET yakınlık=@yakinlik,ziyaretTarih=@ziyaretTarihi WHERE ziyaretciID=@ziyaretcikodu";

            SqlCommand command2 = new SqlCommand(query2, sqlConnection);

            string yakinlik = Request.Method == "POST" ? Request.Form["yakinlik"] : string.Empty;
            string ziyaretTarihi = Request.Method == "POST" ? Request.Form["ziyaretTarihi"] : string.Empty;
          



            command2.Parameters.AddWithValue("@yakinlik", yakinlik);
            command2.Parameters.AddWithValue("@ziyaretTarihi", ziyaretTarihi);
          

            command2.Parameters.AddWithValue("@ziyaretcikodu", ziyaretcikodu);


            command2.ExecuteNonQuery();

            DataSet ds = new DataSet();
            string query3 = "select ziyaretci.ziyaretciID , ziyaretciAdi,ziyaretciTCNO,ziyaretciAdres,hastaAdi,yakınlık,ziyaretTarih from hastaZiyaretci,ziyaretci,hasta " +
                "where hastaZiyaretci.ziyaretciID=ziyaretci.ziyaretciID and hasta.hastaID=hastaZiyaretci.hastaID and ziyaretci.ziyaretciID=@ziyaretcikodu ";


            using (SqlCommand cmd = new SqlCommand(query3))
            {
                cmd.Connection = sqlConnection;
                cmd.Parameters.Add(new SqlParameter("@ziyaretcikodu", ziyaretcikodu));
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds);
                }
            }


            return View(ds);

        }

        [HttpGet]
        public IActionResult Delete()
        {
            DataSet ds = new DataSet();

            string query = "select ziyaretci.ziyaretciID , ziyaretciAdi,ziyaretciTCNO,ziyaretciAdres,hastaAdi,yakınlık,ziyaretTarih from hastaZiyaretci,ziyaretci,hasta " +
                "where hastaZiyaretci.ziyaretciID=ziyaretci.ziyaretciID and hasta.hastaID=hastaZiyaretci.hastaID";

            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = sqlConnection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds);
                }
            }




            return View(ds);

        }

        [HttpPost]
        public IActionResult Delete(string k)

        {
            string ziyaretcikodu = Request.Method == "POST" ? Request.Form["ziyaretcikodu"] : string.Empty;
            sqlConnection.Open();
            string query = "DELETE FROM hastaZiyaretci WHERE ziyaretciID=@ziyaretcikodu";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@ziyaretcikodu", ziyaretcikodu);
            command.ExecuteNonQuery();

            string query2 = "DELETE FROM ziyaretci WHERE ziyaretciID=@ziyaretcikodu";

            SqlCommand command2 = new SqlCommand(query2, sqlConnection);
            command2.Parameters.AddWithValue("@ziyaretcikodu", ziyaretcikodu);
            command2.ExecuteNonQuery();

            DataSet ds = new DataSet();

            string query3 = "select ziyaretci.ziyaretciID , ziyaretciAdi,ziyaretciTCNO,ziyaretciAdres,hastaAdi,yakınlık,ziyaretTarih from hastaZiyaretci,ziyaretci,hasta " +
                "where hastaZiyaretci.ziyaretciID=ziyaretci.ziyaretciID and hasta.hastaID=hastaZiyaretci.hastaID";

            using (SqlCommand cmd = new SqlCommand(query3))
            {
                cmd.Connection = sqlConnection;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds);
                }
            }




            return View(ds);

        }
        public IActionResult Export()
        {
            return View();
        }
        public IActionResult Report()
        {
            return View();
        }
        public IActionResult Close()
        {
            return View();
        }
    }
}
