namespace SurveyEngine.ObjectBase
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// List of survey questions where selection is the response
    /// </summary>
    public interface ISurveyQuestion
    {
        /// <summary>
        /// Indicate if question node is first to be displayed
        /// </summary>
        public bool IsFirstQuestion { get; set; }

        /// <summary>
        ///  Unique ID for the question
        /// </summary>
        public Guid SurveyQuestionId { get; set; }

        /// <summary>
        /// List of self referential questions (selection equates to the answer)
        /// </summary>
        public IEnumerable<IQuestion> Questions { get; set; }
    }
}
