using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.Commands.AddUser;

public record AddUserCommand
{
    [Required]
    [StringLength(250)]
    public string Name { get; set; }
}
