using LibraryApi.Data;
using LibraryApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LibraryDbContext _dbContext;

        public UserController(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] GeneralUser user)
        {
            try
            {
                if (!user.Membership_id.IsNullOrEmpty())
                {
                    Member newMember = new()
                    {
                        UserID = user.UserID,
                        Name = user.Name,
                        Email = user.Email,
                        Phone_Number = user.Phone_Number,
                        Password = user.Password,
                        CreatedAt = user.CreatedAt,
                        Membership_id = user.Membership_id,
                        Address = user.Address,
                        Borrow_Limit = user.Borrow_Limit,
                        Status = user.Status,
                    };
                    //this will also save to the User table since the Member is a user
                    await _dbContext.Members.AddAsync(newMember);
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                else if (!user.Shift.IsNullOrEmpty())
                {
                    Librarian librarian = new()
                    {
                        UserID = user.UserID,
                        Name = user.Name,
                        Email = user.Email,
                        Phone_Number = user.Phone_Number,
                        Password = user.Password,
                        CreatedAt = user.CreatedAt,
                        Shift = user.Shift,
                        HiredDate = user.HiredDate
                    };
                    //this will also save to the User table since Librarian is a user
                    await _dbContext.Librarians.AddAsync(librarian);
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    Manager manager = new()
                    {
                        UserID = user.UserID,
                        Name = user.Name,
                        Email = user.Email,
                        Phone_Number = user.Phone_Number,
                        Password = user.Password,
                        CreatedAt = user.CreatedAt,
                        OfficeLocation = user.OfficeLocation
                    };
                    //this will save tp the User table also since the Manager is also a user
                    await _dbContext.Managers.AddAsync(manager);
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        //Action result tells show that the method return an HttpResponse
        public async Task<ActionResult> Remove(int id)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(id);
                if (user == null)
                    return BadRequest();

                if (user is Member member)
                {
                    _dbContext.Members.Remove(member);
                    _dbContext.Users.Remove(user);
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                else if (user is Librarian librarian)
                {
                    _dbContext.Librarians.Remove(librarian);
                    _dbContext.Users.Remove(user);
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                else if (user is Manager manager)
                {
                    _dbContext.Managers.Remove(manager);
                    _dbContext.Users.Remove(user);
                    await _dbContext.SaveChangesAsync();
                    return Ok();

                }
                //if the user found doesnt match eny of the above that means there is a problem
               return BadRequest();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            try
            {
                return await _dbContext.Users.ToListAsync();//returning a list of Users
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        //asyk Task is advantegeous for efficient thread usage,the sever can handle thousand requests
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(id);
                if (user == null)
                    return BadRequest();

                if (user is Librarian librarian)
                    return Ok(librarian);
                if (user is Member member)
                    return Ok(member);
                if (user is Manager manager)
                    return Ok(manager);

                return BadRequest() ;
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdadteUser(int id, [FromBody]GeneralUser Guser)
        {
            try
            {
                Member user = await _dbContext.Members.FindAsync(id);
                if (user != null)
                {
                    user.Name = Guser.Name;
                    user.Phone_Number = Guser.Phone_Number;
                    user.Email = Guser.Email;
                    user.Phone_Number = Guser.Phone_Number;
                    user.Address = Guser.Address;
                    user.Membership_id = Guser.Membership_id;
                    user.Borrow_Limit = Guser.Borrow_Limit;
                    user.CreatedAt = Guser.CreatedAt;
                    user.Password= Guser.Password;
                }
                _dbContext.Members.Update(user);
                await _dbContext.SaveChangesAsync();
                return Ok("Member details updated successfully");
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        }
    
    }
