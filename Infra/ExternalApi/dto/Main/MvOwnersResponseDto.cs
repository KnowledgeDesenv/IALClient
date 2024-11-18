namespace IALClient.Infra.ExternalApi.Dto.Main;

public record MvOwnersResponseDto(
    string Vin,
    string InvNo,
    string OwnerName,
    string Cel,
    string Email,
    string PCode,
    string Country,
    string Title,
    string Name,
    string Surname,
    string City,
    string CelC,
    string CelA,
    string AppKey,
    string DealerName,
    string Gender,
    string Race,
    DateTime DateBirth,
    string DealerCode,
    DateTime DateSale,
    string SalesMan,
    DateTime CurDate,
    string OwnerID,
    string Province
);

