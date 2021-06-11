namespace SurveyEngine.ObjectBase
{
    using System;

    /// <summary>
    /// A Question
    /// </summary>
    public interface IQuestion
    {
        /// <summary>
        ///  Unique ID for the question
        /// </summary>
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Question selection response mapping
        /// Response mapping to all 0 guid indicates termination of question line
        /// </summary>
        public Guid ResponseMapping { get; set; }

        /// <summary>
        /// Question for the end user
        /// </summary>
        public string QuestionText { get; set; }
    }
}
