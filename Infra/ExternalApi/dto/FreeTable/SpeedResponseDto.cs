namespace IALClient.Infra.ExternalApi.Dto.FreeTable;

public record SpeedResponseDto(
    bool Active,
    string Code,
    string Desc
);
