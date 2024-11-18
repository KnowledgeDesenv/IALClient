using System.ComponentModel.DataAnnotations;

namespace IALClient.DTO.Request.update;

public record UserVehicleStatusUpdateDto(

    [StringLength(50)][Required] string Status

);

