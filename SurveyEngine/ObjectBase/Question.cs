namespace SurveyEngine.ObjectBase
{
    using System;

    /// <inheritdoc />
    public class Question : IQuestion
    {
        /// <inheritdoc />
        public Guid QuestionId { get; set; }
        /// <inheritdoc />
        public Guid ResponseMapping { get; set; }
        /// <inheritdoc />
        public string QuestionText { get; set; }
    }
}
