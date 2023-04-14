using Entities;
using Entities.Enemies;
using UnityEngine;

public class KillCatch : MonoBehaviour, ICatcheable
{
    public void Catch(ICatchHandler catchHandler)
    {
        catchHandler.Die();
    }
}