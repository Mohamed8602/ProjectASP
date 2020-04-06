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
    public  class ADMINISTRATEURRepo : IRepository<ADMINISTRATEUR>
    {

        private static IRepository<ADMINISTRATEUR> _instance;
        public static IRepository<ADMINISTRATEUR> Instance

        {
            get
            {
        
                return _instance ?? (_instance = new ADMINISTRATEURRepo());
            }
        }
        private SqlConnection _connetion;
        public ADMINISTRATEURRepo()
        {
            _connetion = new SqlConnection(@"Data Source=DESKTOP-02SO7PG\SQLEXPRESS;Initial Catalog=DB;Integrated Security=True");
            _connetion.Open();
        }
        public void Create(ADMINISTRATEUR t)
        {
            SqlCommand cmd = _connetion.CreateCommand();
            cmd.CommandText = "INSERT INTO ADMINISTRATEUR(AdminId,NomAdmin)VALUES(@adminId,@NomAdmin)";
            cmd.Parameters.AddWithValue("login", t.AdminId);
            cmd.Parameters.AddWithValue("password", t.NomAdmin);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int AdminId)
        {
            SqlCommand cmd = _connetion.CreateCommand();
            cmd.CommandText = "DELETE FROM ADMINISTRATEUR WHERE AdminId=@id";
            cmd.Parameters.AddWithValue("id", AdminId);
            cmd.ExecuteNonQuery();
        }

        public List<ADMINISTRATEUR> GetAll()
        {
            List<ADMINISTRATEUR> adminlist = new List<ADMINISTRATEUR>();
            SqlCommand cmd = _connetion.CreateCommand();
            cmd.CommandText = "SELECT*FROM ADMINISTRATEUR";
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    adminlist.Add(new ADMINISTRATEUR
                    {
                        AdminId = (int)dr["Id"],
                        NomAdmin=dr["NomAdmin"].ToString()


                    });
                }
                return adminlist;
            }

        }

        public void Update(ADMINISTRATEUR t)
        {

            SqlCommand cmd = _connetion.CreateCommand();
            cmd.CommandText = "UPDATE * FROM ADMINISTRATEUR SET AdminId=@AdminId,NomAdmin=@NomAdmin, WHERE AdminId=@id";
            cmd.Parameters.AddWithValue("Id", t.AdminId);
            cmd.Parameters.AddWithValue("NomAdmin", t.NomAdmin);
            

            cmd.ExecuteNonQuery();
        }

        public ADMINISTRATEUR GetOne(int AdminId)
        {

            SqlCommand cmd = _connetion.CreateCommand();
            cmd.CommandText = "SELECT * FROM ADMINSTRATEUR WHERE AdminId=@id";
            cmd.Parameters.AddWithValue("id", AdminId);
            ADMINISTRATEUR a = new ADMINISTRATEUR();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    a.AdminId = (int)dr["AdminId"];
                    a.NomAdmin = dr["NomAdin"].ToString();


                }
            }
            return a;
        }
    }
}
