using System;
using System.Linq;
using LoliSqlEntity.Lib.Rules;

namespace LoliSqlEntity.Lib.Guards
{
    public class QueryTypeGuard : Guard 
    {
        private readonly string _message;

        public QueryTypeGuard(IGuardContext context) : base(context)
        {
        }

        public QueryTypeGuard(object obj) : base(new GuardContextImpl(obj))
        {
        }

        public override void Execute(params IGuardArgument[] args)
        {
            var types = args.OfType<TypeGuardArg>();
            var container = _context.Unwrap<IRuleContainer>();
            foreach (var type in from t in types select t.Unwrap<Type>())
            {
                if (!container.ContainsType(type))
                    throw new ArgumentOutOfRangeException($"There's no query {type.Name}");
            }
        }
    }
}