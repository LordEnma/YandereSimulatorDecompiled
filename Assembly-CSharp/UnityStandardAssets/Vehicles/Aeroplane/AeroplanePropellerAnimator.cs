using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000532 RID: 1330
	public class AeroplanePropellerAnimator : MonoBehaviour
	{
		// Token: 0x060021F4 RID: 8692 RVA: 0x001EE134 File Offset: 0x001EC334
		private void Awake()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_PropellorModelRenderer = this.m_PropellorModel.GetComponent<Renderer>();
			this.m_PropellorBlurRenderer = this.m_PropellorBlur.GetComponent<Renderer>();
			this.m_PropellorBlur.parent = this.m_PropellorModel;
		}

		// Token: 0x060021F5 RID: 8693 RVA: 0x001EE180 File Offset: 0x001EC380
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

		// Token: 0x04004A2B RID: 18987
		[SerializeField]
		private Transform m_PropellorModel;

		// Token: 0x04004A2C RID: 18988
		[SerializeField]
		private Transform m_PropellorBlur;

		// Token: 0x04004A2D RID: 18989
		[SerializeField]
		private Texture2D[] m_PropellorBlurTextures;

		// Token: 0x04004A2E RID: 18990
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurStart = 0.25f;

		// Token: 0x04004A2F RID: 18991
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurEnd = 0.5f;

		// Token: 0x04004A30 RID: 18992
		[SerializeField]
		private float m_MaxRpm = 2000f;

		// Token: 0x04004A31 RID: 18993
		private AeroplaneController m_Plane;

		// Token: 0x04004A32 RID: 18994
		private int m_PropellorBlurState = -1;

		// Token: 0x04004A33 RID: 18995
		private const float k_RpmToDps = 60f;

		// Token: 0x04004A34 RID: 18996
		private Renderer m_PropellorModelRenderer;

		// Token: 0x04004A35 RID: 18997
		private Renderer m_PropellorBlurRenderer;
	}
}
