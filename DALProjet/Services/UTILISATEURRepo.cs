using DALProjet.Data;
using DALProjet.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProjet.Services
{
    public class UTILISATEURRepo : IRepository<UTILISATEUR>
    {
        private static IRepository<UTILISATEUR> _instance;
        public static IRepository<UTILISATEUR> Instance

        {
            get
            {
                return _instance ?? (_instance = new UTILISATEURRepo());
            }
        }
        private SqlConnection _connetion;
        private UTILISATEURRepo()
        {
            _connetion = new SqlConnection(@"Data Source=DESKTOP-02SO7PG\SQLEXPRESS;Initial Catalog=DB;Integrated Security=True");
            _connetion.Open();
        }
        public void Create(UTILISATEUR t)
        {
            SqlCommand cmd = _connetion.CreateCommand();
            cmd.CommandText = "INSERT INTO UTILISATEUR(Login,Password)VALUES(@login,@password)";
            cmd.Parameters.AddWithValue("login", t.Login);
            cmd.Parameters.AddWithValue("password", t.Password);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = _connetion.CreateCommand();
            cmd.CommandText = "DELETE FROM UTILISATEUR WHERE UserId=@id";
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        } 

        public List<UTILISATEUR> GetAll()
        {
            List<UTILISATEUR> userlist = new List<UTILISATEUR>();
            SqlCommand cmd = _connetion.CreateCommand();
            cmd.CommandText = "SELECT*FROM UTILISATEUR";
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    userlist.Add(new UTILISATEUR
                    {
                        UserId = (int)dr["Id"],
                        Login = dr["Login"].ToString(),
                        Password = dr["Password"].ToString(),
                        isAdmin = (bool)dr["isAdmin"],
                        isActive = (bool)dr["isActive"],


                    });
                }
                return userlist;
            }

        }

        public void Update(UTILISATEUR t)
        {

            SqlCommand cmd = _connetion.CreateCommand();
            cmd.CommandText = "UPDATE * FROM UTILISATEUR SET Login=@login,Password=@password, IsAdmin=@isAdmin,IsPromo,IsFinanceur, IsActive=@isAdmin WHERE UserId=@id";
            cmd.Parameters.AddWithValue("login", t.Login);
            cmd.Parameters.AddWithValue("password", t.Password);
            cmd.Parameters.AddWithValue("isAdmin", t.isActive);
            cmd.Parameters.AddWithValue("isPromo", t.isActive);
            cmd.Parameters.AddWithValue("isFinanceur", t.isActive);
            cmd.Parameters.AddWithValue("isActive", t.isActive);
            cmd.Parameters.AddWithValue("id", t.UserId);

            cmd.ExecuteNonQuery();
        }

        public UTILISATEUR GetOne(int id)
        {

            SqlCommand cmd = _connetion.CreateCommand();
            cmd.CommandText = "SELECT * FROM UTILISATEUR WHERE id=@id";
            cmd.Parameters.AddWithValue("id", id);
            UTILISATEUR u = new UTILISATEUR();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    u.UserId = (int)dr["Id"];
                    u.Login = dr["Login"].ToString();
                    u.Password = dr["Password"].ToString();
                    u.isAdmin = (bool)dr["isAdmin"];
                    u.isPromo = (bool)dr["isPromo"];
                    u.isFinanceur = (bool)dr["isFinanceur"];
                    u.isActive = (bool)dr["isAdmin"];

                }
            }
            return u;
        }
       
        
    }
}

