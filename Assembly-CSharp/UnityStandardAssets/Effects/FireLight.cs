using UnityEngine;

namespace UnityStandardAssets.Effects
{
	public class FireLight : MonoBehaviour
	{
		private float m_Rnd;

		private bool m_Burning = true;

		private Light m_Light;

		private void Start()
		{
			m_Rnd = Random.value * 100f;
			m_Light = GetComponent<Light>();
		}

		private void Update()
		{
			if (m_Burning)
			{
				m_Light.intensity = 2f * Mathf.PerlinNoise(m_Rnd + Time.time, m_Rnd + 1f + Time.time * 1f);
				float x = Mathf.PerlinNoise(m_Rnd + 0f + Time.time * 2f, m_Rnd + 1f + Time.time * 2f) - 0.5f;
				float y = Mathf.PerlinNoise(m_Rnd + 2f + Time.time * 2f, m_Rnd + 3f + Time.time * 2f) - 0.5f;
				float z = Mathf.PerlinNoise(m_Rnd + 4f + Time.time * 2f, m_Rnd + 5f + Time.time * 2f) - 0.5f;
				base.transform.localPosition = Vector3.up + new Vector3(x, y, z) * 1f;
			}
		}

		public void Extinguish()
		{
			m_Burning = false;
			m_Light.enabled = false;
		}
	}
}
