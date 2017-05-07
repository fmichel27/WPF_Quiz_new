using System;
using System.Collections.Generic;



namespace LernQuiz.Db
{
    interface IEstablishQuestionnaires
    {
        Questionnaire GetFragebogen(string fragebogenID);
		List<string> GetFragebogenIds();
    }
}
