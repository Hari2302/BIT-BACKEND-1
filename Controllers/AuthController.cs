using FetchAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FetchAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Registration registration)
        
        {
            if (_context.Registrations.Any(r => r.Email == registration.Email))
                return BadRequest("User already exists.");

            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();
            return Ok("Registration successful");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login login)
        {
            var user = _context.Registrations.FirstOrDefault(r => r.Email == login.Email && r.Password == login.Password);

            if (user == null)
                return Unauthorized("Invalid email or password");

            return Ok("Login successful");
        }
      


        [HttpPost("Intern")]
        public async Task<IActionResult> Intern(Intern intern)
        {
            if(_context.Interns.Any(r=>r.Email == intern.Email))
            {
                return BadRequest("Already Email Present");

            }
            else
            {
                
                _context.Interns.Add(intern);
                await _context.SaveChangesAsync();
                return Ok("Added Successfull");
            }
        }

        [HttpPost("Fresher")]
        public async Task<IActionResult> Fresher (Fresher fresher)
        {

            if (_context.Freshers.Any(r => r.Email == fresher.Email))
            {
                return BadRequest("Already Email Present");
              

            }
            else
            {
                _context.Freshers.Add(fresher);
                await _context.SaveChangesAsync();
                return Ok("Added Successfull");
            }

        }
        [HttpPost("Experience")]
        public async Task<IActionResult> Experience(Experience exp)
        {

            if (_context.Experiencer.Any(r => r.Email == exp.Email))
            {
                return BadRequest("Already Email Present");

            }
            else
            {
               
                _context.Experiencer.Add(exp);
                await _context.SaveChangesAsync();
                return Ok("Added Successfull");
            }

        }

        [HttpGet("Interns")]
        public async Task<IActionResult> GetInterns()
        {
            var interns = await _context.Interns.ToListAsync();
            return Ok(interns); // Return the list of interns
        }

        [HttpGet("Freshers")]
        public async Task<IActionResult> GetFreshers()
        {
            var freshers = await _context.Freshers.ToListAsync();
            return Ok(freshers); // Return the list of freshers
        }

        [HttpGet("Experiences")]
        public async Task<IActionResult> GetExperiences()
        {
            var experiences = await _context.Experiencer.ToListAsync();
            return Ok(experiences); // Return the list of experienced employees
        }


        [HttpGet("Application")]
        public async Task<IActionResult> GetApplication()
        {
            var app = await _context.Applications.ToListAsync();
            return Ok(app); // Return the list of experienced employees
        }

        // Edit Intern (PUT)
        [HttpPut("Intern/{id}")]
        public async Task<IActionResult> EditIntern(int id, Intern intern)
        {
            var existingIntern = await _context.Interns.FindAsync(id);
            if (existingIntern == null)
            {
                return NotFound("Intern not found.");
            }

            existingIntern.Name = intern.Name;
            existingIntern.Email = intern.Email;
            existingIntern.Phone = intern.Phone;
            existingIntern.Role = intern.Role;

            _context.Interns.Update(existingIntern);
            await _context.SaveChangesAsync();
            return Ok("Intern updated successfully.");
        }

        // Delete Intern (DELETE)
        [HttpDelete("Intern/{id}")]
        public async Task<IActionResult> DeleteIntern(int id)
        {
            var intern = await _context.Interns.FindAsync(id);
            if (intern == null)
            {
                return NotFound("Intern not found.");
            }

            _context.Interns.Remove(intern);
            await _context.SaveChangesAsync();
            return Ok("Intern deleted successfully.");
        }

        // Similarly, you can implement the same for Fresher and Experience models

        // Edit Fresher (PUT)
        [HttpPut("Fresher/{id}")]
        public async Task<IActionResult> EditFresher(int id, Fresher fresher)
        {
            var existingFresher = await _context.Freshers.FindAsync(id);
            if (existingFresher == null)
            {
                return NotFound("Fresher not found.");
            }

            existingFresher.Name = fresher.Name;
            existingFresher.Email = fresher.Email;
            existingFresher.Phone = fresher.Phone;
            existingFresher.Role = fresher.Role;
            existingFresher.Salary = fresher.Salary;

            _context.Freshers.Update(existingFresher);
            await _context.SaveChangesAsync();
            return Ok("Fresher updated successfully.");
        }

        // Delete Fresher (DELETE)
        [HttpDelete("Fresher/{id}")]
        public async Task<IActionResult> DeleteFresher(int id)
        {
            var fresher = await _context.Freshers.FindAsync(id);
            if (fresher == null)
            {
                return NotFound("Fresher not found.");
            }

            _context.Freshers.Remove(fresher);
            await _context.SaveChangesAsync();
            return Ok("Fresher deleted successfully.");
        }

        // Edit Experience (PUT)
        [HttpPut("Experience/{id}")]
        public async Task<IActionResult> EditExperience(int id, Experience exp)
        {
            var existingExp = await _context.Experiencer.FindAsync(id);
            if (existingExp == null)
            {
                return NotFound("Experience not found.");
            }

            existingExp.Name = exp.Name;
            existingExp.Email = exp.Email;
            existingExp.Phone = exp.Phone;
            existingExp.Role = exp.Role;
            existingExp.Salary = exp.Salary;
            

            _context.Experiencer.Update(existingExp);
            await _context.SaveChangesAsync();
            return Ok("Experience updated successfully.");
        }

        // Delete Experience (DELETE)
        [HttpDelete("Experience/{id}")]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            var experience = await _context.Experiencer.FindAsync(id);
            if (experience == null)
            {
                return NotFound("Experience not found.");
            }

            _context.Experiencer.Remove(experience);
            await _context.SaveChangesAsync();
            return Ok("Experience deleted successfully.");
        }

        //----------------------------------------Carrers
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitApplication([FromBody] ApplicationFormModel application)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(application.Resume))
                {
                    return BadRequest("Resume link is required.");
                }

                // Save application to the database
                _context.Applications.Add(application);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Application submitted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        // Delete Application Form
        [HttpDelete("Applications/{email}")]
        public async Task<IActionResult> DeleteApplication(string email)
        {
            var app = await _context.Applications.FirstOrDefaultAsync(a => a.Email == email);
            if (app == null)
            {
                return NotFound("Application not found.");
            }

            _context.Applications.Remove(app);
            await _context.SaveChangesAsync();
            return Ok("Application deleted successfully.");
        }




        // Update Fresher (PUT)
        [HttpPut("UpdateStatus/{email}/{status}")]
        public async Task<IActionResult> UpdateStatus(string email,string status)
        {
            var existingApp = await _context.Applications.FindAsync(email);
            if (existingApp == null)
            {
                return NotFound("Application not found.");
            }
            existingApp.Status = status;
           

            _context.Applications.Update(existingApp);
            await _context.SaveChangesAsync();
            return Ok(" updated successfully.");
        }
    }




}


