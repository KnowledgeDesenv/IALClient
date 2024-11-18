using System.ComponentModel.DataAnnotations;

namespace IALClient.DTO.Request;

public record VerifyCodeDto (
    [Required] string Email,
    [Required] string Code
);

