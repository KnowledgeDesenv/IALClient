using IALClient.Infra.ExternalApi.dto.Main;
using IALClient.Infra.ExternalApi.Dto.FreeTable;
using IALClient.Infra.ExternalApi.Dto.Main;

namespace IALClient.Infra.ExternalApi;

public class TinyDogService(IConfiguration configuration, HttpClient httpClient)
{

    
    private const string Resource = "/api";

    
    public async Task<MvOwnersResponseDto> GetMvowners(string key)
    {

        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetMvowners";

        //Console.WriteLine($"Base URL for TinyDOG => {baseUrl}");

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
            Query = $"key={key}"
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var ownerDetails = await response!.Content!.ReadFromJsonAsync<List<MvOwnersResponseDto>>()!;

        if (ownerDetails == null ||  ownerDetails.Count == 0)
        {
            throw new Exception("No key found"); // colocar exception especifica
        }

        return ownerDetails.First();
    }

    public async Task<VehicleVinResponseDto> GetVehicleVin(string key)
    {

        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetVehiclesM";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
            Query = $"key={key}"
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var vin = await response.Content.ReadFromJsonAsync<List<VehicleVinResponseDto>>();

        if (vin == null ||  vin.Count == 0)
        {
            throw new Exception("No key found"); // colocar exception especifica
        }

        return vin.First();
    }


    public async Task<VehicleMDto> GetVehiclesM(string? key, string? vin)
    {

        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetVehiclesM";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
            Query = $"key={key}&vin={vin}"
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var vinResult = await response.Content.ReadFromJsonAsync<List<VehicleMDto>>();

        if (vinResult == null || vinResult.Count == 0)
        {
            throw new Exception("No key found"); // colocar exception especifica
        }

        return vinResult.First();
    }

    public async Task<List<SrHistoryWrapperResponseDto>> GetSrHistory(string key)
    {

        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetSrHistory";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
            Query = $"key={key}"
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var serviceHistories = await response.Content.ReadFromJsonAsync<List<SrHistoryWrapperResponseDto>>();

        return serviceHistories!;
    }

    public async Task<List<SrHistoryWrapperResponseDto>> GetSrHistoryByVin(string? vin, string? jobno, string? claimno)
    {

        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetSrHistoryByVin";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
            Query = $"vin={vin}&jobno={jobno}&claimno={claimno}"
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var serviceHistories = await response.Content.ReadFromJsonAsync<List<SrHistoryWrapperResponseDto>>();

        return serviceHistories!;
    }

    public async Task<List<DealerResponseDto>> GetDealers()
    {


        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetDealers";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();
        
        var dealers = await response.Content.ReadFromJsonAsync<List<DealerResponseDto>>();

        return dealers!;
    }

    public async Task<List<WarrantyResponseDto>> GetWarranties(string vin)
    {


        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetWarranties";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
            Query = $"vin={vin}"
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var warranties = await response.Content.ReadFromJsonAsync<List<WarrantyResponseDto>>();

        return warranties!;
    }

    public async Task<List<CategoriesResponseDto>> GetCat(string? code, string? reference, string? category, string? type)
    {

        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetCat";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var categories = await response.Content.ReadFromJsonAsync<List<CategoriesResponseDto>>();
        
        return FilterCategories(categories!, code, reference, category, type);

    }

    public async Task<List<SrTransResponseDto>> GetSrTrans(string? jobno, string? claimno, string? invoiceno)
    {

        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetSrTrans";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
            Query = $"jobno={jobno}&claimno={claimno}&invoiceno={invoiceno}"
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var srTransList = await response.Content.ReadFromJsonAsync<List<SrTransResponseDto>>();

        return srTransList!;
    }

    public async Task<List<VinmileageResponseDto>> GetVinmileage(string? vin)
    {

        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetVinmileage";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
            Query = $"vin={vin}"
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var vinmileageList = await response.Content.ReadFromJsonAsync<List<VinmileageResponseDto>>();

        return vinmileageList!;

    }

    public async Task<List<ImportsResponseDto>> GetImports(string? vin)
    {

        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetImports";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
            Query = $"vin={vin}"
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var importsList = await response.Content.ReadFromJsonAsync<List<ImportsResponseDto>>();

        return importsList!;

    }

    public async Task<List<VehrecampResponseDto>> GetVehrecamp(string? vin)
    {

        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetVehrecamp";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
            Query = $"vin={vin}"
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var vehrecampList = await response.Content.ReadFromJsonAsync<List<VehrecampResponseDto>>();

        return vehrecampList!;

    }

    public async Task<List<VehiclesCResponseDto>> GetVehiclesC(string? vin)
    {

        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetVehiclesC";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
            Query = $"vin={vin}"
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var vehiclesCList = await response.Content.ReadFromJsonAsync<List<VehiclesCResponseDto>>();

        return vehiclesCList!;

    }

