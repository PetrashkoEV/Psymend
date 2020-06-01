namespace Psymend.Infrastructure.Core
{
    public abstract class BaseSqlRepository<T> where T : BaseSqlContext
    {
        protected T Context;
    }
}