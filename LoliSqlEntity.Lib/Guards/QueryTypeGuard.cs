using System;
using System.Linq;
using LoliSqlEntity.Lib.Rules;

namespace LoliSqlEntity.Lib.Guards
{
    public class QueryTypeGuard : Guard 
    {
        public QueryTypeGuard(IGuardContext context) : base(context)
        {
        }

        public QueryTypeGuard(IRuleContainer container) : base(new GuardContextImpl(container))
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