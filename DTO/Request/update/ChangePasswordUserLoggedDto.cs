using System.ComponentModel.DataAnnotations;

namespace IALClient.DTO.Request.update;

public record ChangePasswordUserLoggedDto(
    [Required] string NewPassword
);

