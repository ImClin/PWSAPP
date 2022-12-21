using MySql.Data.MySqlClient;
using System;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.PortableExecutable;
using WebApiClin.Classes.Requests;
using WebApiClin.Classes.Responses;

namespace WebApiClin.Classes
{
    public class Database
    {

        private static string ConnectieString = "server=testserver-clin.mysql.database.azure.com;database=volgsysteem;user id=clin;password=Colin#01;";
        public static string TestConnection()
        {
            try
            {
                string Resultaat = "";

                using (var connection = new MySqlConnection(ConnectieString))
                {
                    connection.Open();

                    using var command = new MySqlCommand("SELECT COUNT(*) FROM Leerlingen", connection);
                    var movieCount = command.ExecuteScalar();
                    Resultaat = ($"Er zijn {movieCount} leerlingen");
                }
                return Resultaat;

            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }

        }

        public static List<DocentGegevens> DocentenLijst()
        {
            {
                List<DocentGegevens> Resultaat = new List<DocentGegevens>();

                using (var connection = new MySqlConnection(ConnectieString))
                {
                    connection.Open();

                    using var command = new MySqlCommand("select DocentId, Wachtwoord, Naam, IsMentor, Omschrijving from volgsysteem.docenten d left join volgsysteem.vakken v on d.VakId = v.VakId", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DocentGegevens d = new DocentGegevens();
                            d.DocentId = reader.GetString(0);
                            d.Wachtwoord = reader.GetString(1);
                            d.Naam = reader.GetString(2);
                            d.Mentor = "Nee";
                            if (reader.GetInt16(3) == 1)
                                d.Mentor = "Ja";
                            d.VakId = reader.GetString(3);
                            d.Omschrijving= reader.GetString(4);
                            Resultaat.Add(d);
                        }
                    }
                }
                return Resultaat;
            }

        }

        [Serializable]
        class InlogException : Exception
        {
            public InlogException() { }

            public InlogException(string name)
                : base(String.Format("Ongeldige inlog gegevens"))
            {

            }
        }

