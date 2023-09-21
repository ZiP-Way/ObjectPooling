using System;

namespace Pools.ObjectPoolContext
{
  public interface IPoolElement : IDisposable
  {
    void Commission();
    void Decommission();
  }
}