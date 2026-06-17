using MechanicShop.Domain.common;

namespace MechanicShop.Domain.Comon;

public abstract class Entity
{
    public Guid Id {get;}

    protected Entity(){}//can call by chidren

    private readonly List<DomainEvent> _dEvents = [];
    protected Entity(Guid id)
    {
        Id=id==Guid.Empty ? Guid.NewGuid() :id ;
    }


    public void AddDomainEvent(DomainEvent domainEvent)
    {
        _dEvents.Add(domainEvent);
    }


    public void RemoveDomainEvent(DomainEvent domainEvent)
    {
        _dEvents.Remove(domainEvent);
    }


    public void ClearDomainEvents()
    {
        _dEvents.Clear();
    }
}
