
using BikesNBrewsV2.Models;

namespace BikesNBrewsV2.Services
{
    public interface IGeoCachable
    {
        public Coordinate GetCoordinates(string Address, string City, string State, string Zip);
    }
}
