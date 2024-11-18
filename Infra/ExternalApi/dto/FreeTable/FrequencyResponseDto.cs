namespace IALClient.Infra.ExternalApi.Dto.FreeTable;

public record FrequencyResponseDto(
    bool Active,
    string Code,
    string Desc
);
