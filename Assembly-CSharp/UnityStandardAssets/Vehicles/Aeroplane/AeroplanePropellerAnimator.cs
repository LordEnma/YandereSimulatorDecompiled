using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000536 RID: 1334
	public class AeroplanePropellerAnimator : MonoBehaviour
	{
		// Token: 0x0600220C RID: 8716 RVA: 0x001F009C File Offset: 0x001EE29C
		private void Awake()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_PropellorModelRenderer = this.m_PropellorModel.GetComponent<Renderer>();
			this.m_PropellorBlurRenderer = this.m_PropellorBlur.GetComponent<Renderer>();
			this.m_PropellorBlur.parent = this.m_PropellorModel;
		}

		// Token: 0x0600220D RID: 8717 RVA: 0x001F00E8 File Offset: 0x001EE2E8
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

		// Token: 0x04004A8A RID: 19082
		[SerializeField]
		private Transform m_PropellorModel;

		// Token: 0x04004A8B RID: 19083
		[SerializeField]
		private Transform m_PropellorBlur;

		// Token: 0x04004A8C RID: 19084
		[SerializeField]
		private Texture2D[] m_PropellorBlurTextures;

		// Token: 0x04004A8D RID: 19085
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurStart = 0.25f;

		// Token: 0x04004A8E RID: 19086
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurEnd = 0.5f;

		// Token: 0x04004A8F RID: 19087
		[SerializeField]
		private float m_MaxRpm = 2000f;

		// Token: 0x04004A90 RID: 19088
		private AeroplaneController m_Plane;

		// Token: 0x04004A91 RID: 19089
		private int m_PropellorBlurState = -1;

		// Token: 0x04004A92 RID: 19090
		private const float k_RpmToDps = 60f;

		// Token: 0x04004A93 RID: 19091
		private Renderer m_PropellorModelRenderer;

		// Token: 0x04004A94 RID: 19092
		private Renderer m_PropellorBlurRenderer;
	}
}
