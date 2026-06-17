namespace MechanicShop.Domain.Comon;

public abstract class Entity
{
    public Guid Id {get;}

    protected Entity(){}//can call by chidren


    protected Entity(Guid id)
    {
        Id=id==Guid.Empty ? Guid.NewGuid() :id ;
    }
}