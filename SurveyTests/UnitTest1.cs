using Microsoft.AspNetCore.Mvc;
using Moq;
using SurveyEngine.Controllers;
using SurveyEngine.Models;
using SurveyEngine.ObjectBase;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SurveyTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestControllerStart()
        {
            // Could use test setup instead
            // Arrange
            var SurveyDB = new Mock<SurveyEngine.Models.SurveyContext>();
            var SurveyDef = new Mock<ISurveyDefinition>();
            SurveyDef.SetupGet(m => m.SelectedSurvey).Returns(GetTestSurvey());
            SurveyController_SelfReferential controller = new SurveyController_SelfReferential(SurveyDef.Object);

            // Act
            var response = controller.StartSurvey();

            
            // Assert
            Assert.NotNull(response);
            

            //Assert.True(response is OkObjectResult);
            //Assert.True((response as OkObjectResult).StatusCode == 200);
            var result = response.Result;
            var value = result.Value;

            Assert.True(value is List<IQuestion>);            
            Assert.True((value as List<IQuestion>).Count == 2);
            Assert.True((value.AsQueryable().FirstOrDefault(q => q.QuestionText == "A") != null));
            Assert.True((value.AsQueryable().FirstOrDefault(q => q.QuestionText == "B") != null));
            Assert.True((value.AsQueryable().FirstOrDefault(q => q.QuestionId == Guid.Parse("6ebc2e0e-8794-4ecf-923a-c65fe1aeb650")) != null));
            Assert.True((value.AsQueryable().FirstOrDefault(q => q.ResponseMapping == Guid.Parse("765864e0-a569-4fb8-9b9d-11603a49c8a9")) != null));
        }

        [Fact]
        public void TestControllerNextQuestion()
        {
            // Could use test setup instead
            // Arrange
            var SurveyDB = new Mock<SurveyEngine.Models.SurveyContext>();
            var SurveyDef = new Mock<ISurveyDefinition>();
            SurveyDef.SetupGet(m => m.SelectedSurvey).Returns(GetTestSurvey());
            SurveyController_SelfReferential controller = new SurveyController_SelfReferential(SurveyDef.Object);

            // Act
            var result = controller.NextQuestiion("765864e0-a569-4fb8-9b9d-11603a49c8a9").Result.Value;

            // Assert
            Assert.NotNull(result);
            Assert.True(result is List<IQuestion>);
            Assert.True((result as List<IQuestion>).Count == 2);
            Assert.True((result.AsQueryable().FirstOrDefault(q => q.QuestionText == "E") != null));
            Assert.True((result.AsQueryable().FirstOrDefault(q => q.QuestionText == "F") != null));
            Assert.True((result.AsQueryable().FirstOrDefault(q => q.QuestionId == Guid.Parse("d68858cd-53a4-4422-b2a6-55f3237a2ace")) != null));
            Assert.True((result.AsQueryable().FirstOrDefault(q => q.ResponseMapping == Guid.Parse("00000000-0000-0000-0000-000000000000")) != null));
        }


        [Fact]
        public void TestControllerNextQuestionInvalidId()
        {
            // Could use test setup instead
            // Arrange
            var SurveyDB = new Mock<SurveyEngine.Models.SurveyContext>();
            var SurveyDef = new Mock<ISurveyDefinition>();
            SurveyDef.SetupGet(m => m.SelectedSurvey).Returns(GetTestSurvey());
            SurveyController_SelfReferential controller = new SurveyController_SelfReferential(SurveyDef.Object);

            // Act
            var resultInvalid = controller.NextQuestiion("765864e0-a569-4fb8-9b9d-INVALID").Result;
            Assert.NotNull(resultInvalid);
            Assert.True(resultInvalid.Result is BadRequestObjectResult);
            Assert.True((resultInvalid.Result as BadRequestObjectResult).StatusCode == 400);
            Assert.True((resultInvalid.Result as BadRequestObjectResult).Value == "Invalid Survey Node Guid");

            var resultNotFound = controller.NextQuestiion("765864e0-0000-0000-0000-11603a49c8a9").Result;
            Assert.NotNull(resultNotFound);
            Assert.True(resultNotFound.Result is NotFoundObjectResult);
            Assert.True((resultNotFound.Result as NotFoundObjectResult).StatusCode == 404);
            Assert.True((resultNotFound.Result as NotFoundObjectResult).Value == "Survey Node Guid Not Found");
        }

        private SurveyEngine.ObjectBase.Survey GetTestSurvey()
        {
            return new SurveyEngine.ObjectBase.Survey()
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
        }
    }
}