        public static List<LeerlingGegevens> LeerlingenLijst()
        {
            {
                List<LeerlingGegevens> Resultaat = new List<LeerlingGegevens>();

                using (var connection = new MySqlConnection(ConnectieString))
                {
                    connection.Open();

                    using var command = new MySqlCommand("SELECT LeerlingId, l.Wachtwoord, l.naam as LeerlingNaam, Klas, MentorId, d.naam as MentorNaam FROM volgsysteem.leerlingen l inner join volgsysteem.docenten d on l.MentorId = d.DocentId ;", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            LeerlingGegevens d = new LeerlingGegevens();
                            d.LeerlingId = reader.GetInt16(0);
                            d.Wachtwoord = reader.GetString(1);
                            d.LeerlingNaam = reader.GetString(2);
                            d.Klas = reader.GetString(3);
                            d.MentorId = reader.GetString(4);
                            d.MentorNaam = reader.GetString(5);
                            Resultaat.Add(d);
                        }
                    }
                }
                return Resultaat;
            }

        }

        public static List<MijnCijfers> MijnCijferLijst(string LeerlingId)
        {
            {
                List<MijnCijfers> Resultaat = new List<MijnCijfers>();

                using (var connection = new MySqlConnection(ConnectieString))
                {
                    connection.Open();
                    //
                    // Eerst het vakkenpakket ophalen
                    //
                    var sqlCommand = "SELECT vp.VakId, v.Omschrijving, d.docentId, d.Naam " +
                                    "FROM volgsysteem.vakkenpakket vp " +
                                    "INNER JOIN volgsysteem.vakken v on vp.VakId = v.VakId " +
                                    "INNER JOIN volgsysteem.docenten d on vp.VakId = d.VakId " +
                                    $"WHERE vp.LeerlingId = '{LeerlingId}' ";
                    using var command = new MySqlCommand(sqlCommand, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MijnCijfers d = new MijnCijfers();
                            d.VakId = reader.GetInt32(0);
                            d.Omschrijving = reader.GetString(1);
                            d.DocentId = reader.GetString(2);
                            d.Naam = reader.GetString(3);
                            //
                            // Cijfers erbij zoeken
                            //
                            Gemiddelde Score = new Gemiddelde();
                            d.Behaald = CijfersOphalen(LeerlingId, d.VakId, Score);
                            d.Gemiddelde = Score.Waarde;
                            //
                            Resultaat.Add(d);
                        }
                    }
                }
                return Resultaat;
            }

        }

        class Gemiddelde
        {
            public int Waarde = 0;
        }

        public static List<CijfersPerKlas> MijnLeerlingenCijfers(int VakId)
        {
            // TODO
            {
                List<CijfersPerKlas> Resultaat = new List<CijfersPerKlas>();

                using (var connection = new MySqlConnection(ConnectieString))
                {
                    connection.Open();
                    //
                    // Eerst het vakkenpakket ophalen
                    //
                    var sqlCommand = "SELECT vp.VakId, Omschrijving, vp.LeerlingId, Naam, Klas " +
                                     "FROM volgsysteem.vakkenpakket vp " +
                                     "INNER JOIN volgsysteem.vakken v on vp.VakId = v.VakId " +
                                     "INNER JOIN volgsysteem.leerlingen l on vp.LeerlingId = l.LeerlingId " +
                                     $"WHERE vp.VakId = {VakId} ";
                    using var command = new MySqlCommand(sqlCommand, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CijfersPerKlas d = new CijfersPerKlas();
                            d.VakId = reader.GetInt32(0);
                            d.Omschrijving = reader.GetString(1);
                            d.LeerlingId = reader.GetString(2);
                            d.Naam = reader.GetString(3);
                            d.Klas = reader.GetString(4);
                            //
                            // Cijfers erbij zoeken
                            //
                            //
                            Gemiddelde Score = new Gemiddelde();
                            d.Behaald = CijfersOphalen(d.LeerlingId, d.VakId, Score);
                            d.Gemiddelde = Score.Waarde;
                            Resultaat.Add(d);
                        }
                    }
                }
                return Resultaat;
            }

        }

        private static List<int> CijfersOphalen(string LeerlingId, int VakId, Gemiddelde Score)
        {
            List<int> Resultaat = new List<int>();
            using (var connection2 = new MySqlConnection(ConnectieString))
            {
                connection2.Open();
                var sqlCommand = "SELECT Cijfer " +
                             "FROM volgsysteem.cijferlijst " +
                             $"WHERE LeerlingId = {LeerlingId} " +
                             $"AND VakId = {VakId}";
                using var cijfersCommand = new MySqlCommand(sqlCommand, connection2);
                MySqlDataReader reader2 = cijfersCommand.ExecuteReader();
                int Aantal = 0;
                int Totaal = 0;
                if (reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                        Resultaat.Add(reader2.GetInt32(0));
                        Totaal += reader2.GetInt32(0);
                        Aantal += 1;
                    }
                    int roundedE = (int)Decimal.Round(Totaal / Aantal, 0, MidpointRounding.AwayFromZero);
                    if (Aantal > 0) { Score.Waarde = roundedE; };
                }
            }
            return Resultaat;
        }

        public static List<CijfersPerKlas> CijfersBijwerken(List<BehaaldeCijfers> NieuweCijfers)
        {
            List<CijfersPerKlas> Resultaat = new List<CijfersPerKlas>();
            int InterneVakId = 0;
            using (var connection = new MySqlConnection(ConnectieString))

            {
                //
                // Open connectie en transactie starten
                //
                connection.Open();
                MySqlTransaction myTransaction;
                myTransaction = connection.BeginTransaction();
                try
                {
                    bool EersteLeerling = true;
                    foreach (var Leerling in NieuweCijfers)
                    {
                        MySqlCommand myCommand = connection.CreateCommand();
                        if (EersteLeerling)
                        {
                            //
                            // Alle oude cijfers weggooien gelijk voor alle leerlingen
                            //
                            myCommand.CommandText = $"DELETE FROM volgsysteem.cijferlijst WHERE VakId = {Leerling.VakId}  ";
                            myCommand.ExecuteNonQuery();
                            EersteLeerling = false;
                            InterneVakId = Leerling.VakId;
                        }
                        //
                        // Nieuwe cijfers aanmaken
                        //
                        foreach (var Cijfer in Leerling.Behaald)
                        {
                            myCommand.CommandText = "INSERT INTO volgsysteem.cijferlijst (VakId, LeerlingId, Cijfer) " +
                                                    $"VALUES ( {Leerling.VakId}, '{Leerling.LeerlingId}', {Cijfer})";
                            myCommand.ExecuteNonQuery();
                        }
                    }
                    //
                    // Tranactie doorvoeren
                    //
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    //  
                    // Transactie afbreken
                    //
                    myTransaction.Rollback();
                    throw;
                }

            }
            //
            // Nieuwe cijfers ophalen
            //
            Resultaat = MijnLeerlingenCijfers(InterneVakId);
            return Resultaat;
        }

        public static LeerlingGegevens MijnLeerlingGegevens(string LeerlingId)
        {
            {
                LeerlingGegevens Resultaat = new LeerlingGegevens();

                using (var connection = new MySqlConnection(ConnectieString))
                {
                    connection.Open();
                    var selecdCommand = "SELECT LeerlingId, l.Wachtwoord, l.naam as LeerlingNaam, Klas, " +
                        "MentorId, d.naam as MentorNaam FROM volgsysteem.leerlingen l " +
                        "inner join volgsysteem.docenten d on l.MentorId = d.DocentId " +
                        $"WHERE LeerlingId = '{LeerlingId}' ";
                    using var command = new MySqlCommand(selecdCommand, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Resultaat.LeerlingId = reader.GetInt16(0);
                        Resultaat.Wachtwoord = reader.GetString(1);
                        Resultaat.LeerlingNaam = reader.GetString(2);
                        Resultaat.Klas = reader.GetString(3);
                        Resultaat.MentorId = reader.GetString(4);
                        Resultaat.MentorNaam = reader.GetString(5);
                    }
                }
                return Resultaat;
            }

        }

        public static DocentGegevens MijnDocentGegevens(string DocentId)
        {
            {
                DocentGegevens Resultaat = new DocentGegevens();

                using (var connection = new MySqlConnection(ConnectieString))
                {
                    connection.Open();
                    var selecdCommand = "SELECT DocentId, Wachtwoord, Naam, d.VakId, Omschrijving, IsMentor " +
                                        "FROM volgsysteem.docenten d " +
                                        "inner join volgsysteem.vakken v on d.VakId = v.VakId " +
                                        $"WHERE DocentId = '{DocentId}'";
                    using var command = new MySqlCommand(selecdCommand, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Resultaat.DocentId = reader.GetString(0);
                        Resultaat.Wachtwoord = reader.GetString(1);
                        Resultaat.Naam = reader.GetString(2);
                        Resultaat.VakId = reader.GetString(3);
                        Resultaat.Omschrijving = reader.GetString(4);
                        Resultaat.Mentor = "Nee";
                        if (reader.GetInt16(5) == 1)
                            Resultaat.Mentor = "Ja";
                    }
                }
                return Resultaat;
            }

        }

        public static SessionToken Login(LogonRequest LoginGegevens)
        {
            SessionToken Resultaat = new SessionToken();
            try
            {

                using (var connection = new MySqlConnection(ConnectieString))
                {
                    //
                    // Tabel en veld bepalen waarin je moet zoeken
                    //
                    connection.Open();
                    bool IsDocent = false;
                    if (LoginGegevens.Soort.ToUpper().Contains("DOC"))
                        IsDocent = true;

                    var sqlCommand = $"SELECT LeerlingId, Wachtwoord, Naam, Klas, MentorId FROM Leerlingen WHERE LeerlingId = '{LoginGegevens.ID}' ";
                    if (IsDocent)
                        sqlCommand = $"SELECT DocentId, Wachtwoord, Naam, IsMentor FROM Docenten WHERE DocentId = '{LoginGegevens.ID}' ";

                    using var command = new MySqlCommand(sqlCommand, connection);
                    using MySqlDataReader reader = command.ExecuteReader();
                    {
                        //
                        // Controleer of er iets gevonden is
                        //
                        if (reader.HasRows)
                        {
                            reader.Read();
                            //
                            // Wachtwoord controleren
                            //
                            var wachtwoord = reader.GetValue(1).ToString();
                            if (wachtwoord == LoginGegevens.Wachtwoord)
                            {
                                Resultaat.ok = true;
                                Resultaat.Error = "";
                                Resultaat.Token = Guid.NewGuid().ToString();
                                Resultaat.ExpiresAt = DateTime.Now.AddHours(1);
                                Resultaat.Id = reader.GetValue(0).ToString();
                                Resultaat.Naam = reader.GetValue(2).ToString();
                                if (IsDocent)
                                {
                                    Resultaat.IsMentor = (int?)reader.GetValue(3);
                                    Resultaat.Klas = "";
                                    Resultaat.Mentor = "";
                                }
                                else
                                {
                                    Resultaat.Klas = reader.GetValue(3).ToString();
                                    Resultaat.Mentor = reader.GetValue(4).ToString();
                                    Resultaat.IsMentor = 0;
                                }
                            }
                            else
                            {
                                throw new Exception("Foutieve inloggegevens");
                            }
                        }
                        else
                        {
                            throw new Exception("Foutieve inloggegevens");
                        }
                    }

                }

            }
            catch (InlogException e)
            {
                //
                // Als er iets fout is gegaan de melding en status zetten
                //

                Resultaat.ok = false;
                Resultaat.Error = $"Foutieve inloggegevens";
            }
            catch (Exception e)
            {
                //
                // technische fouten niet tonen
                //
                Resultaat.ok = false;
                Resultaat.Error = $"Foutieve inloggegevens of technisch probleem";
            }

            return Resultaat;

        }
    }
}
