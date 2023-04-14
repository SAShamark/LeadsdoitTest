using UnityEngine;

namespace Entities.Point
{
    public interface IPointsProvider
    {
        Transform StartPoint { get; }
        Transform EndPoint { get; }
        Transform LeftPoint { get; }
        Transform RightPoint { get; }
    }
}