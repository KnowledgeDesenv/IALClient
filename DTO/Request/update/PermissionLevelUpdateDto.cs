using System.ComponentModel.DataAnnotations;

namespace IALClient.DTO.Request.update;

public record PermissionLevelUpdateDto(

    [StringLength(50)][Required] string Code,

    [StringLength(255)][Required] string Description

);

