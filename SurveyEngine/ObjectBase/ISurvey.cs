using System.Collections.Generic;

namespace SurveyEngine.ObjectBase
{
    /// <summary>
    /// Full tree of question repsone data and mapping
    /// </summary>
    public interface ISurvey
    {
        /// <summary>
        /// List of survery question response nodes
        /// </summary>
        public IEnumerable<ISurveyQuestion> SurveyQuestions { get; set; }
    }
}
