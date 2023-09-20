using UnityEngine;

namespace Pool.Container
{
  public interface IMonoPoolElement : IPoolElement
  {
    Transform Transform { get; }
  }
}