namespace EventApi.DataTransferObjects; // This namespace is used to organize the EventDTO class, indicating that it belongs to the Data Transfer Objects layer of the application
public class EventDTO
{
    public int Id {get;set;}    
    public string Title { get; set; } = string.Empty; // Title of the event, initialized to an empty string to avoid null reference issues
    public string Description { get; set; } = string.Empty; // Description of the event, also initialized to an empty string
    public DateTime Date { get; set; } // Date of the event, using DateTime to represent date and time information
}