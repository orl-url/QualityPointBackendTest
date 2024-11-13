using AutoMapper;
using qualityPointBackendTest.Dto;

namespace qualityPointBackendTest.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<DaDataAddress, Address>();
    }
}