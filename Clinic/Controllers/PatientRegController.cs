using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Controllers
{
    public class PatientRegController : Controller
    {
        static int sakinkodu;
           static String conString = "Data Source=HOBBIT\\SQLEXPRESS;Initial Catalog=clinic;Integrated Security=True;Encrypt=False";
        SqlConnection sqlConnection = new SqlConnection(conString);


        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewReg()
        {
            return View();
        }
         
        [HttpPost]
        public IActionResult NewReg(string k)
        {
       
                    sqlConnection.Open();
                    string reg = "INSERT INTO hasta(hastaAdi,kimlikNo,babaadi,anneadi,dogumtarihi,dogumyeri,cinsiyet,boy,kilo,meslek,kayittarihi,il,ilçe,adres,evTel," +
                        "ceptel,email,sosguvkur,sigara,alkol,kangrubu,hepatit,hiv,diyabet,kullandigilac,gecmishastaliklar,ailehastaliklari,gecmisameliyat," +
                        "sakinhakkinda) VALUES (@hastaAdi,@kimlikNo,@babaadi,@anneadi,@dogumtarihi,@dogumyeri,@cinsiyet,@boy,@kilo,@meslek,@kayittarihi,@il,@ilçe,@adres,@evTel," +
                        "@ceptel,@email,@sosguvkur,@sigara,@alkol,@kangrubu,@hepatit,@hiv,@diyabet,@kullandigilac,@gecmishastaliklar,@ailehastaliklari,@gecmisameliyat," +
                        "@sakinhakkinda)";

                    SqlCommand command = new SqlCommand(reg, sqlConnection);

                    string name = Request.Method == "POST" ? Request.Form["name"] : string.Empty;
                    string kimlikNo = Request.Method == "POST" ? Request.Form["kimlikNo"] : string.Empty;
                    string babaadı = Request.Method == "POST" ? Request.Form["babaadı"] : string.Empty;
                    string anneadı = Request.Method == "POST" ? Request.Form["anneadı"] : string.Empty;
                    string dogumtarihi = Request.Method == "POST" ? Request.Form["dogumtarihi"] : string.Empty;
                    string dogumyeri = Request.Method == "POST" ? Request.Form["dogumyeri"] : string.Empty;
                    string cinsiyet = Request.Method == "POST" ? Request.Form["cinsiyet"] : string.Empty;
                    string boy = Request.Method == "POST" ? Request.Form["boy"] : string.Empty;
                    string kilo = Request.Method == "POST" ? Request.Form["kilo"] : string.Empty;
                    string meslek = Request.Method == "POST" ? Request.Form["meslek"] : string.Empty;
                    string kayıttarihi = Request.Method == "POST" ? Request.Form["kayıttarihi"] : string.Empty;
                    string il = Request.Method == "POST" ? Request.Form["il"] : string.Empty;
                    string ilçe = Request.Method == "POST" ? Request.Form["ilçe"] : string.Empty;
                    string adres = Request.Method == "POST" ? Request.Form["adres"] : string.Empty;
                    string evTel = Request.Method == "POST" ? Request.Form["evTel"] : string.Empty;
                    string ceptel = Request.Method == "POST" ? Request.Form["ceptel"] : string.Empty;
                    string email = Request.Method == "POST" ? Request.Form["email"] : string.Empty;
                    string sosguvkur = Request.Method == "POST" ? Request.Form["sosguvkur"] : string.Empty;
                    string sigara = Request.Method == "POST" ? Request.Form["sigara"] : string.Empty;
                    string alkol = Request.Method == "POST" ? Request.Form["alkol"] : string.Empty;
                    string kangrubu = Request.Method == "POST" ? Request.Form["kangrubu"] : string.Empty;
                    string hepatit = Request.Method == "POST" ? Request.Form["hepatit"] : string.Empty;
                    string hıv = Request.Method == "POST" ? Request.Form["hıv"] : string.Empty;
                    string diyabet = Request.Method == "POST" ? Request.Form["diyabet"] : string.Empty;
                    string kullandigilac = Request.Method == "POST" ? Request.Form["kullandigilac"] : string.Empty;
                    string gecmishastalıklar = Request.Method == "POST" ? Request.Form["gecmishastalıklar"] : string.Empty;
                    string ailehastalıkları = Request.Method == "POST" ? Request.Form["ailehastalıkları"] : string.Empty;
                    string gecmisameliyat = Request.Method == "POST" ? Request.Form["gecmisameliyat"] : string.Empty;
                    string sakinhakkında = Request.Method == "POST" ? Request.Form["sakinhakkında"] : string.Empty;

                    command.Parameters.AddWithValue("@hastaAdi", name);
                    command.Parameters.AddWithValue("@kimlikNo", kimlikNo);
                    command.Parameters.AddWithValue("@babaadi", babaadı);
                    command.Parameters.AddWithValue("@anneadi", anneadı);
                    command.Parameters.AddWithValue("@dogumtarihi", dogumtarihi);
                    command.Parameters.AddWithValue("@dogumyeri", dogumyeri);
                    command.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                    command.Parameters.AddWithValue("@boy", boy);
                    command.Parameters.AddWithValue("@kilo", kilo);
                    command.Parameters.AddWithValue("@meslek", meslek);
                    command.Parameters.AddWithValue("@kayittarihi", kayıttarihi);
                    command.Parameters.AddWithValue("@il", il);
                    command.Parameters.AddWithValue("@ilçe", ilçe);
                    command.Parameters.AddWithValue("@adres", adres);
                    command.Parameters.AddWithValue("@evTel", evTel);
                    command.Parameters.AddWithValue("@ceptel", ceptel);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@sosguvkur", sosguvkur);
                    command.Parameters.AddWithValue("@sigara", sigara);
                    command.Parameters.AddWithValue("@alkol", alkol);
                    command.Parameters.AddWithValue("@kangrubu", kangrubu);
                    command.Parameters.AddWithValue("@hepatit", hepatit);
                    command.Parameters.AddWithValue("@hiv", hıv);
                    command.Parameters.AddWithValue("@diyabet", diyabet);
                    command.Parameters.AddWithValue("@kullandigilac", kullandigilac);
                    command.Parameters.AddWithValue("@gecmishastaliklar", gecmishastalıklar);
                    command.Parameters.AddWithValue("@ailehastaliklari", ailehastalıkları);
                    command.Parameters.AddWithValue("@gecmisameliyat",gecmisameliyat);
                    command.Parameters.AddWithValue("@sakinhakkinda", sakinhakkında);



                    command.ExecuteNonQuery();



            return View();
        }
        [HttpGet]
        public IActionResult Edit()
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

          


            return View(ds);
        }
        [HttpPost]
        public RedirectResult Edit(string bos )
        {
            string kod = Request.Method == "POST" ? Request.Form["sakinkodu"] : string.Empty;
            sakinkodu= Int32.Parse(kod);
          



            return Redirect("../PatientReg/EditRedirect");
        }
        [HttpGet]

        public IActionResult EditRedirect()
        {

           

            DataSet ds = new DataSet();
            string query = "SELECT * FROM hasta Where hastaID=@sakinkodu ";
         
          
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = sqlConnection;
                cmd.Parameters.Add(new SqlParameter("@sakinkodu", sakinkodu));
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
            string query = "UPDATE hasta  SET hastaAdi=@hastaAdi,kimlikNo=@kimlikNo,babaadi=@babaadi,anneadi=@anneadi,dogumtarihi=@dogumtarihi,dogumyeri=@dogumyeri,cinsiyet=@cinsiyet,boy=@boy,kilo=@kilo,meslek=@meslek,kayittarihi=@kayittarihi,il=@il,ilçe=@ilçe,adres=@adres,evTel=@evTel," +
                       "ceptel=@ceptel,email=@email,sosguvkur=@sosguvkur,sigara=@sigara,alkol=@alkol,kangrubu=@kangrubu,hepatit=@hepatit,hiv=@hiv,diyabet=@diyabet,kullandigilac=@kullandigilac,gecmishastaliklar=@gecmishastaliklar,ailehastaliklari=@ailehastaliklari,gecmisameliyat=@gecmisameliyat," +
                       "sakinhakkinda=@sakinhakkinda WHERE hastaID=@sakinkodu";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            string name = Request.Method == "POST" ? Request.Form["name"] : string.Empty;
            string kimlikNo = Request.Method == "POST" ? Request.Form["kimlikNo"] : string.Empty;
            string babaadı = Request.Method == "POST" ? Request.Form["babaadı"] : string.Empty;
            string anneadı = Request.Method == "POST" ? Request.Form["anneadı"] : string.Empty;
            string dogumtarihi = Request.Method == "POST" ? Request.Form["dogumtarihi"] : string.Empty;
            string dogumyeri = Request.Method == "POST" ? Request.Form["dogumyeri"] : string.Empty;
            string cinsiyet = Request.Method == "POST" ? Request.Form["cinsiyet"] : string.Empty;
            string boy = Request.Method == "POST" ? Request.Form["boy"] : string.Empty;
            string kilo = Request.Method == "POST" ? Request.Form["kilo"] : string.Empty;
            string meslek = Request.Method == "POST" ? Request.Form["meslek"] : string.Empty;
            string kayıttarihi = Request.Method == "POST" ? Request.Form["kayıttarihi"] : string.Empty;
            string il = Request.Method == "POST" ? Request.Form["il"] : string.Empty;
            string ilçe = Request.Method == "POST" ? Request.Form["ilçe"] : string.Empty;
            string adres = Request.Method == "POST" ? Request.Form["adres"] : string.Empty;
            string evTel = Request.Method == "POST" ? Request.Form["evTel"] : string.Empty;
            string ceptel = Request.Method == "POST" ? Request.Form["ceptel"] : string.Empty;
            string email = Request.Method == "POST" ? Request.Form["email"] : string.Empty;
            string sosguvkur = Request.Method == "POST" ? Request.Form["sosguvkur"] : string.Empty;
            string sigara = Request.Method == "POST" ? Request.Form["sigara"] : string.Empty;
            string alkol = Request.Method == "POST" ? Request.Form["alkol"] : string.Empty;
            string kangrubu = Request.Method == "POST" ? Request.Form["kangrubu"] : string.Empty;
            string hepatit = Request.Method == "POST" ? Request.Form["hepatit"] : string.Empty;
            string hıv = Request.Method == "POST" ? Request.Form["hıv"] : string.Empty;
            string diyabet = Request.Method == "POST" ? Request.Form["diyabet"] : string.Empty;
            string kullandigilac = Request.Method == "POST" ? Request.Form["kullandigilac"] : string.Empty;
            string gecmishastalıklar = Request.Method == "POST" ? Request.Form["gecmishastalıklar"] : string.Empty;
            string ailehastalıkları = Request.Method == "POST" ? Request.Form["ailehastalıkları"] : string.Empty;
            string gecmisameliyat = Request.Method == "POST" ? Request.Form["gecmisameliyat"] : string.Empty;
            string sakinhakkında = Request.Method == "POST" ? Request.Form["sakinhakkında"] : string.Empty;

            command.Parameters.AddWithValue("@hastaAdi", name);
            command.Parameters.AddWithValue("@kimlikNo", kimlikNo);
            command.Parameters.AddWithValue("@babaadi", babaadı);
            command.Parameters.AddWithValue("@anneadi", anneadı);
            command.Parameters.AddWithValue("@dogumtarihi", dogumtarihi);
            command.Parameters.AddWithValue("@dogumyeri", dogumyeri);
            command.Parameters.AddWithValue("@cinsiyet", cinsiyet);
            command.Parameters.AddWithValue("@boy", boy);
            command.Parameters.AddWithValue("@kilo", kilo);
            command.Parameters.AddWithValue("@meslek", meslek);
            command.Parameters.AddWithValue("@kayittarihi", kayıttarihi);
            command.Parameters.AddWithValue("@il", il);
            command.Parameters.AddWithValue("@ilçe", ilçe);
            command.Parameters.AddWithValue("@adres", adres);
            command.Parameters.AddWithValue("@evTel", evTel);
            command.Parameters.AddWithValue("@ceptel", ceptel);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@sosguvkur", sosguvkur);
            command.Parameters.AddWithValue("@sigara", sigara);
            command.Parameters.AddWithValue("@alkol", alkol);
            command.Parameters.AddWithValue("@kangrubu", kangrubu);
            command.Parameters.AddWithValue("@hepatit", hepatit);
            command.Parameters.AddWithValue("@hiv", hıv);
            command.Parameters.AddWithValue("@diyabet", diyabet);
            command.Parameters.AddWithValue("@kullandigilac", kullandigilac);
            command.Parameters.AddWithValue("@gecmishastaliklar", gecmishastalıklar);
            command.Parameters.AddWithValue("@ailehastaliklari", ailehastalıkları);
            command.Parameters.AddWithValue("@gecmisameliyat", gecmisameliyat);
            command.Parameters.AddWithValue("@sakinhakkinda", sakinhakkında);
            command.Parameters.AddWithValue("@sakinkodu", sakinkodu);


            command.ExecuteNonQuery();

            DataSet ds = new DataSet();
            string query1 = "SELECT * FROM hasta Where hastaID=@sakinkodu ";


            using (SqlCommand cmd = new SqlCommand(query1))
            {
                cmd.Connection = sqlConnection;
                cmd.Parameters.Add(new SqlParameter("@sakinkodu", sakinkodu));
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
            string query = "SELECT * FROM hasta";
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
            string sakinkodu = Request.Method == "POST" ? Request.Form["sakinkodu"] : string.Empty;
            sqlConnection.Open();
            string query = "DELETE FROM HASTA WHERE hastaID=@sakinkodu";
            
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@sakinkodu", sakinkodu);
            command.ExecuteNonQuery();
            DataSet ds = new DataSet();
            string query1 = "SELECT * FROM hasta";
            using (SqlCommand cmd = new SqlCommand(query1))
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
