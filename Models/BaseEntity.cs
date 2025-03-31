public abstract class BaseEntity 
{
    public int Id { get; set; } // Primary key for the entity, typically used for database operations
    public DateTime CreatedAt { get; set; } // Timestamp for when the entity was created, useful for tracking creation time
    public DateTime UpdatedAt { get; set; } // Timestamp for when the entity was last updated, useful for tracking modifications
}