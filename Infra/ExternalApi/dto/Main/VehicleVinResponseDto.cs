using Newtonsoft.Json;

namespace IALClient.Infra.ExternalApi.Dto.Main;

public record VehicleVinResponseDto(

   [JsonProperty("VIN")] // Não remover! Está deixando a propriedade maiuscula
   string VIN

 );