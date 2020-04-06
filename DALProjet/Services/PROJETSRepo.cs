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
    public class PROJETSRepo:IRepository<PROJETS>
    {
        private static IRepository<PROJETS> _instance;
        public static IRepository<PROJETS> Instance

        {
            get
            {
                return _instance ?? (_instance = new PROJETSRepo());
            }
        }
        private SqlConnection _connetion;
        public PROJETSRepo()
        {
            _connetion = new SqlConnection(@"Data Source=DESKTOP-02SO7PG\SQLEXPRESS;Initial Catalog=DB;Integrated Security=True");
            _connetion.Open();
        }
        public void Create(PROJETS t)
        {

            SqlCommand cmd = _connetion.CreateCommand();
            cmd.CommandText = "INSERT INTO PROJETS(Nom,Description,plafondFinancement,numeroCompte,urlvideo)VALUES(@Nom,@Description,@plafondFinancement,@numeroCompte,@urlvideo)";
            cmd.Parameters.AddWithValue("Nom", t.Nom);
            cmd.Parameters.AddWithValue("Description", t.Description);
            cmd.Parameters.AddWithValue("plafondFinancement", t.plafondFinancement);
            cmd.Parameters.AddWithValue("numeroCompte", t.numeroCompte);
            cmd.Parameters.AddWithValue("urlvideo", t.urlVideo);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = _connetion.CreateCommand();
            cmd.CommandText = "DELETE FROM PROJETS WHERE ProjetId=@id";
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }

        public List<PROJETS> GetAll()
        {
            List<PROJETS> projetlist = new List<PROJETS>();
            SqlCommand cmd = _connetion.CreateCommand();
            cmd.CommandText = "SELECT*FROM PROJETS";
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    projetlist.Add(new PROJETS
                    {
                        ProjetId = (int)dr["Id"],
                        Nom = dr["Nom"].ToString(),
                        Description = dr["Description"].ToString(),
                        plafondFinancement = (double)dr["plafondFinancement"],
                        numeroCompte = dr["numeroCompte"].ToString(),
                        urlVideo = dr["urlvideo"].ToString()


                    });
                }
                return projetlist;
            }
        }

        public PROJETS GetOne(int id)
        {
            SqlCommand cmd = _connetion.CreateCommand();
            cmd.CommandText = "SELECT * FROM Users WHERE id=@id";
            cmd.Parameters.AddWithValue("id", id);
            PROJETS p = new PROJETS();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    p.ProjetId = (int)dr["Id"];
                    p.Nom = dr["Nom"].ToString();
                    p.Description = dr["Pwd"].ToString();
                    p.plafondFinancement = (double)dr["plafondFinancement"];
                    p.urlVideo = dr["urlvideo"].ToString();
                    p.numeroCompte = dr["numeroCompte"].ToString();

                }
            }
            return p;
        }



        public void Update(PROJETS t)
        {
            SqlCommand cmd = _connetion.CreateCommand();
            cmd.CommandText = "UPDATE*FROM SOCIETE SET Id=@Id, numeroTVA=@numeroTVA,Descript=@Descript";
            cmd.Parameters.AddWithValue("ProjetId", t.ProjetId);
            cmd.Parameters.AddWithValue("Description", t.Description);
            cmd.Parameters.AddWithValue("Nom", t.Nom);
            cmd.Parameters.AddWithValue("urlvideo", t.urlVideo);
            cmd.ExecuteNonQuery();
        }
    }
}
