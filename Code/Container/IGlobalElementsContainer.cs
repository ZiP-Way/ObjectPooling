using Pools;
using Pools.ObjectPoolContext;

namespace Container
{
  public interface IGlobalElementsContainer
  {
    void AddElementToContainer(IPoolElement element, IPoolElementReturner pool);
    void RemoveElementFromContainer(IPoolElement element);
  }
}