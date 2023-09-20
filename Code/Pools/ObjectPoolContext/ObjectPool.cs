using System;
using System.Collections.Generic;
using System.Linq;
using Container;
using Factory;

namespace Pools.ObjectPoolContext
{
  public class ObjectPool<T> : IPool<T> where T : IPoolElement
  {
    #region Properties

    public bool HasFreeElements => _elements.Count > 0;
    public int FreeElementsCount => _elements.Count;

    #endregion

    #region Fields

    private readonly IGlobalElementsContainer _poolsContainer;
    private readonly Func<T> _factoryMethod;
    
    private HashSet<T> _elements;

    #endregion

    public ObjectPool(IFactory<T> factory, IGlobalElementsContainer poolsContainer)
    {
      _poolsContainer = poolsContainer;
      _factoryMethod = factory.Create;
    }

    public void CreatePool(string poolName, int elementsCount)
    {
      _elements = new HashSet<T>(elementsCount);
      
      for (int i = 0; i < elementsCount; i++)
        _elements.Add(CreateElement());
    }

    public T GetFreeElement()
    {
      T poolElement;
      
      if (HasFreeElements)
      {
        poolElement = _elements.First();
        _elements.Remove(poolElement);
      }
      else
        poolElement = CreateElement();

      poolElement.Commission();
      return poolElement;
    }

    public void ReturnToPool(IPoolElement element)
    {
      T poolElement = (T)element;
      
      poolElement.Decommission();
      _elements.Add(poolElement);
    }

    private T CreateElement()
    {
      T createdElement = _factoryMethod();
      
      _poolsContainer.AddElementToContainer(createdElement, this);
      
      return createdElement;
    }
  }
}