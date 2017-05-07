using System;
using System.Collections.Generic;

namespace LernQuiz
{
    interface ICanLogErrors
    {
        void LogWarning(String warning);
        void LogError(String error);
    }
}
