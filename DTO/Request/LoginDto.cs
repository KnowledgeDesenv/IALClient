using System.ComponentModel.DataAnnotations;

namespace IALClient.DTO.Request;

public record LoginDto(

    [Required] string Email, 
    [Required] string Password
    
);
