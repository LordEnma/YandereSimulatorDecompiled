using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053E RID: 1342
	public class AeroplanePropellerAnimator : MonoBehaviour
	{
		// Token: 0x06002240 RID: 8768 RVA: 0x001F59D8 File Offset: 0x001F3BD8
		private void Awake()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_PropellorModelRenderer = this.m_PropellorModel.GetComponent<Renderer>();
			this.m_PropellorBlurRenderer = this.m_PropellorBlur.GetComponent<Renderer>();
			this.m_PropellorBlur.parent = this.m_PropellorModel;
		}

		// Token: 0x06002241 RID: 8769 RVA: 0x001F5A24 File Offset: 0x001F3C24
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

		// Token: 0x04004B18 RID: 19224
		[SerializeField]
		private Transform m_PropellorModel;

		// Token: 0x04004B19 RID: 19225
		[SerializeField]
		private Transform m_PropellorBlur;

		// Token: 0x04004B1A RID: 19226
		[SerializeField]
		private Texture2D[] m_PropellorBlurTextures;

		// Token: 0x04004B1B RID: 19227
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurStart = 0.25f;

		// Token: 0x04004B1C RID: 19228
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurEnd = 0.5f;

		// Token: 0x04004B1D RID: 19229
		[SerializeField]
		private float m_MaxRpm = 2000f;

		// Token: 0x04004B1E RID: 19230
		private AeroplaneController m_Plane;

		// Token: 0x04004B1F RID: 19231
		private int m_PropellorBlurState = -1;

		// Token: 0x04004B20 RID: 19232
		private const float k_RpmToDps = 60f;

		// Token: 0x04004B21 RID: 19233
		private Renderer m_PropellorModelRenderer;

		// Token: 0x04004B22 RID: 19234
		private Renderer m_PropellorBlurRenderer;
	}
}
