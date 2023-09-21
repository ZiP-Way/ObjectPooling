using Pools;
using Pools.ObjectPoolContext;

namespace Container
{
  public interface IGlobalElementsContainer
  {
    void AddElementToContainer(IPoolElement element, IPool pool);
    void RemoveElementFromContainer(IPoolElement element);
    void ClearAllPools();
  }
}