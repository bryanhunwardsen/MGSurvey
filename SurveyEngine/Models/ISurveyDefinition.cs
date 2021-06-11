using SurveyEngine.ObjectBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyEngine.Models
{
    public interface ISurveyDefinition
    {
        public ISurvey SelectedSurvey { get; }
    }
}
