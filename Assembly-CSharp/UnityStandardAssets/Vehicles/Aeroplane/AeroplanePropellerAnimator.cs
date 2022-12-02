using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	public class AeroplanePropellerAnimator : MonoBehaviour
	{
		[SerializeField]
		private Transform m_PropellorModel;

		[SerializeField]
		private Transform m_PropellorBlur;

		[SerializeField]
		private Texture2D[] m_PropellorBlurTextures;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurStart = 0.25f;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurEnd = 0.5f;

		[SerializeField]
		private float m_MaxRpm = 2000f;

		private AeroplaneController m_Plane;

		private int m_PropellorBlurState = -1;

		private const float k_RpmToDps = 60f;

		private Renderer m_PropellorModelRenderer;

		private Renderer m_PropellorBlurRenderer;

		private void Awake()
		{
			m_Plane = GetComponent<AeroplaneController>();
			m_PropellorModelRenderer = m_PropellorModel.GetComponent<Renderer>();
			m_PropellorBlurRenderer = m_PropellorBlur.GetComponent<Renderer>();
			m_PropellorBlur.parent = m_PropellorModel;
		}

		private void Update()
		{
			m_PropellorModel.Rotate(0f, m_MaxRpm * m_Plane.Throttle * Time.deltaTime * 60f, 0f);
			int num = 0;
			if (m_Plane.Throttle > m_ThrottleBlurStart)
			{
				num = Mathf.FloorToInt(Mathf.InverseLerp(m_ThrottleBlurStart, m_ThrottleBlurEnd, m_Plane.Throttle) * (float)(m_PropellorBlurTextures.Length - 1));
			}
			if (num != m_PropellorBlurState)
			{
				m_PropellorBlurState = num;
				if (m_PropellorBlurState == 0)
				{
					m_PropellorModelRenderer.enabled = true;
					m_PropellorBlurRenderer.enabled = false;
				}
				else
				{
					m_PropellorModelRenderer.enabled = false;
					m_PropellorBlurRenderer.enabled = true;
					m_PropellorBlurRenderer.material.mainTexture = m_PropellorBlurTextures[m_PropellorBlurState];
				}
			}
		}
	}
}
