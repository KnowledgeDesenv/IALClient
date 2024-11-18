namespace IALClient.Infra.ExternalApi.Dto.FreeTable;

public record EngineconResponseDto(
    bool Active,
    string Code,
    string Desc
);