    public async Task<List<VehiclesResponseDto>> GetVehicles(string? vin, string? stkno)
    {

        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetVehicles";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
            Query = $"vin={vin}&stkno={stkno}"
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var vehiclesList = await response.Content.ReadFromJsonAsync<List<VehiclesResponseDto>>();

        return vehiclesList!;

    }

    public async Task<List<JobcardsResponseDto>> GetJobcards()
    {

        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetJobcards";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var jobcardsList = await response.Content.ReadFromJsonAsync<List<JobcardsResponseDto>>();

        return jobcardsList!;

    }

    public async Task<List<MvmodelsResponseDto>> GetMvmodels()
    {

        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetMvmodels";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var mvmodelsList = await response.Content.ReadFromJsonAsync<List<MvmodelsResponseDto>>();

        return mvmodelsList!;

    }

    public async Task<List<MvservicesResponseDto>> GetMvservices()
    {

        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/Main/GetMvservices";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();

        var mvservicesList = await response.Content.ReadFromJsonAsync<List<MvservicesResponseDto>>();

        return mvservicesList!;

    }

    private List<CategoriesResponseDto> FilterCategories(List<CategoriesResponseDto> categories, string? code, string? reference, string? category, string? type)
    {

        if (code != null)
        {
            categories = categories.Where(c => c.Code == code).ToList();
        }

        if (reference != null)
        {
            categories = categories.Where(c => c.Ref == reference).ToList();
        }

        if (category != null)
        {
            categories = categories.Where(c => c.Category == category).ToList();
        }

        if (type != null)
        {
            categories = categories.Where(c => c.Type == type).ToList();
        }

        return categories;

    }


    // --------- FREE TABLES ----

    public async Task<List<SpeedResponseDto>> GetSpeedList()
    {


        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/FreeTable/GetSpeedList";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();
        
        var speedList = await response.Content.ReadFromJsonAsync<List<SpeedResponseDto>>();

        return speedList!;
    }

    public async Task<List<FrequencyResponseDto>> GetFrequencies()
    {


        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/FreeTable/GetFrequencies";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();
        
        var frequencies = await response.Content.ReadFromJsonAsync<List<FrequencyResponseDto>>();

        return frequencies!;
    }

    public async Task<List<DirectionResponseDto>> GetDirections()
    {


        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/FreeTable/GetDirections";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();
        
        var directions = await response.Content.ReadFromJsonAsync<List<DirectionResponseDto>>();

        return directions!;
    }

    public async Task<List<LoadconResponseDto>> GetLoadcons()
    {


        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/FreeTable/GetLoadcons";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();
        
        var loadcons = await response.Content.ReadFromJsonAsync<List<LoadconResponseDto>>();

        return loadcons!;
    }

    public async Task<List<EngineconResponseDto>> GetEnginecons()
    {


        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/FreeTable/GetEnginecons";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();
        
        var enginecons = await response.Content.ReadFromJsonAsync<List<EngineconResponseDto>>();

        return enginecons!;
    }

    public async Task<List<ClimateconResponseDto>> GetClimatecons()
    {


        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/FreeTable/GetClimatecons";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();
        
        var climatecons = await response.Content.ReadFromJsonAsync<List<ClimateconResponseDto>>();

        return climatecons!;
    }

    public async Task<List<RoadconResponseDto>> GetRoadcons()
    {


        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/FreeTable/GetRoadcons";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();
        
        var roadcons = await response.Content.ReadFromJsonAsync<List<RoadconResponseDto>>();

        return roadcons!;
    }

    public async Task<List<IdCodeResponseDto>> GetIdCodes()
    {


        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/FreeTable/GetIdCodes";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();
        
        var idCodes = await response.Content.ReadFromJsonAsync<List<IdCodeResponseDto>>();

        return idCodes!;
    }

    public async Task<List<MvFuelResponseDto>> GetMvFuels()
    {


        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/FreeTable/GetMvFuels";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();
        
        var mvFuels = await response.Content.ReadFromJsonAsync<List<MvFuelResponseDto>>();

        return mvFuels!;
    }

    public async Task<List<MvTransResponseDto>> GetMvTrans()
    {


        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/FreeTable/GetMvTrans";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();
        
        var mvTrans = await response.Content.ReadFromJsonAsync<List<MvTransResponseDto>>();

        return mvTrans!;
    }

    public async Task<List<LanguagesResponseDto>> GetLanguages()
    {


        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/FreeTable/GetLanguages";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();
        
        var languages = await response.Content.ReadFromJsonAsync<List<LanguagesResponseDto>>();

        return languages!;
    }

    public async Task<List<SMResponseDto>> GetSMList()
    {


        var baseUrl = configuration["TinyDogApiUrl"]!;
        var endpoint = Resource + "/FreeTable/GetSMlist";

        var url = new UriBuilder(baseUrl)
        {
            Path = endpoint,
        };

        var response = await httpClient.GetAsync(url.ToString());
        response.EnsureSuccessStatusCode();
        
        var smList = await response.Content.ReadFromJsonAsync<List<SMResponseDto>>();

        return smList!;
    }

}
