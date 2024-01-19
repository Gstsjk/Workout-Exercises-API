using Microsoft.AspNetCore.Mvc;
using Workout_Exercises_API.ExerciseComponent;
using Workout_Exercises_API.Models;

namespace Workout_Exercises_API.UserComponent
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)

        {

            _service = service;

        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.Create(user);
            return CreatedAtAction(nameof(PostUser), user);
        }

        //[HttpPut]
        //public async Task<ActionResult> PutExercise([FromBody] Exercise exercise)
        //{
        //    var updatedExercise = await _service.Update(exercise);

        //    if (updatedExercise == null)
        //        return BadRequest("Id not valid");

        //    return NoContent();
        //}

        //[HttpDelete("{exId}")]
        //public async Task<ActionResult> Delete(int exId)
        //{
        //    var exerciseToDelete = await _service.Get(exId);
        //    if (exerciseToDelete == null)
        //        return NotFound();

        //    await _service.Delete(exerciseToDelete.Id);
        //    return NoContent();

        //}

    }
}
