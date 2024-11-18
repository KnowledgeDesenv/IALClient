using System.ComponentModel.DataAnnotations;

namespace IALClient.DTO.Request.update;

public record UserVehicleUpdateDto(

    [StringLength(50)][Required] string Key,
    [Required] string UserVehicleType,
    long? PermissionLevelId

);
