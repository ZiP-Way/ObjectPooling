using System.Collections.Generic;

namespace Pool.Container
{
  public class PoolsContainer : IGlobalElementsContainer, IPoolAccessor
  {
    #region Fields

    private Dictionary<IPoolElement, IPoolElementReturner> _container;

    #endregion

    public PoolsContainer() => 
      _container = new Dictionary<IPoolElement, IPoolElementReturner>();

    public IPoolElementReturner GetPool(IPoolElement element)
    {
      _container.TryGetValue(element, out IPoolElementReturner pool);
      return pool;
    }

    public void AddElementToContainer(IPoolElement element, IPoolElementReturner pool) => 
      _container.Add(element, pool);
  }
}