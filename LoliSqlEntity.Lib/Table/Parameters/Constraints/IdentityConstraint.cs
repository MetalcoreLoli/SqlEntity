namespace LoliSqlEntity.Lib.Table.Parameters.Constraints
{
    public class IdentityConstraint : IColumnConstraint
    {
        /// <summary>
        /// Is the value that is used for the very first row loaded into the table. 
        /// </summary>
        public uint Seed { get; set; }
       
        /// <summary>
        /// Is the incremental value that is added to the identity value of the previous row that was loaded.
        /// </summary>
        public uint  Increment { get; set; }


        public IdentityConstraint() : this(1, 1)
        {
        }

        public IdentityConstraint(uint seed, uint increment)
        {
            Seed = seed;
            Increment = increment;
        }


        public override string ToString()
        {
            if (Seed > 0 || Increment > 0)
                return $"{Name} ({Seed}, {Increment})";

            return Name;
        }

        public string Name => "IDENTITY";
    }
}