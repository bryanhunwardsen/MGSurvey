namespace SurveyEngine.ObjectBase
{
    using System;
    using System.Collections.Generic;

    /// <inheritdoc />
    public class SurveyQuestion : ISurveyQuestion
    {
        /// <inheritdoc />
        public bool IsFirstQuestion { get; set; } = false;

        /// <inheritdoc />
        public Guid SurveyQuestionId { get; set; }

        /// <inheritdoc />
        public IEnumerable<IQuestion> Questions { get; set; }
    }
}
