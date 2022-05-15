using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053E RID: 1342
	public class AeroplanePropellerAnimator : MonoBehaviour
	{
		// Token: 0x0600223F RID: 8767 RVA: 0x001F5470 File Offset: 0x001F3670
		private void Awake()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_PropellorModelRenderer = this.m_PropellorModel.GetComponent<Renderer>();
			this.m_PropellorBlurRenderer = this.m_PropellorBlur.GetComponent<Renderer>();
			this.m_PropellorBlur.parent = this.m_PropellorModel;
		}

		// Token: 0x06002240 RID: 8768 RVA: 0x001F54BC File Offset: 0x001F36BC
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

		// Token: 0x04004B0F RID: 19215
		[SerializeField]
		private Transform m_PropellorModel;

		// Token: 0x04004B10 RID: 19216
		[SerializeField]
		private Transform m_PropellorBlur;

		// Token: 0x04004B11 RID: 19217
		[SerializeField]
		private Texture2D[] m_PropellorBlurTextures;

		// Token: 0x04004B12 RID: 19218
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurStart = 0.25f;

		// Token: 0x04004B13 RID: 19219
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurEnd = 0.5f;

		// Token: 0x04004B14 RID: 19220
		[SerializeField]
		private float m_MaxRpm = 2000f;

		// Token: 0x04004B15 RID: 19221
		private AeroplaneController m_Plane;

		// Token: 0x04004B16 RID: 19222
		private int m_PropellorBlurState = -1;

		// Token: 0x04004B17 RID: 19223
		private const float k_RpmToDps = 60f;

		// Token: 0x04004B18 RID: 19224
		private Renderer m_PropellorModelRenderer;

		// Token: 0x04004B19 RID: 19225
		private Renderer m_PropellorBlurRenderer;
	}
}
