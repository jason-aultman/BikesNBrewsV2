namespace BikesNBrewsV2.Services;
using BikesNBrewsV2.Models;

public interface IBrewData
{
    public List<Brewery> GetBreweriesByZip(string Zip);
    public List<Brewery> GetBreweriesByCityState(string City, string State);
    
}
