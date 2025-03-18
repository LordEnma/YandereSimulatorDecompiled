using UnityEngine;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof(NavMeshAgent))]
	[RequireComponent(typeof(ThirdPersonCharacter))]
	public class AICharacterControl : MonoBehaviour
	{
		public Transform target;

		public NavMeshAgent agent { get; private set; }

		public ThirdPersonCharacter character { get; private set; }

		private void Start()
		{
			agent = GetComponentInChildren<NavMeshAgent>();
			character = GetComponent<ThirdPersonCharacter>();
			agent.updateRotation = false;
			agent.updatePosition = true;
		}

		private void Update()
		{
			if (target != null)
			{
				agent.SetDestination(target.position);
			}
			if (agent.remainingDistance > agent.stoppingDistance)
			{
				character.Move(agent.desiredVelocity, crouch: false, jump: false);
			}
			else
			{
				character.Move(Vector3.zero, crouch: false, jump: false);
			}
		}

		public void SetTarget(Transform target)
		{
			this.target = target;
		}
	}
}
