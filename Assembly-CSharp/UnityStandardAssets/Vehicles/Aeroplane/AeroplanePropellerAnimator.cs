using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053B RID: 1339
	public class AeroplanePropellerAnimator : MonoBehaviour
	{
		// Token: 0x0600221C RID: 8732 RVA: 0x001F190C File Offset: 0x001EFB0C
		private void Awake()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_PropellorModelRenderer = this.m_PropellorModel.GetComponent<Renderer>();
			this.m_PropellorBlurRenderer = this.m_PropellorBlur.GetComponent<Renderer>();
			this.m_PropellorBlur.parent = this.m_PropellorModel;
		}

		// Token: 0x0600221D RID: 8733 RVA: 0x001F1958 File Offset: 0x001EFB58
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

		// Token: 0x04004ABC RID: 19132
		[SerializeField]
		private Transform m_PropellorModel;

		// Token: 0x04004ABD RID: 19133
		[SerializeField]
		private Transform m_PropellorBlur;

		// Token: 0x04004ABE RID: 19134
		[SerializeField]
		private Texture2D[] m_PropellorBlurTextures;

		// Token: 0x04004ABF RID: 19135
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurStart = 0.25f;

		// Token: 0x04004AC0 RID: 19136
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurEnd = 0.5f;

		// Token: 0x04004AC1 RID: 19137
		[SerializeField]
		private float m_MaxRpm = 2000f;

		// Token: 0x04004AC2 RID: 19138
		private AeroplaneController m_Plane;

		// Token: 0x04004AC3 RID: 19139
		private int m_PropellorBlurState = -1;

		// Token: 0x04004AC4 RID: 19140
		private const float k_RpmToDps = 60f;

		// Token: 0x04004AC5 RID: 19141
		private Renderer m_PropellorModelRenderer;

		// Token: 0x04004AC6 RID: 19142
		private Renderer m_PropellorBlurRenderer;
	}
}
