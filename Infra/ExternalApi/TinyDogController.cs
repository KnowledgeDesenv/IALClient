using IALClient.Infra.ExternalApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IALClient.Infra.ExternalAPI;

[ApiController]
[Route("[controller]")]
public class TinyDogController(TinyDogService service) : ControllerBase
{
    
    [Authorize]
    [HttpGet("GetMvowners")]
    public async Task<IActionResult> GetMvowners([FromQuery] string key)
    {

        var ownerDetail = await service.GetMvowners(key);

        return Ok(ownerDetail);
    }

    [AllowAnonymous]
    [HttpGet("GetVin")]
    public async Task<IActionResult> GetVehicleVin([FromQuery] string key)
    {
        
        var vin = await service.GetVehicleVin(key);

        return Ok(vin);
    }

    [Authorize]
    [HttpGet("GetVehiclesM")]
    public async Task<IActionResult> GetVehiclesM([FromQuery] string? key = null, [FromQuery] string? vin = null)
    {
        
        var vehicleDetails = await service.GetVehiclesM(key, vin);

        return Ok(vehicleDetails);
    }

    [Authorize]
    [HttpGet("GetSrHistory")]
    public async Task<IActionResult> GetSrHistory([FromQuery] string key)
    {

        var serviceHistories = await service.GetSrHistory(key);

        return Ok(serviceHistories);
    }

    [Authorize]
    [HttpGet("GetSrHistoryByVin")]
    public async Task<IActionResult> GetSrHistoryByVin([FromQuery] string? vin = null, [FromQuery] string? jobno = null, [FromQuery] string? claimno = null)
    {

        var serviceHistories = await service.GetSrHistoryByVin(vin, jobno, claimno);

        return Ok(serviceHistories);
    }

    [Authorize]
    [HttpGet("GetDealers")]
    public async Task<IActionResult> GetDealers()
    {

        var dealers = await service.GetDealers();

        return Ok(dealers);
    }

    [Authorize]
    [HttpGet("GetWarranties")]
    public async Task<IActionResult> GetWarranties([FromQuery] string vin)
    {
        
        var warranties = await service.GetWarranties(vin);

        return Ok(warranties);
    }

    [AllowAnonymous]
    [HttpGet("GetCat")]
    public async Task<IActionResult> GetCat([FromQuery] string? code = null, 
                                            [FromQuery] string? reference = null, 
                                            [FromQuery] string? category = null, 
                                            [FromQuery] string? type = null)
    {

        var categories = await service.GetCat(code, reference, category, type);

        return Ok(categories);
    }

    [AllowAnonymous]
    [HttpGet("GetSrTrans")]
    public async Task<IActionResult> GetSrTrans([FromQuery] string? jobno, [FromQuery] string? claimno, [FromQuery] string? invoiceno)
    {

        var srTransList = await service.GetSrTrans(jobno, claimno, invoiceno);

        return Ok(srTransList);
    }

    [AllowAnonymous]
    [HttpGet("GetVinmileage")]
    public async Task<IActionResult> GetVinmileage([FromQuery] string vin)
    {

        var vinmileageList = await service.GetVinmileage(vin);

        return Ok(vinmileageList);
    }

    [AllowAnonymous]
    [HttpGet("GetImports")]
    public async Task<IActionResult> GetImports([FromQuery] string vin)
    {

        var importsList = await service.GetImports(vin);

        return Ok(importsList);
    }

    [AllowAnonymous]
    [HttpGet("GetVehrecamp")]
    public async Task<IActionResult> GetVehrecamp([FromQuery] string vin)
    {

        var vehrecampList = await service.GetVehrecamp(vin);

        return Ok(vehrecampList);
    }

    [AllowAnonymous]
    [HttpGet("GetVehiclesC")]
    public async Task<IActionResult> GetVehiclesC([FromQuery] string vin)
    {

        var vehiclesCList = await service.GetVehiclesC(vin);

        return Ok(vehiclesCList);
    }

    [AllowAnonymous]
    [HttpGet("GetVehicles")]
    public async Task<IActionResult> GetVehicles([FromQuery] string? vin = null, [FromQuery] string? stkno = null)
    {

        var vehiclesList = await service.GetVehicles(vin, stkno);

        return Ok(vehiclesList);
    }

    [AllowAnonymous]
    [HttpGet("GetJobcards")]
    public async Task<IActionResult> GetJobcards()
    {

        var jobcardsList = await service.GetJobcards();

        return Ok(jobcardsList);
    }

    [AllowAnonymous]
    [HttpGet("GetMvmodels")]
    public async Task<IActionResult> GetMvmodels()
    {

        var mvmodelsList = await service.GetMvmodels();

        return Ok(mvmodelsList);
    }

    [AllowAnonymous]
    [HttpGet("GetMvservices")]
    public async Task<IActionResult> GetMvservices()
    {

       var mvservicesList = await service.GetMvservices();

        return Ok(mvservicesList);
    }

    // --------- FREE TABLES ----

    [HttpGet]
    [Route("GetSpeedList")]
    public async Task<IActionResult> GetSpeedList()
    {
        
        var speedList = await service.GetSpeedList();

        return Ok(speedList);
    }

    [HttpGet]
    [Route("GetFrequencies")]
    public async Task<IActionResult> GetFrequencies()
    {
        
        var frequencies = await service.GetFrequencies();

        return Ok(frequencies);
    }

    [HttpGet]
    [Route("GetDirections")]
    public async Task<IActionResult> GetDirections()
    {
        
        var directions = await service.GetDirections();

        return Ok(directions);
    }


    [HttpGet]
    [Route("GetLoadcons")]
    public async Task<IActionResult> GetLoadcons()
    {
        
        var loadcons = await service.GetLoadcons();

        return Ok(loadcons);
    }

    [HttpGet]
    [Route("GetEnginecons")]
    public async Task<IActionResult> GetEnginecons()
    {
        
        var enginecons = await service.GetEnginecons();
        
        return Ok(enginecons);
    }

    [HttpGet]
    [Route("GetClimatecons")]
    public async Task<IActionResult> GetClimatecons()
    {
        
        var climatecons = await service.GetClimatecons();

        return Ok(climatecons);
    }

    [HttpGet]
    [Route("GetRoadcons")]
    public async Task<IActionResult> GetRoadcons()
    {
        
        var roadcons = await service.GetRoadcons();

        return Ok(roadcons);
    }


    [HttpGet]
    [Route("GetIdCodes")]
    public async Task<IActionResult> GetIdCodes()
    {
        
        var idCodes = await service.GetIdCodes();

        return Ok(idCodes);
    }

    [HttpGet]
    [Route("GetMvFuels")]
    public async Task<IActionResult> GetMvFuels()
    {
        
        var mvFuels = await service.GetMvFuels();

        return Ok(mvFuels);
    }

    [HttpGet]
    [Route("GetMvTrans")]
    public async Task<IActionResult> GetMvTrans()
    {
        
        var mvTrans = await service.GetMvTrans();

        return Ok(mvTrans);
    }

    [HttpGet]
    [Route("GetLanguages")]
    public async Task<IActionResult> GetLanguages()
    {
        
        var languages = await service.GetLanguages();

        return Ok(languages);
    }

    [HttpGet]
    [Route("GetSMList")]
    public async Task<IActionResult> GetSMList()
    {
        
        var smList = await service.GetSMList();

        return Ok(smList);
    }

}
