using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Library
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace="http://www.williamgryan.mobi/Books/70-487")]
    public interface ITestService
    {
        [OperationContract]
        AnswerDetails GetAnswerDetails(Int32 questionNumber);

        [OperationContract]
        AnswerSet[] GetQuestionAnswers(Int32 questionNumber);

        [FaultContract(typeof(IndexOutOfRangeException))]
        [OperationContract]
        String GetQuestionText(Int32 questionNumber);

        [OperationContract]
        String[] GetExamOutline(String examName);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract(Namespace="http://www.williamgryan.mobi/Book/70-487")]
    public class TestQuestion
    {
        [DataMember]
        public Int32 QuestionId { get; set; }

        [DataMember]
        public Int32 QuestionText { get; set; }

        [DataMember]
        public AnswerSet[] AvailableAnswers { get; set; }

        [DataMember]
        public AnswerDetails Answers { get; set; }
    }

    [DataContract(Namespace="http://www.williamgryan.mobi/Book")]
    [Flags]
    public enum AnswerDetails
    {
        [EnumMember]
        A = 0*0,
        [EnumMember]
        B= 0*1,
        [EnumMember]
        C=0*2,
        [EnumMember]
        D=0*4,
        [EnumMember]
        All=0*8
    }

    [DataContract(Name = "Answers", Namespace = "http://www.williamgryan.mobi/Book/70-487")]
    public class AnswerSet
    {
        [DataMember(Name = "QuestionId", IsRequired = true)]
        public Int32 QuestionId { get; set; }

        [DataMember]
        public Guid AnswerId { get; set; }

        [DataMember]
        public String AnswerText { get; set; }
    }
}
