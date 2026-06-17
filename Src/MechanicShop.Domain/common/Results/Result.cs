using System.ComponentModel;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MechanicShop.Domain.common.Results
{
    public static class Result
    {
        public static Success success => default;

        public static Created created => default;

        public static Updated updated => default;

        public static Deleted deleted => default;
    }

    public sealed class Result<TValue> : IResult<TValue>
    {
        
    
        private readonly TValue? _value = default;

        private readonly List<Error>? _errors = null;

        public bool IsSuccess { get; }

        public bool IsError => !IsSuccess;

        public List<Error> Errors => IsError ? _errors! : [];

        public TValue Value => IsSuccess ? _value! : throw new InvalidOperationException("Cannot access the value of an error result.");


        public Result(Error error) 
        {
            _errors = [error];
            IsSuccess = false;
        }

        public Result(List<Error> errors)
        {
            if (errors is null || errors.Count == 0) 
            { 
              throw new ArgumentException("Cannot create an Error <TValue> from an empty collection of errors provide at east one error",nameof(errors));
            }

            _errors = errors;
            IsSuccess = false;
            
        }

        [JsonConstructor]//we need public ctor
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("For seializer only",true)]
        public Result(TValue? value,List<Error>?errors,bool isSuccess)
        {

            if (isSuccess)
            {
                _value = value ?? throw new ArgumentNullException(nameof(value));
                _errors = [];
                IsSuccess = true;

            }
            else
            {
                if(errors==null || errors.Count == 0)
                {
                    throw new ArgumentException("Provide at least one error",nameof(_errors));
                }

                _errors = errors;
                _value = default;
                IsSuccess = false;

            }

        }

       
            
        
        public Result(TValue value)
        {
            if (value is null)
            { 
                throw new ArgumentNullException(nameof(value));
            }

            _value = value;

            IsSuccess = true;
        }

         public TNextValue Match<TNextValue>(Func<TValue, TNextValue> onValue, Func<List<Error>, TNextValue> onError)
            => IsSuccess ? onValue(_value!) : onError(Errors);
        

        public static implicit operator Result<TValue>(TValue value) => new Result<TValue>(value); //result pattern 


        public static implicit operator Result<TValue>(Error error)=>new Result<TValue>(error);//call ctor

        public static implicit operator Result<TValue>(List<Error> errors)=>new Result<TValue>(errors);



    }

    public readonly record struct Success;

    public readonly record struct Created;

    public readonly record struct Updated;

    public readonly record struct Deleted;
}
