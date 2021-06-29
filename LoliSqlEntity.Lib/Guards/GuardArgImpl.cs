namespace LoliSqlEntity.Lib.Guards
{
    public readonly struct GuardArgImpl : IGuardArgument
    {
        private readonly object _value;

        public GuardArgImpl(object value) =>
            _value = value;
        
        public TReturn Unwrap<TReturn>() => 
            (TReturn)_value;
    }
}