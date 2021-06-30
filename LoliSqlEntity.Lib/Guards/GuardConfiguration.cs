using System;
using System.Collections.Generic;
using System.Reflection;

namespace LoliSqlEntity.Lib.Guards
{
    public class GuardConfiguration
    {
        private readonly Guard _guard;

        //private readonly Func<object, bool> _canExecute;
        private Action<Guard> _onEntry;
        private readonly List<IGuardArgument> _args;
        public GuardConfiguration(Guard guard)
        {
            _guard = guard;
            _args = new List<IGuardArgument>();
        }

        public GuardConfiguration OnEntry(Action<Guard> action)
        {
            _onEntry = action;
            return this;
        }

        public GuardConfiguration PermitOn<TGuardArg>(params object[] args)
            where TGuardArg : IGuardArgument
        {
            foreach (var o in args)
            {
                var ob = Activator.CreateInstance(typeof(TGuardArg), o);
                if (ob == null)
                    throw new NullReferenceException("This is no guard with this count of args");
                _args.Add((IGuardArgument)ob);
            }
            
            return this;
        }


        public GuardConfiguration Execute()
        {
            _onEntry?.Invoke(_guard);
            _guard.Execute(_args.ToArray());
            return this;
        }
    }
}