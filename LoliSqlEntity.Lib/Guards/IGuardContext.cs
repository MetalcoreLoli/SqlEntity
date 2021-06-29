using System;

namespace LoliSqlEntity.Lib.Guards
{
    public interface IGuardContext
    {
        TReturn Unwrap<TReturn>();
    }
    
    
    public class GuardContextImpl : IGuardContext
    {
        protected readonly object _obj;

        public GuardContextImpl(object obj)
        {
            _obj = obj;
        }

        public TReturn Unwrap<TReturn>() => (TReturn) _obj;
    }
}