using Pools;
using Pools.ObjectPoolContext;

namespace Container
{
  public interface IPoolAccessor
  {
    IPoolElementReturner GetPool(IPoolElement element);
  }
}