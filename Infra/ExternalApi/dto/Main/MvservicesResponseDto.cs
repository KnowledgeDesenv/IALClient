namespace IALClient.Infra.ExternalApi.dto.Main;

public record MvservicesResponseDto(

  bool Active,

  string? Modelcd,

  string? Model,

  string? Lseries,

  string? Series,

  int? Regyear,

  int? Mileage,

  string? Ref,

  string? Code,

  string? Desc,

  string? Category,

  string? Subcat,

  int? Qty,

  int? Retail,

  string? Notes,

  string? Comments,

  string? Userid,

  DateTime? Cdate,

  string? Guid,

  string? Sschedule,

  bool Altcodes,

  string? Descript

);
