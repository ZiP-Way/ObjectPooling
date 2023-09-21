using Pools.ObjectPoolContext;

namespace Pools
{
  public interface IPool : IPoolElementReturner
  {
    bool HasFreeElements { get; }
    int FreeElementsCount { get; }

    void CreatePool(string poolName, int elementsCount);
    void ClearPool();
  }
  
  public interface IPool<T> : IPool where T : IPoolElement
  {
    T GetFreeElement();
    void RemoveElementFromPool(T element);
  }
}