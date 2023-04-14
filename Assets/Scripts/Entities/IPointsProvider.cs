using UnityEngine;

namespace Entities
{
    public interface IPointsProvider
    {
        Transform StartPoint { get; }
        Transform EndPoint { get; }
        Transform LeftPoint { get; }
        Transform RightPoint { get; }
    }
}