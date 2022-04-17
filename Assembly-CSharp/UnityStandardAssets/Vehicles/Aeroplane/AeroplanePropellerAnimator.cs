using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053C RID: 1340
	public class AeroplanePropellerAnimator : MonoBehaviour
	{
		// Token: 0x0600222B RID: 8747 RVA: 0x001F2898 File Offset: 0x001F0A98
		private void Awake()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_PropellorModelRenderer = this.m_PropellorModel.GetComponent<Renderer>();
			this.m_PropellorBlurRenderer = this.m_PropellorBlur.GetComponent<Renderer>();
			this.m_PropellorBlur.parent = this.m_PropellorModel;
		}

		// Token: 0x0600222C RID: 8748 RVA: 0x001F28E4 File Offset: 0x001F0AE4
		private void Update()
		{
			this.m_PropellorModel.Rotate(0f, this.m_MaxRpm * this.m_Plane.Throttle * Time.deltaTime * 60f, 0f);
			int num = 0;
			if (this.m_Plane.Throttle > this.m_ThrottleBlurStart)
			{
				num = Mathf.FloorToInt(Mathf.InverseLerp(this.m_ThrottleBlurStart, this.m_ThrottleBlurEnd, this.m_Plane.Throttle) * (float)(this.m_PropellorBlurTextures.Length - 1));
			}
			if (num != this.m_PropellorBlurState)
			{
				this.m_PropellorBlurState = num;
				if (this.m_PropellorBlurState == 0)
				{
					this.m_PropellorModelRenderer.enabled = true;
					this.m_PropellorBlurRenderer.enabled = false;
					return;
				}
				this.m_PropellorModelRenderer.enabled = false;
				this.m_PropellorBlurRenderer.enabled = true;
				this.m_PropellorBlurRenderer.material.mainTexture = this.m_PropellorBlurTextures[this.m_PropellorBlurState];
			}
		}

		// Token: 0x04004AD2 RID: 19154
		[SerializeField]
		private Transform m_PropellorModel;

		// Token: 0x04004AD3 RID: 19155
		[SerializeField]
		private Transform m_PropellorBlur;

		// Token: 0x04004AD4 RID: 19156
		[SerializeField]
		private Texture2D[] m_PropellorBlurTextures;

		// Token: 0x04004AD5 RID: 19157
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurStart = 0.25f;

		// Token: 0x04004AD6 RID: 19158
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurEnd = 0.5f;

		// Token: 0x04004AD7 RID: 19159
		[SerializeField]
		private float m_MaxRpm = 2000f;

		// Token: 0x04004AD8 RID: 19160
		private AeroplaneController m_Plane;

		// Token: 0x04004AD9 RID: 19161
		private int m_PropellorBlurState = -1;

		// Token: 0x04004ADA RID: 19162
		private const float k_RpmToDps = 60f;

		// Token: 0x04004ADB RID: 19163
		private Renderer m_PropellorModelRenderer;

		// Token: 0x04004ADC RID: 19164
		private Renderer m_PropellorBlurRenderer;
	}
}
