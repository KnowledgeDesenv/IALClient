using System.ComponentModel.DataAnnotations;

namespace IALClient.DTO.Request.register;

public record PermissionLevelRegisterDto(

    [StringLength(50)][Required] string Code,

    [StringLength(255)][Required] string Description
);


