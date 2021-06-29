namespace LoliSqlEntity.Lib.Guards
{
    public class GuardArgumentImpl : IGuardArgument
    {
        protected readonly object _obj;

        public GuardArgumentImpl(object obj)
        {
            _obj = obj;
        }

        public virtual TReturn Unwrap<TReturn>()
        {
            return (TReturn)_obj;
        }
    }

    public interface IGuardArgument
    {
        TReturn Unwrap<TReturn>();
    }
}