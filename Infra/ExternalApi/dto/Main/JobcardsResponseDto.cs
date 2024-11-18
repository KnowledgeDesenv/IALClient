namespace IALClient.Infra.ExternalApi.dto.Main;

public record JobcardsResponseDto(

   bool Active,

   string? Status,

   string? Jobno,

   DateTime? Jobd,

   string? Jobu,

   string? Jobsummary,

   string? Jobdesc,

   string? Category,

   string? Subcat,

   string? Failure,

   string? Cause,

   string? Remedy,

   string? Jobrep,

   string? Advisor,

   string? Tech,

   string? Wscode,

   string? Ws,

   string? Orderno,

   DateTime? Orderd,

   string? Orderu,

   string? Refno,

   string? Policyno,

   string? Contractno,

   bool Jrev,

   string? Jrevcrno,

   DateTime? Jrevd,

   string? Jrevu,

   bool Jredo,

   string? Jredono,

   string? Jredoinvno,

   string? Jredocrno,

   DateTime? Jredod,

   string? Jredou,

   bool Jcb,

   string? Jcbno,

   string? Jcbinvno,

   string? Jcbclaimno,

   DateTime? Jcbd,

   string? Jcbu,
   bool Warranty,
   bool Extwar,
   bool Sp,
   bool Mp,
   bool Fmc,
   bool Internal,

   string? Internala,

   string? Internalo,

   int? Internalv,

   bool Sublet,

   string? Subleta,

   string? Subleto,

   int? Subletv,

   DateTime? Datein,

   DateTime? Dateout,

   DateTime? Datedue,

   bool? Vor,

   int? Vord,

   string? Vin,

   string? Engine,

   string? Regno,

   string? Unitno,

   string? Pumpno,

   string? Serialno,

   string? Govno,

   DateTime? Datesale,

   int? Mandate,

   string? Fuel,

   string? Transmiss,

   int? Enginecc,

   int? Netpower,

   string? Makecd,

   string? Make,

   string? Modelcd,

   string? Model,

   string? Baseccode,

   string? Basecolor,

   string? Colorcd,

   string? Color,

   string? Derivative,

   string? Series,

   string? Lseries,

   string? Pseries,

   string? Fuelin,

   string? Fuelout,

   DateTime? Scannedin,

   string? Scaninu,

   DateTime? Scannedout,

   string? Mvdepotcd,

   string? Mvdepot,

   string? Accno,

   string? Acccat,

   string? Acctype,

   string? Scd,

   string? Srep,

   string? Sareacd,

   string? Sregioncd,

   string? Mainc,

   bool Mail,
   bool Sms,
   bool Sm,
   bool Call,

   string? Contact,

   string? Telc,

   string? Tela,

   string? Tel,

   string? Celc,

   string? Cela,

   string? Cel,

   string? Faxc,

   string? Faxa,

   string? Fax,

   string? Email,

   DateTime? Collectd,

   string? Collectn,

   string? Cadd1,

   string? Cadd2,

   string? Cadd3,

   string? Careacd,

   string? Ccitycd,

   string? Ccity,

   string? Cregioncd,

   string? Cregion,

   string? Cprovcd,

   string? Cprov,

   string? Ccountrycd,

   string? Ccountry,

   DateTime? Deliveryd,

   string? Deliveryn,

   string? Dadd1,

   string? Dadd2,

   string? Dadd3,

   string? Dareacd,

   string? Dcitycd,

   string? Dcity,

   string? Dregioncd,

   string? Dregion,

   string? Dprovcd,

   string? Dprov,

   string? Dcountrycd,

   string? Dcountry,

   string? Claimno,

   DateTime? Claimd,

   string? Claimu,

   int? Claimv,

   string? Quoteno,

   DateTime? Quoted,

   string? Quoteu,

   int? Quotev,

   bool Completed,

   DateTime? Completedd,

   string? Completedu,

   bool? Frv,

   DateTime? Frvd,

   string? Frvu,
   bool? Fra1,

   DateTime? Fra1d,

   string? Fra1u,
   bool? Fra2,

   DateTime? Fra2d,

   string? Fra2u,
   bool? Invoiced,
   bool? Proforma,

   int? Exvatc,

   int? Vatvc,

   int? Totalc,

   int? Exvats,

   int? Vatvs,

   int? Totals,

   int? Period,

   string? Group,

   string? Company,

   string? Branch,

   string? Notes,

   string? Comments,

   string? Userid,

   DateTime? Cdate,

   string? Guid,
   bool Goodwill,

   bool Rust,
   bool Onhold,

   DateTime? Onholdd,
   string? Onholdu,
   bool Collect,
   bool Deliver,
   bool Closed,

   DateTime? Closedd,
   string? Closedu,
   int? Mileagein,
   int? Mileageout,
   bool Checklist,

   DateTime? Checklistd,
   string? Checklistu,
   bool Damaged,

   DateTime? Damagedd,
   string? Damagedu,
   string? Fuelcd,
   string? Transcd,
   int? Itemno,
   int? Claiminvno,
   int? Claimcrno,
   DateTime? Statusd,
   string? Statusu,
   string? Scanoutu,
   string? Salestype,
   string? Failurecd,
   string? Causecd,
   string? Remedycd,
   string? Subletcd,
   bool Rejected,

   DateTime? Rejectedd,
   string? Rejectedu,
   bool Approved,

   DateTime? Approvedd,
   string? Approvedu,
   bool Fra3,

   DateTime? Fra3d,
   string? Fra3u,
   bool Fra4,

   DateTime? Fra4d,
   string? Fra4u,
   string? Goodwilln,
   string? Apprejn,
   int? Materialv,
   int? Labourv,
   string? Scardno,
   bool Oem,
   bool Inv,

   DateTime? Invd,
   string? Invu,
   bool Intorder,
   string? Intorderno,
   DateTime? Intorderd,
   string? Intorderu,
   int? Intorderv,
   string? Grp

);

