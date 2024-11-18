namespace IALClient.Infra.ExternalApi.Dto.FreeTable;

public record LanguagesResponseDto(
    bool Active,
    string Code,
    string Ref,
    string Desc,
    string Notes,
    string Comments,
    string UserId,
    DateTime CDate,
    string Guid
);
