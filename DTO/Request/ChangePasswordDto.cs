using System.ComponentModel.DataAnnotations;

namespace IALClient.DTO.Request;

public record ChangePasswordDto(
    [Required] string Email,
    [Required] string Code,
    [Required] string NewPassword
);

