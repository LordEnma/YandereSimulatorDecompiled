using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
	public class WaterHoseParticles : MonoBehaviour
	{
		public static float lastSoundTime;

		public float force = 1f;

		private List<ParticleCollisionEvent> m_CollisionEvents = new List<ParticleCollisionEvent>();

		private ParticleSystem m_ParticleSystem;

		private void Start()
		{
			m_ParticleSystem = GetComponent<ParticleSystem>();
		}

		private void OnParticleCollision(GameObject other)
		{
			int collisionEvents = m_ParticleSystem.GetCollisionEvents(other, m_CollisionEvents);
			for (int i = 0; i < collisionEvents; i++)
			{
				if (Time.time > lastSoundTime + 0.2f)
				{
					lastSoundTime = Time.time;
				}
				Rigidbody component = m_CollisionEvents[i].colliderComponent.GetComponent<Rigidbody>();
				if (component != null)
				{
					Vector3 velocity = m_CollisionEvents[i].velocity;
					component.AddForce(velocity * force, ForceMode.Impulse);
				}
				other.BroadcastMessage("Extinguish", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
