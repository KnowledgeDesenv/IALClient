using System.ComponentModel.DataAnnotations;

namespace IALClient.DTO.Request.register;

public record UserVehicleStatusRegisterDto (

    [StringLength(50)][Required] string Status

);

