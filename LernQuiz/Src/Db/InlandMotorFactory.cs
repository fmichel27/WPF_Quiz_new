using System;
using System.Data;
using System.Collections.Generic;

using LernQuiz.Db;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace LernQuiz.Db
{
	public class InlandMotorFactory : IEstablishQuestionnaires
	{
        string connectionString = "server=localhost;database=Binnenschifffahrt;Trusted_Connection=True;";       
        //private String  ConnectionString = "Server=carlaischmann.de;" + "Database=Binnenschifffahrt;" + "User ID=smoky;" + "Password=fghk32937fdg!2;" + "Pooling=false";

        public InlandMotorFactory ()
		{
		}

		public List<String> GetFragebogenIds() {
			List<String> fragebogenIds = new List<String>();

			String sqlCommand = 
				"SELECT DISTINCT FragebogenNr " +
				"FROM T_Fragebogen_unter_Maschine";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string frageBogenId = ((int)reader["FragebogenNr"]).ToString();
                    fragebogenIds.Add(frageBogenId);
                }
                reader.Close();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return fragebogenIds;
		}
			
		public Questionnaire GetFragebogen (String fragebogenID)
		{
			Questionnaire questionnaire;
			List<Question> questions = new List<Question> ();

			String sqlCommand = 
				"SELECT * " +
				"FROM T_SBF_Binnen " +
				"JOIN T_Fragebogen_unter_Maschine " +
				"ON T_SBF_Binnen.P_Id = T_Fragebogen_unter_Maschine.F_Id_SBF_Binnen  " +
				"AND T_Fragebogen_unter_Maschine.FragebogenNr = " + fragebogenID + ";";





            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int questionNumber = (int)reader["P_Id"];
                    string question = (string)reader["Frage"];
                    string answer1 = (string)reader["Antwort1"];
                    string answer2 = (string)reader["Antwort2"];
                    string answer3 = (string)reader["Antwort3"];
                    string answer4 = (string)reader["Antwort4"];
                    byte correctAnswer = (byte)reader["RichtigeAntwort"];

                    questions.Add(
                        new Question(
                            questionNumber,
                            question,
                            new List<Answer> {
                            new Answer(answer1, correctAnswer == 1),
                            new Answer(answer2, correctAnswer == 2),
                            new Answer(answer3, correctAnswer == 3),
                            new Answer(answer4, correctAnswer == 4)
                            }
                        )
                    );
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

			questionnaire = new Questionnaire (questions);
			return questionnaire;
		}

		private SqlDataReader query(String sqlCommand) {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return reader;
		}
	}
}
	  