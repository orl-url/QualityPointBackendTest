using AutoMapper;
using qualityPointBackendTest.Dto;

namespace qualityPointBackendTest.Services;

public class DaDataService(
    IHttpClientFactory httpClientFactory,
    IMapper _mapper)
{
    public async Task<Address> StandardizeAddress(string address)
    {
        var client = httpClientFactory.CreateClient("daData");

        string[] addresses = [address];

        var response = await client.PostAsJsonAsync("clean/address", addresses);

        var daDataAddresses = await response.Content.ReadFromJsonAsync<List<DaDataAddress>>();

        var daDataAddress = daDataAddresses.FirstOrDefault();

        if (daDataAddress != null)
        {
            var mappedAddress = _mapper.Map<Address>(daDataAddress);

            return mappedAddress;
        }

        return new Address();
    }
}