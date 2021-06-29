namespace LoliSqlEntity.Lib.Guards
{
    public abstract class Guard
    {
        protected readonly IGuardContext _context;
        protected Guard(IGuardContext context) =>
            _context = context;
        public abstract void Execute(params IGuardArgument[] args);
    }
}