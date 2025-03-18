using UnityEngine;

namespace UnityStandardAssets.Effects
{
	public class ExtinguishableParticleSystem : MonoBehaviour
	{
		public float multiplier = 1f;

		private ParticleSystem[] m_Systems;

		private void Start()
		{
			m_Systems = GetComponentsInChildren<ParticleSystem>();
		}

		public void Extinguish()
		{
			ParticleSystem[] systems = m_Systems;
			for (int i = 0; i < systems.Length; i++)
			{
				ParticleSystem.EmissionModule emission = systems[i].emission;
				emission.enabled = false;
			}
		}
	}
}
