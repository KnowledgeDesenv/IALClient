using System.ComponentModel.DataAnnotations;

namespace IALClient.DTO.Request.register;

public record ConfigRegisterDto(



    [StringLength(255)][Required] string ApiMapKey,

    [StringLength(255)][Required] string ApiURL,

    [StringLength(50)][Required] string ApiUser,

    [StringLength(100)][Required] string ApiPassword

);




