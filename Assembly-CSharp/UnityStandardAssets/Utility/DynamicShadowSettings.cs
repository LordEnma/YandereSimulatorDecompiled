using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class DynamicShadowSettings : MonoBehaviour
	{
		public Light sunLight;

		public float minHeight = 10f;

		public float minShadowDistance = 80f;

		public float minShadowBias = 1f;

		public float maxHeight = 1000f;

		public float maxShadowDistance = 10000f;

		public float maxShadowBias = 0.1f;

		public float adaptTime = 1f;

		private float m_SmoothHeight;

		private float m_ChangeSpeed;

		private float m_OriginalStrength = 1f;

		private void Start()
		{
			m_OriginalStrength = sunLight.shadowStrength;
		}

		private void Update()
		{
			Ray ray = new Ray(Camera.main.transform.position, -Vector3.up);
			float num = base.transform.position.y;
			if (Physics.Raycast(ray, out var hitInfo))
			{
				num = hitInfo.distance;
			}
			if (Mathf.Abs(num - m_SmoothHeight) > 1f)
			{
				m_SmoothHeight = Mathf.SmoothDamp(m_SmoothHeight, num, ref m_ChangeSpeed, adaptTime);
			}
			float num2 = Mathf.InverseLerp(minHeight, maxHeight, m_SmoothHeight);
			QualitySettings.shadowDistance = Mathf.Lerp(minShadowDistance, maxShadowDistance, num2);
			sunLight.shadowBias = Mathf.Lerp(minShadowBias, maxShadowBias, 1f - (1f - num2) * (1f - num2));
			sunLight.shadowStrength = Mathf.Lerp(m_OriginalStrength, 0f, num2);
		}
	}
}
