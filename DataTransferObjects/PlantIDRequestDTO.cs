namespace API.DataTransferObjects
{
    public class PlantIDRequestDTO
    {
        public required IFormFile File { get; set; }
        public string Organ { get; set; } = "flower";
    }
}
