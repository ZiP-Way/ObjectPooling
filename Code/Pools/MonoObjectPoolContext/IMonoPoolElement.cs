using Pools.ObjectPoolContext;
using UnityEngine;

namespace Pools.MonoObjectPoolContext
{
  public interface IMonoPoolElement : IPoolElement
  {
    Transform Transform { get; }
  }
}