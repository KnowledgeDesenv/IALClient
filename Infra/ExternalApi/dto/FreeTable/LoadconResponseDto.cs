namespace IALClient.Infra.ExternalApi.Dto.FreeTable;

public record LoadconResponseDto(
    bool Active,
    string Code,
    string Desc
);
