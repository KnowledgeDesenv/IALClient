namespace IALClient.Infra.ExternalApi.Dto.FreeTable;

public record MvTransResponseDto(
    bool Active,
    string Code,
    string Desc,
    string Notes,
    string Comments,
    string UserId,
    DateTime CDate,
    string Guid
);
