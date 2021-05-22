using System.Collections.Generic;

namespace LoliSqlEntity.Lib
{
    public interface ISqlQuery
    {
        string Name { get; set; }
        IList<ISqlParameter> Parameters { get; }
    }
}