
using IALClient.Infra.ExternalApi.Dto.Main;

namespace IALClient.Infra.ExternalApi.dto.Main;

public record SrHistoryWrapperResponseDto(

    string VIN,

    List<SrHistoryResponseDto> SrHistoryList

);
