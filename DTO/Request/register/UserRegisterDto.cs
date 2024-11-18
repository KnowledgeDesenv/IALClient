using System.ComponentModel.DataAnnotations;

namespace IALClient.DTO.Request.register;

public record UserRegisterDto(

    [Required] string Email,
    [Required] string Password,
    [Required] string Name

);
