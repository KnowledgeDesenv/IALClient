namespace IALClient.Infra.ExternalApi.Dto.Main;

public record VehicleMDto
(
    string MmCode,
    string Make,
    string ModelCD,
    string Model,
    string Color,
    string Fuel,
    int Transmiss,
    int NetPower,
    int EngineDisp,
    int NoCyl,
    string Vin,
    string Engine,
    int Tare,
    int Gvm,
    int Gcm,
    int Length,
    int Height,
    int Width,
    string DealerCode,
    string DealerName,
    DateTime ReleasedD,
    string RegNo,
    DateTime LastSrv,
    string LastSrvRef,
    int Mileage,
    int SSchedule,
    int SScheduleN,
    string AppKey,
    string? StkNo
);
