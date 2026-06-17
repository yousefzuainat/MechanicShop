namespace MechanicShop.Domain.common.Results
{
    public interface IResult
    {
        List<Error>? Errors { get;  } 

        bool IsSuccess { get; } 
    }

    public interface IResult<out TValue> : IResult //TValue  Generic  : user  or proudect ...
    {
        TValue Value { get; }

    }
}
