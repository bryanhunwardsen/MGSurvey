using SurveyEngine.ObjectBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyEngine.Models
{
    public class SurveyDefinition : ISurveyDefinition
    {
        private ISurvey testSurvey = new SurveyEngine.ObjectBase.Survey()
        {
            SurveyQuestions = new List<ISurveyQuestion>()
            {
                new SurveyQuestion()
                {
                    IsFirstQuestion = false,
                    SurveyQuestionId = Guid.Parse("1efa6313-9806-4408-a596-12d762bff0e5"),
                    Questions = new List<IQuestion>()
                    {
                        new Question() { QuestionId = Guid.Parse("082fce4c-08cf-4cca-bf41-309d83e435e0"), ResponseMapping = Guid.Parse("00000000-0000-0000-0000-000000000000"), QuestionText = "C"},
                        new Question() { QuestionId = Guid.Parse("59072ebc-5bb5-4907-96f6-23a8def7889a"), ResponseMapping = Guid.Parse("00000000-0000-0000-0000-000000000000"), QuestionText = "D"}
                    }
                },
                new SurveyQuestion()
                {
                    IsFirstQuestion = true,
                    SurveyQuestionId = Guid.Parse("4a388bba-3b85-4870-905b-8bef55959c4a"),
                    Questions = new List<IQuestion>()
                    {
                        new Question() { QuestionId = Guid.Parse("6ebc2e0e-8794-4ecf-923a-c65fe1aeb650"), ResponseMapping = Guid.Parse("1efa6313-9806-4408-a596-12d762bff0e5"), QuestionText = "A"},
                        new Question() { QuestionId = Guid.Parse("8cd6f576-67ce-403a-83c2-48772095e8df"), ResponseMapping = Guid.Parse("765864e0-a569-4fb8-9b9d-11603a49c8a9"), QuestionText = "B"}
                    }
                },
                new SurveyQuestion()
                {
                    IsFirstQuestion = false,
                    SurveyQuestionId = Guid.Parse("765864e0-a569-4fb8-9b9d-11603a49c8a9"),
                    Questions = new List<IQuestion>()
                    {
                        new Question() { QuestionId = Guid.Parse("07ef67e1-ef18-44dc-ba29-ed1c3309b2eb"), ResponseMapping = Guid.Parse("00000000-0000-0000-0000-000000000000"), QuestionText = "E"},
                        new Question() { QuestionId = Guid.Parse("d68858cd-53a4-4422-b2a6-55f3237a2ace"), ResponseMapping = Guid.Parse("00000000-0000-0000-0000-000000000000"), QuestionText = "F"}
                    }
                }
            }
        };
         
        public ISurvey SelectedSurvey { get { return testSurvey; } }
    }
}
