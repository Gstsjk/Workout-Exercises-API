using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Workout_Exercises_API.Models;

namespace Workout_Exercises_API.ExerciseComponent
{
    [Route("api/[controller]")]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _service;

        public ExerciseController(IExerciseService service)

        {

            _service = service;

        }

        [HttpGet]
        public async Task<IEnumerable<ExerciseResponseDto>> GetExercises()
        {

           return await _service.Get();

        }

        [HttpGet("{exId}")]
        public async Task<ActionResult<ExerciseResponseDto>> GetExercise(int exId)
        {
            var exercise = await _service.Get(exId);
            if(exercise == null) 
            {
                return NotFound("Id not found.");
            }
            return exercise;

        }

        [HttpGet("Search/{name}")]
        public async Task<IEnumerable<ExerciseResponseDto>> GetExercisesByName(string name)
        {

            return await _service.Get(name);

        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> PostExercise([FromBody] ExerciseRequestDto exerciseRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newExercise = await _service.Create(exerciseRequestDto);
            return CreatedAtAction(nameof(PostExercise), newExercise);
        }

        [HttpPut]
        public async Task<ActionResult> PutExercise([FromBody] Exercise exercise)
        {   
            var updatedExercise =  await _service.Update(exercise);

            if (updatedExercise == null)
                return BadRequest("Id not valid");

            return NoContent();
        }

        [HttpDelete("{exId}")]
        public async Task<ActionResult> Delete(int exId)
        {
            var exerciseToDelete = await _service.Get(exId);
            if (exerciseToDelete == null)
                return NotFound();

            await _service.Delete(exerciseToDelete.Id);
            return NoContent();

        }

    }

}

