using API.DataTransferObjects;

namespace API.Services
{
    public interface IPlantIDService
    {
        Task<PlantIDDTO> IdentifyPlantAsync(IFormFile file);
    }
}
