using System.Collections.Generic;
using Pools;
using Pools.ObjectPoolContext;

namespace Container
{
  public class PoolsContainer : IGlobalElementsContainer, IPoolAccessor
  {
    #region Fields

    private Dictionary<IPoolElement, IPool> _container;

    #endregion

    public PoolsContainer() => 
      _container = new Dictionary<IPoolElement, IPool>();

    public IPoolElementReturner GetPool(IPoolElement element)
    {
      _container.TryGetValue(element, out IPool pool);
      return pool;
    }

    public void AddElementToContainer(IPoolElement element, IPool pool) => 
      _container.Add(element, pool);

    public void RemoveElementFromContainer(IPoolElement element) => 
      _container.Remove(element);
  }
}