namespace MechanicShop.Domain.Comon;

public abstract class AuditableEntity : Entity {
    
    public AuditableEntity(Parameters)
    {
        
    }

    protected AuditableEntity(Guid id)
    : base(id) // run cotr father 
    {
        
    }

    public DateTimeOffset CreatedAtUtc { get; set; }


    public string? CreatedBy { get; set; }

    public DateTimeOffset LastModifiedUtc { get; set; }

    public string LastModifiedBy { get; set; }


}

