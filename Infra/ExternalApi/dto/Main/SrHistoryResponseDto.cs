namespace IALClient.Infra.ExternalApi.Dto.Main;

public record SrHistoryResponseDto(

    string JobNo,
    DateTime? JobDate,
    string JobSummary,
    string Category,
    string SubCategory,
    string ReferenceNo,
    string PolicyNo,
    string ContractNo,
    bool Warranty,
    bool ExtWar,
    bool SP,
    bool MP,
    bool FMC,
    bool Goodwill,
    bool Rust,
    bool Internal,
    DateTime? DateIn,
    DateTime? DateOut,
    bool VOR,
    string VIN,
    string Engine,
    string RegNo,
    int MileageIn,
    int MileageOut,
    string FuelIn,
    string FuelOut,
    string Contact,
    string Tel,
    string Cel,
    string Email,
    string ClaimNo,
    DateTime? ClaimDate,
    string InvoiceNo,
    DateTime? InvoiceDate

);

