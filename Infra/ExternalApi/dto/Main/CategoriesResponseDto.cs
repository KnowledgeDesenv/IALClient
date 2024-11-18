
namespace IALClient.Infra.ExternalApi.Dto.Main;

public record CategoriesResponseDto(
        bool Active,
        string Code,
        string Ref,
        int Rank,
        string Desc,
        string Category,
        string Type
);

