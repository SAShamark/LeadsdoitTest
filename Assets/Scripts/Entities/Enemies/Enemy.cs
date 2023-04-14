using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entities.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private IPointsProvider _pointsProvider;
        private IDestroyable _destroyable;
        private ICatcheable[] _catcheables;

        [Inject]
        private void Construct(IPointsProvider pointsProvider)
        {
            _pointsProvider = pointsProvider;
        }

        private void Start()
        {
            _destroyable = gameObject.GetComponent<IDestroyable>();
            _catcheables = gameObject.GetComponents<ICatcheable>();
        }

        private void Update()
        {
            Destroy();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ICatchHandler catchHandler))
            {
                Catch(catchHandler);
            }
        }

        private void ProcessCollider(Collider other)
        {
        }

        private void Catch(ICatchHandler catchHandler)
        {
            foreach (ICatcheable catcheable in _catcheables)
            {
                catcheable.Catch(catchHandler);
            }

            CatchDestroy();
        }

        private void CatchDestroy()
        {
            _destroyable.DestroyObject();
        }

        private void Destroy()
        {
            if (transform.position.y < _pointsProvider.EndPoint.position.y)
            {
                _destroyable.DestroyObject();
            }
        }
    }
}