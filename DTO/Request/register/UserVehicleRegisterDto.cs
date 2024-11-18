using System;
using System.ComponentModel.DataAnnotations;

namespace IALClient.DTO.Request.register;

public record UserVehicleRegisterDto(

    [StringLength(50)][Required] string Key,
    [Required] string UserVehicleType

);

