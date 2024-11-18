﻿namespace IALClient.Infra.ExternalApi.dto.Main;

 public record SrTransResponseDto(

     bool Active,
     string Jobno,
     string Code,
     string Ref,
     string Sernumber,
     string Desc,
     string Category,
     string Subcat,
     string Jgroup,
     int Disporder,
     string Failure,
     string Cause,
     string Remedy,
     string Advisor,
     string Tech,
     string Jscd1,
     int Jsp1,
     string Jscd2,
     int Jsp2,
     string Jscd3,
     int Jsp3,
     string Jscd4,
     int Jsp4,
     int Itemno,
     string Accno,
     string Acccat,
     string Acctype,
     string Scd,
     string Srep,
     string Sareacd,
     string Sregioncd,
     string Orderno,
     string Refno,
     string Policyno,
     string Contractno,
     bool Jrev,
     string Jrevcrno,
     DateTime Jrevd,
     string Jrevu,
     bool Jredo,
     string Jredono,
     string Jredoinvno,
     string Jredocrno,
     DateTime Jredod,
     string Jredou,
     string Lptype,
     string Lpsystem,
     string Lpgroup,
     string Lpsubgroup,
     string Family,
     string Status,
     string Flag,
     bool Kit,
     string Kitype,
     bool Warranty,
     string Warcd,
     bool Extwar,
     bool Sp,
     bool Mp,
     bool Fmc,
     bool Goodwill,
     bool Rust,
     bool Internal,
     bool Vor,
     bool Sublet,
     string Subletref,
     string Subletsup,
     string Subletacc,
     DateTime Subletd,
     bool Pool,
     string Poolref,
     string Poolsup,
     string Poolacc,
     DateTime Poold,
     string Vin,
     string Engine,
     string Regno,
     string Unitno,
     string Pumpno,
     string Serialno,
     string Govno,
     string Makecd,
     string Make,
     string Modelcd,
     string Model,
     string Baseccode,
     string Basecolor,
     string Colorcd,
     string Color,
     string Derivative,
     string Series,
     string Lseries,
     string Pseries,
     int Mileagein,
     bool Mrp,
     int Cost,
     int Retail,
     int Discount,
     int Qty,
     int Exvatc,
     int Vatvc,
     int Totalc,
     int Exvats,
     int Vatvs,
     int Totals,
     int Vatper,
     int Discper,
     int Markuper,
     int Gper,
     int Gp,
     string Claimno,
     DateTime Claimd,
     string Claimu,
     int Claimv,
     string Claims,
     string Invoiceno,
     DateTime Invoiced,
     string Invoiceu,
     int Invoicev,
     string Crno,
     DateTime Crd,
     string Cru,
     int Crv,
     int Period,
     string Group,
     string Company,
     string Branch,
     string Notes,
     string Comments,
     string Userid,
     DateTime Cdate,
     string Guid,
     string Claimcat,
     string Claimsubc,
     string Claimtype,
     DateTime Statusd,
     string Statusu,
     DateTime Flagd,
     string Flagu,
     bool Adjusted,
     DateTime Adjustedd,
     string Adjustedu,
     bool Exchanged,
     DateTime Exchangedd,
     string Exchangedu,
     bool Added,
     DateTime Addedd,
     string Addedu,
     int Vatperc,
     string Vatcdc,
     string Vatcd
);
