namespace SurveyEngine.Models
{
    using System;

    /// <summary>
    /// Storage of Survey Results
    /// </summary>
    public class Survey
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Users terminal selection
        /// </summary>
        public Guid UserFinalResult { get; set; }
    }
}
