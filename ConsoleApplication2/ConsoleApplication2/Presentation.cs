using CouchesAccèsBD;
using System;
using System.Collections.Generic;

namespace CoucheMetier
{
    public class Presentation
    {
        
        private AccesDB coucheAccesBD;
        public Presentation()
        {
            try
            {
                coucheAccesBD = new AccesDB();
            }
            catch (ExceptionAccesBD e)
            {

                Console.WriteLine("\nAccès à la BD impossible("+ e.Message + ")");
                System.Environment.Exit(0);
            }
        }

        public void MenuPrincipal()
        {
            while (true)
            {
                AccesConsole.CreerEcran("Menu principal");
                Console.WriteLine("1 = joueurs" +
                                   "\n2 = Lister toutes les tables" +
                                   "\n3 = Lister tous les  arbitres" +
                                   "\n4 =  Rencontre" +
                                   "\nQ = Quitter");
                try
                {
                    switch (AccesConsole.SaisirInt("\nChoix:"))
                    {
                        case 1:
                            AccesConsole.CreerEcran("Joueurs");
                            MenuJoueur();
                            AccesConsole.Attendre();

                            break;

                        case 2:
                            AccesConsole.CreerEcran("Lister toutes les tables");
                            int i = Int32.Parse(Console.ReadLine());
                            AccesConsole.Attendre();
                            break;

                        case 3:
                            AccesConsole.CreerEcran("Lister tous les  arbitres");
                            break;

                        case 4:
                            AccesConsole.CreerEcran("Rencontre");
                            MenuRencontre();
                            break;

                        case 'Q':
                            AccesConsole.CreerEcran("Quitter");
                            
                            break;
                        
                            
                    }

                }

                catch (ExceptionAccesBD e)
                {
                    Console.WriteLine("\nAccès à la BD impossible(" + e.Message + ")");
                    System.Environment.Exit(0);
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nErreur rencontrée(" + e.Message + ")");
                 
                }
            }
            
        }

      

        public void MenuJoueur()
        {
            AccesConsole.CreerEcran("Menu Joueur");
            Console.WriteLine("1 = Lister joueur" +
                               "\n2 = Lister les rencontres jouées par un joueur spécifique" +
                               "\n3 = Ajouter un joueur" +
                               "\n4 = Supprimer un joueur" +
                               "\n5 = Modifier un joueur" +
                               "\nQ = Quitter");

            switch (AccesConsole.SaisirInt("\nChoix:"))
            {
                case 1:
                    AccesConsole.CreerEcran("Lister joueur");
                    ListerJoueurs();
                    break;

                case 2:
                    AccesConsole.CreerEcran("Lister les rencontres jouées par un joueur spécifique");
                   ListerRencontreJoueur();
                    break;

                case 3:
                    AccesConsole.CreerEcran("Ajouter un joueur");
                    AjouterJoueur();
                    break;

                case 4:
                    AccesConsole.CreerEcran("Supprimer un joueur");
                    SupprimerJoueur();
                    break;

                case 5:
                    AccesConsole.CreerEcran("Modifier un joueur");
                    break;

                case 'Q':
                    break;
                default:
                    MenuPrincipal();
                    break;
            }
        }

        public void MenuRencontre()
        {
            AccesConsole.CreerEcran("Menu Rencontre");

            Console.WriteLine("1 = Creer un nouveau tournoi avec 1/4 généré automatiquement" +
                               "\n2 = Lister les rencontres jouées par un joueur spécifique" +
                               "\n3 = Générer les demi-finales et la final sur base de la phase précédente" +
                               "\n4 = Lister rencontres pour chaque phase du tournoi" +
                               "\n5 = Modifier rencontre pour indiquer vainqueur" +
                               "\nQ = Quitter");

            switch (AccesConsole.SaisirInt("\nChoix:"))
            {
                case 1:
                    AccesConsole.CreerEcran("Creer un nouveau tournoi avec 1/4 généré automatiquement");
                    break;
                case 2:
                    AccesConsole.CreerEcran("Lister les rencontres jouées par un joueur spécifique");
                    break;
                case 3:
                    AccesConsole.CreerEcran("Générer les demi-finales et la final sur base de la phase précédente");
                    break;
                case 4:
                    AccesConsole.CreerEcran("Lister rencontres pour chaque phase du tournoi");
                    break;
                case 5:
                    AccesConsole.CreerEcran("Modifier rencontre pour indiquer vainqueur");
                    break;
                default:
                    MenuPrincipal();
                    break;
            }

        }

        public void ListerJoueurs()
             {
            List<Joueur> liste = coucheAccesBD.ListerJoueurs();
            if (liste == null)
            {
                Console.WriteLine("\nIl n'y a aucun joueur dans la BD!");
                return;
            }
            Console.WriteLine("Numéro, nom, prénom, classement:\n");
            while (liste.Count > 0)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", liste[0].num_joueur,liste[0].nom_joueur,liste[0].prenom_joueur, liste[0].classement);
                liste.RemoveAt(0);
            }
        }

            public void ListerRencontreJoueur()
        {
            int joueur = AccesConsole.SaisirInt("\n entrez le numero d'un joueur: ");
            List<Rencontre> liste = coucheAccesBD.ListerRencontreJoueur(joueur);

            if (liste == null)
            {
                Console.WriteLine("\nIl n'y a aucune recontre pour ce joueur !");
                return;
            }

            Console.WriteLine("Numéro, position, résultat ");

            while (liste.Count > 0)
            {
                Console.WriteLine("{0}, {1}, {2}", liste[0].num_rencontre, liste[0].position, liste[0].resultat);
                liste.RemoveAt(0);
            }
        }

        public void AjouterJoueur()
        {
            Joueur joueur = new Joueur();

            joueur.nom_joueur = AccesConsole.SaisirChaine("Entrez le nom du joueur: ");
            joueur.prenom_joueur = AccesConsole.SaisirChaine("Entrez le prénom du joueur: ");
            joueur.classement = AccesConsole.SaisirChaine("Entrez le classement du joueur: ");

            if (coucheAccesBD.ajouterJoueur(joueur) == 0)
            {
                Console.WriteLine("\nL'ajout n'a pas eu lieu!");
            }
            else
            {
                Console.WriteLine("\nL'ajout s'est bien déroulé");
            }

        }

        public void SupprimerJoueur()
        {
            Joueur joueur;

            int numJoueur = AccesConsole.SaisirInt("entrez le numéro du joueur à supprimer: ");
            
            if((joueur = coucheAccesBD.LireJoueurSpecifique(numJoueur)) == null){
                Console.WriteLine("\nLe joueur demandé n'existe pas !");
                return;
            }
            string s = AccesConsole.SaisirChaine("\nVoulez-vous supprimer le joueur " + joueur.prenom_joueur + " " + joueur.nom_joueur + " (o/n)? ");

            if(s.CompareTo("o") == 0)
            {
                if (coucheAccesBD.SupprimerJoueur(numJoueur) == 0)
                    Console.WriteLine("\n\nLa suppression n'a pas eu lieu! ");
                else
                    Console.WriteLine("\n\nLa suppression s'est bien déroulée");
            }
        }
        }
    }

