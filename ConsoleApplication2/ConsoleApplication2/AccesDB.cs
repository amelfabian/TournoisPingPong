using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoucheMetier;

namespace CouchesAccèsBD
{
    class AccesDB
    {
        private SqlConnection sqlConn;

        public AccesDB()
        {
            try
            {
                sqlConn = new SqlConnection("Integrated security=true;" + "user id=antoine;" + "Data Source=DESKTOP-VHATAOL;" + "Initial Catalog=ProjetSGBD;");
                sqlConn.Open();
            }
            catch (Exception e)
            {
                throw new ExceptionAccesBD("Connexion à la BD", e.Message);
            }      
        }
            /**
             * Obtenir tous les joueurs
             **/

           public List<Joueur> ListerJoueurs()
        {
            List<Joueur> liste = null;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandText = "select num_joueur, nom_joueur, prenom_joueur, classement " +
                                      "from joueur " +
                                      "order by num_joueur asc";

                sqlCmd.Connection = sqlConn;

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    liste = new List<Joueur>();

                    do
                    {
                        liste.Add(new Joueur(Convert.ToInt32(sqlReader["num_joueur"]),
                                                            Convert.ToString(sqlReader["nom_joueur"]),
                                                            Convert.ToString(sqlReader["prenom_joueur"]),
                                                            Convert.ToString(sqlReader["classement"])));

                    } while (sqlReader.Read());
                }
                sqlReader.Close();
            }
            catch (Exception e)
            {

                throw new ExceptionAccesBD(sqlCmd.CommandText, e.Message); 
            }
            return liste; 
        }

        public List<Rencontre> ListerRencontreJoueur(int numJoueur)
        {
            List<Rencontre> liste = null;
            SqlCommand sqlCmd = new SqlCommand();

            try
            {
                sqlCmd.CommandText = "select rencontre.num_rencontre,rencontre.position,rencontre.resultat " +
                                      "from rencontre,joueur " +
                                      "where joueur.num_joueur = rencontre.num_j1 OR joueur.num_joueur = rencontre.num_j2 AND joueur.num_joueur = @numJoueur";
                sqlCmd.Connection = sqlConn;
              
                sqlCmd.Parameters.Add("@NumJoueur",SqlDbType.Int).Value = numJoueur;

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    liste = new List<Rencontre>();

                    do
                    {
                        liste.Add(new Rencontre(Convert.ToInt32(sqlReader["num_rencontre"]),
                                                Convert.ToString(sqlReader["position"]),
                                                Convert.ToString(sqlReader["resultat"])
                                           
                                                ));


                    } while (sqlReader.Read());
                }
                sqlReader.Close();
            }
            catch (Exception e)
            {

                throw new ExceptionAccesBD(sqlCmd.CommandText, e.Message);
            }
            return liste;

        }

        public int ajouterJoueur(Joueur joueur)
        {
            SqlCommand sqlCmd = new SqlCommand();
            
            try
            {
                sqlCmd.CommandText = "select max(num_joueur) + 1 from joueur";
                sqlCmd.Connection = sqlConn;
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                sqlReader.Read();

                if (sqlReader[0] == DBNull.Value)
                    joueur.num_joueur = 1;
                else
                    joueur.num_joueur = Convert.ToInt32(sqlReader[0]);
                sqlReader.Close();

                sqlCmd.CommandText =
                    "insert into joueur(num_joueur,nom_joueur,prenom_joueur,classement) " +
                    " values(@NumJoueur,@Nom,@Prenom,@Classement)";

                sqlCmd.Parameters.Add("@NumJoueur", SqlDbType.Int).Value = joueur.num_joueur;
                sqlCmd.Parameters.Add("@Nom", SqlDbType.VarChar).Value = joueur.nom_joueur;
                sqlCmd.Parameters.Add("@Prenom", SqlDbType.VarChar).Value = joueur.prenom_joueur;
                sqlCmd.Parameters.Add("@Classement", SqlDbType.VarChar).Value = joueur.classement;

                return sqlCmd.ExecuteNonQuery();

               
            }
            catch(Exception e)
            {
                throw new ExceptionAccesBD(sqlCmd.CommandText, e.Message);
            }
         
        }

        public int SupprimerJoueur(int numJoueur)
        {
            SqlCommand sqlCmd = new SqlCommand();

            try
            {
                sqlCmd.Connection = sqlConn;
                sqlCmd.Parameters.Add("@NumJoueur", SqlDbType.Int).Value = numJoueur;
                sqlCmd.CommandText = "delete from joueur where num_joueur = @NumJoueur";

                return sqlCmd.ExecuteNonQuery();
                    
            }catch(Exception e)
            {
                throw new ExceptionAccesBD(sqlCmd.CommandText, e.Message);
            }

        }

        public Joueur LireJoueurSpecifique(int numJoueur)
        {
            Joueur joueur = null;
            SqlCommand sqlCmd = new SqlCommand();

            try
            {
                sqlCmd.CommandText = "select num_joueur, nom_joueur, prenom_joueur, classement" +
                        " from joueur " +
                        " where num_joueur = @NumJoueur";
                sqlCmd.Connection = sqlConn;
                sqlCmd.Parameters.Add("@NumJoueur", SqlDbType.Int).Value = numJoueur;

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    joueur = new Joueur(Convert.ToInt32(sqlReader["num_joueur"]),
                                        Convert.ToString(sqlReader["nom_joueur"]),
                                        Convert.ToString(sqlReader["prenom_joueur"]),
                                        Convert.ToString(sqlReader["classement"]));
                    sqlReader.Close();
                }

            }
            catch(Exception e)
            {
                throw new ExceptionAccesBD(sqlCmd.CommandText, e.Message);
            }
            return joueur;
        }
    }
}
