using Boilerplate.Application.Commands.AddUser;
using Boilerplate.Application.Commands.DeleteUser;
using Boilerplate.Application.Queries;
using Boilerplate.Application.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace Boilerplate.WebApi.Controllers;

[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersQueries _usersQueries;
    private readonly IDeleteUser _deleteUser;
    private readonly IAddUser _addUser;

    public UsersController(IUsersQueries usersQueries, IDeleteUser deleteUser, IAddUser addUser)
    {
        _usersQueries = usersQueries;
        _deleteUser = deleteUser;
        _addUser = addUser;
    }

    /// <summary>
    /// Get all users
    /// </summary>
    [HttpGet(Name = "GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        Collection<UserResult> users = await _usersQueries.GetAllUsers();

        if (users == null)
        {
            return new NoContentResult();
        }

        return Ok(users);
    }


    /// <summary>
    /// Delete user
    /// </summary>
    [HttpDelete(Name = "DeleteUser")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var userId = await _deleteUser.Execute(new Guid(id));

        if (userId == Guid.Empty)
        {
            return new BadRequestResult();
        }

        return Ok(userId);
    }

    // <summary>
    // Delete user
    // </summary>
    [HttpPost(Name = "AddUser")]
    public async Task<IActionResult> AddUser([FromBody] AddUserCommand addUserCommand)
    {
        if (ModelState.IsValid)
        {

            var userId = await _addUser.Execute(addUserCommand);

            if (userId == Guid.Empty)
            {
                return new BadRequestResult();
            }

            return Ok(userId);
        }

        return BadRequest();
    }
}