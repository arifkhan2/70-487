using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Library
{
    public class TestService : ITestService
    {

        AnswerDetails ITestService.GetAnswerDetails(int questionNumber)
        {
            AnswerDetails CurrentDetails = new AnswerDetails();
            return CurrentDetails;
        }

        AnswerSet[] ITestService.GetQuestionAnswers(int questionNumber)
        {
            AnswerSet[] CurrentAnswers = null;
            return CurrentAnswers;
        }

        string ITestService.GetQuestionText(int questionNumber)
        {
            if ( questionNumber <= 0 )
            {
                String OutOfRangeMessage = "Question Ids must be a positive value greather than 0";
                IndexOutOfRangeException InvalidQuestionId = new IndexOutOfRangeException(OutOfRangeMessage);
            }
            String AnswerText = null;
            return AnswerText;
        }
        

        string[] ITestService.GetExamOutline(string examName)
        {
            String[] OutlineItems = null;
            return OutlineItems;
        }
    }
}
