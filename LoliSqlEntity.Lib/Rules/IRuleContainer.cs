using System;

namespace LoliSqlEntity.Lib.Rules
{
    public interface IRuleContainer
    {
        IRuleContainer AddRule<TQuery>(IRule rule) where TQuery : ISqlQuery;

        IRuleContainer RemoveRule<TQuery>() where TQuery : ISqlQuery;
        IRule GetRule<TQuery>() where TQuery : ISqlQuery;

        bool ContainsType(Type type);
    }
}