using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyEngine.Models;
using SurveyEngine.ObjectBase;

namespace SurveyEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController_SelfReferential : ControllerBase
    {
        private readonly SurveyContext _context;

        private readonly SurveyEngine.ObjectBase.ISurvey _survey;

        public SurveyController_SelfReferential(ISurveyDefinition surveyDef)
        {
            //_context = context;
            _survey = surveyDef.SelectedSurvey;// as SurveyEngine.ObjectBase.Survey;
        }

        // GET: api/SurveyController_SelfReferential
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurveyEngine.ObjectBase.IQuestion>>> StartSurvey()
        {
            var node = _survey.SurveyQuestions.First<ISurveyQuestion>(q => q.IsFirstQuestion).Questions;
            return new ActionResult<IEnumerable<SurveyEngine.ObjectBase.IQuestion>>(node);
            //return await _context.TodoItems.ToListAsync();
        }

        // GET: api/SurveyController_SelfReferential/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SurveyEngine.ObjectBase.IQuestion>>> NextQuestiion(string id)
        {
            if (!Guid.TryParse(id, out Guid nodeGuid))
            {
                return BadRequest("Invalid Survey Node Guid");
            }
            var node = _survey.SurveyQuestions.FirstOrDefault<ISurveyQuestion>(q => q.SurveyQuestionId == nodeGuid);
            if (node is null)
            {
                return NotFound("Survey Node Guid Not Found");
            }
            return new ActionResult<IEnumerable<SurveyEngine.ObjectBase.IQuestion>>(node.Questions);
        }

        #region Overflow

        //// PUT: api/SurveyController_SelfReferential/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id:guid}")]
        //public async Task<IActionResult> PutSurvey(long id, SurveyEngine.Models.Survey survey)
        //{
        //    if (id != survey.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(survey).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SurveyExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/SurveyController_SelfReferential
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<SurveyEngine.Models.Survey>> PostSurvey(SurveyEngine.Models.Survey survey)
        //{
        //    _context.TodoItems.Add(survey);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSurvey", new { id = survey.Id }, survey);
        //}

        //// DELETE: api/SurveyController_SelfReferential/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteSurvey(long id)
        //{
        //    var survey = await _context.TodoItems.FindAsync(id);
        //    if (survey == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TodoItems.Remove(survey);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool SurveyExists(long id)
        //{
        //    return _context.TodoItems.Any(e => e.Id == id);
        //}

        #endregion
    }
}
