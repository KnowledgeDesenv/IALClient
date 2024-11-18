namespace IALClient.Infra.ExternalApi.Dto.FreeTable;

public record DirectionResponseDto(
    bool Active,
    string Code,
    string Desc
);
