using Pools.ObjectPoolContext;

namespace Pools
{
  public interface IPoolElementReturner
  {
    void ReturnToPool(IPoolElement element);
  }
}