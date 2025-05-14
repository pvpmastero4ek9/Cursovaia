using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Core.AnimalsHaos
{
    public class MovementAnimals : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        private Transform _target;
        public Transform Target
        {
            get
            {
                return _target;
            }
            set
            {
                if (value != null) _target = value;
            }
        }

        void Start()
        {
            _agent.updateRotation = false;
		    _agent.updateUpAxis = false;
        }

        private void Update()
        {
            MoveAnimal();
            CheckWayAnimal();
        }

        private void MoveAnimal()
        {
            _agent.SetDestination(_target.position);
        }

        private void CheckWayAnimal()
        {
            if (Vector3.Distance(transform.position, _target.position) < _agent.stoppingDistance + 0.6f)
            {
                Destroy(gameObject);
            }
        }
    }
}
