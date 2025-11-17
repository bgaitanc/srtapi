using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Countries;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CountriesController(ICountryService countryService) : SrtControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetCountryResponse>>> GetCountries()
    {
        return await ExecuteServiceAsync(async () => await countryService.GetCountries());
    }

    [HttpGet]
    public async Task<ActionResult<GetCountryResponse?>> GetCountry([FromQuery] GetCountryRequest request)
    {
        return await ExecuteServiceAsync(async () => await countryService.GetCountry(request));
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreateCountryResponse>> CreateCountry([FromBody] CreateCountryRequest request)
    {
        return await ExecuteServiceAsync(async () => await countryService.CreateCountry(request), HttpStatusCode.Created);
    }

    [HttpPut("update")]
    public async Task<ActionResult<UpdateCountryResponse>> UpdateCountry([FromBody] UpdateCountryRequest request)
    {
        return await ExecuteServiceAsync(async () => await countryService.UpdateCountry(request));
    }
}