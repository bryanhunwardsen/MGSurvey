namespace SurveyEngine.ObjectBase
{
    using System.Collections.Generic;

    /// <inheritdoc />
    public class Survey : ISurvey
    {
        /// <inheritdoc />
        public IEnumerable<ISurveyQuestion> SurveyQuestions { get; set ; }
    }
}