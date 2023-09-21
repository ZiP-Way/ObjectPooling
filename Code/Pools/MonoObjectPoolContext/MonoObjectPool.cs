using System;
using System.Collections.Generic;
using System.Linq;
using Container;
using Factory;
using Pools.ObjectPoolContext;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Pools.MonoObjectPoolContext
{
  public class MonoObjectPool<T> : IPool<T> where T : IMonoPoolElement
  {
    #region Properties

    public bool HasFreeElements => _elements.Count > 0;
    public int FreeElementsCount => _elements.Count;

    #endregion

    #region Fields

    private readonly IGlobalElementsContainer _poolsContainer;
    private readonly Func<T> _factoryMethod;
    
    private HashSet<T> _elements;
    private Transform _container;

    #endregion

    public MonoObjectPool(IFactory<T> factory, IGlobalElementsContainer poolsContainer)
    {
      _poolsContainer = poolsContainer;
      _factoryMethod = factory.Create;
    }

    public void CreatePool(string poolName, int elementsCount)
    {
      _elements = new HashSet<T>(elementsCount);
      
      CreatePoolContainer(poolName);
      
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
      T monoElement = (T)element;
      
      monoElement.Decommission();
      _elements.Add(monoElement);
      
      monoElement.Transform.parent = _container;
    }

    public void RemoveElementFromPool(T element)
    {
      _elements.Remove(element);
      _poolsContainer.RemoveElementFromContainer(element);
      
      Object.Destroy(element.Transform.gameObject);
    }

    public void ClearPool()
    {
      foreach (T element in _elements) 
        RemoveElementFromPool(element);
      
      _elements.Clear();
    }
    
    private T CreateElement()
    {
      T createdElement = _factoryMethod();

      createdElement.Transform.parent = _container;
      _poolsContainer.AddElementToContainer(createdElement, this);
      
      return createdElement;
    }

    private void CreatePoolContainer(string poolName) => 
      _container = new GameObject(poolName).transform;
  }
}