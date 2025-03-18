using UnityEngine;

namespace UnityStandardAssets.Effects
{
	public class Hose : MonoBehaviour
	{
		public float maxPower = 20f;

		public float minPower = 5f;

		public float changeSpeed = 5f;

		public ParticleSystem[] hoseWaterSystems;

		public Renderer systemRenderer;

		private float m_Power;

		private void Update()
		{
			m_Power = Mathf.Lerp(m_Power, Input.GetMouseButton(0) ? maxPower : minPower, Time.deltaTime * changeSpeed);
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				systemRenderer.enabled = !systemRenderer.enabled;
			}
			ParticleSystem[] array = hoseWaterSystems;
			foreach (ParticleSystem obj in array)
			{
				ParticleSystem.MainModule main = obj.main;
				main.startSpeed = m_Power;
				ParticleSystem.EmissionModule emission = obj.emission;
				emission.enabled = m_Power > minPower * 1.1f;
			}
		}
	}
}
