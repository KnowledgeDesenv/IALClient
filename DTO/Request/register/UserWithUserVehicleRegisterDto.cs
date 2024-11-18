using System.ComponentModel.DataAnnotations;

namespace IALClient.DTO.Request.register;

public record UserWithUserVehicleRegisterDto(


   [Required] string Email,

   [Required] string Password,

   [Required] string Name,

   [StringLength(50)][Required] string Key,

   [Required] string UserVehicleType

);


