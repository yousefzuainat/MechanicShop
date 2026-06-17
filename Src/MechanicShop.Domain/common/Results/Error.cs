namespace MechanicShop.Domain.common.Results
{
    public readonly record struct Error
    {
        private Error(string code, string description, ErrorKind type)
        {
            Code = code;
            Description = description;
            Type = type;
        }

        public string Code { get; }

        public string Description { get; }

        public ErrorKind Type { get; }


        public static Error Failure(string code = nameof(Failure), string description = "General failure") => new(code, description, ErrorKind.Failure);

        public static Error Unxpected(string code = nameof(Unxpected), string description = "Unexpected Error") => new Error(code, description, ErrorKind.Unexpected);

        public static Error Validation(string code = nameof(Validation), string description = "Validation Error") => new Error(code, description, ErrorKind.Validation);


        public static Error Conflict(string code = nameof(Conflict), string description = "Validation Error") => new Error(code, description, ErrorKind.Conflict);

        public static Error NotFound(string code = nameof(NotFound), string description = "NotFound Error") => new Error(code, description, ErrorKind.NotFound);

        public static Error Unauthorized(string code = nameof(Unauthorized), string description = "Unauthorized Error") => new Error(code, description, ErrorKind.Unauthorized);

        public static Error Forbidden(string code = nameof(Forbidden), string description = "Forbidden Error") => new Error(code, description, ErrorKind.Forbidden);

        public static Error Create(string code, string description, ErrorKind type) => new Error(code, description, type);









    }
}
