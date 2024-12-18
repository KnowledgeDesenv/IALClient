﻿namespace IALClient.Infra.ExternalApi.dto.Main;

 public record VehiclesResponseDto(
     string StkNo,
     string MakeCd,
     string Make,
     string FactCd,
     string TradeCd,
     string ModelCd,
     string Model,
     string Derivative,
     string Series,
     string BaseCcode,
     string BaseColor,
     string ColorCd,
     string Color,
     string ColorIntCd,
     string ColorInt,
     string Vin,
     string Engine,
     int ManDate,
     int YearFReg,
     int Mileage,
     string Fuel,
     string Transmiss,
     int Cc,
     int Kw,
     int Tare,
     int Gvm,
     int Gcm,
     int Payload,
     int Kerb,
     int NoDoors,
     int NoWheels,
     int TankCap,
     int NatisModel,
     string NatisColor,
     string NatisReg,
     string SapNo,
     string RegNo,
     string KeyNo,
     string Sno,
     bool New,
     bool Used,
     bool Demo,
     bool Gray,
     bool Rebuilt,
     bool Srec,
     bool Lhd,
     bool Rhd,
     bool Dis,
     bool Rnd,
     bool Rst,
     bool Logbook,
     bool ServiceBook,
     bool Mp,
     bool Press,
     bool Private,
     bool Staff,
     bool Buyout,
     string BuyoutRef,
     string BuyoutU,
     DateTime BuyoutD,
     decimal BuyoutV,
     bool BBack,
     string BBackRef,
     string BBackStk,
     string BBackU,
     DateTime BBackD,
     decimal BBackV,
     bool TakeOn,
     string TakeOnRef,
     string TakeOnU,
     DateTime TakeOnD,
     decimal TakeOnV,
     decimal Acv,
     string AcvR,
     string AcvU,
     DateTime AcvD,
     bool TradeIn,
     string TradeInR,
     string TradeInVin,
     string TradeInStk,
     string TradeInU,
     DateTime TradeInD,
     decimal TradeInV,
     bool Rebate,
     string RebateR,
     string RebateU,
     DateTime RebateD,
     decimal RebateV,
     bool OAllow,
     string OAllowR,
     string OAllowU,
     DateTime OAllowD,
     decimal OAllowV,
     bool Disc,
     string DiscR,
     string DiscU,
     DateTime DiscD,
     decimal DiscV,
     bool Stlment,
     string StlmentR,
     string StlmentBC,
     string StlmentBN,
     string StlmentU,
     DateTime StlmentD,
     decimal StlmentV,
     DateTime DateIn,
     string UserIn,
     string RefIn,
     decimal FobP,
     string FobCur,
     decimal FobRate,
     decimal CostP,
     DateTime DateOut,
     string UserOut,
     string RefOut,
     decimal DealerP,
     decimal RetailP,
     decimal SellingP,
     bool DSale,
     bool PSale,
     bool TSale,
     bool Damaged,
     DateTime DamagedD,
     string DamagedU,
     decimal DamagedV,
     bool Repaired,
     string RepairedR,
     DateTime RepairedD,
     string RepairedU,
     decimal RepairedV,
     bool Refurbish,
     string RefurbishR,
     DateTime RefurbishD,
     string RefurbishU,
     decimal RefurbishV,
     bool Pdi,
     string PdiR,
     DateTime PdiD,
     string PdiU,
     decimal PdiV,
     bool Stolen,
     DateTime StolenD,
     string StolenU,
     decimal StolenV,
     bool Scrapped,
     DateTime ScrappedD,
     string ScrappedU,
     decimal ScrappedV,
     string SupplierCd,
     string SupplierRef,
     string Supplier,
     string DealerCd,
     string DealerRef,
     string Dealer,
     string ClientCd,
     string ClientRef,
     string Client,
     string Notes,
     string NotesExt,
     string Comments,
     string UserId,
     DateTime CDate,
     string Guid,
     bool Comp,
     string Category,
     string Group,
     string Company,
     string Branch,
     bool Oem,
     int TradeIns,
     decimal ExtraCosts,
     bool OnHold,
     DateTime OnHoldD,
     string OnHoldU,
     string Status,
     DateTime StatusD,
     string StatusU,
     decimal MinGp,
     decimal MaxDisc,
     decimal TradeP,
     bool OnHand,
     bool Sold,
     string DamagedR,
     string StolenR,
     string ScrappedR,
     bool Inv,
     DateTime InvD,
     string InvU,
     decimal DepositV,
     decimal TradeInsV,
     bool FirstPur,
     string PurposeC,
     string Purpose,
     string Spec,
     string Equipment,
     string PayType,
     string TransType,
     string DriveMode,
     bool Access,
     bool TowBar,
     bool NudgeBar,
     bool SideSteps,
     bool RollBar,
     bool SnGrab,
     bool Canopy,
     bool MagWheels,
     bool OAccess,
     bool StlmentP,
     string StlmentPU,
     DateTime StlmentPD,
     decimal StlmentPV,
     bool FPlan,
     string FPlanAC,
     string FPlanN,
     string FPlanR,
     DateTime FPlanD,
     string FPlanU,
     bool Consign,
     string ConsignAC,
     string ConsignN,
     string ConsignR,
     DateTime ConsignD,
     string ConsignU,
     string FPlanInv,
     decimal FPlanV,
     decimal FPlanIV,
     bool FPlanP,
     DateTime FPlanPD,
     string FPlanPU,
     decimal FPlanPV,
     string FPlanAC2,
     string FPlanN2,
     decimal StlmentSV,
     bool Depre,
     string DepreR,
     string DepreU,
     DateTime DepreD,
     decimal DepreV,
     DateTime LDateIn,
     DateTime CostingD,
     string CostingU,
     string Grp
);

