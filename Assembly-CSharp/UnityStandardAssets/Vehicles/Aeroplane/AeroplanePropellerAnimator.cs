using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052A RID: 1322
	public class AeroplanePropellerAnimator : MonoBehaviour
	{
		// Token: 0x060021B4 RID: 8628 RVA: 0x001E8578 File Offset: 0x001E6778
		private void Awake()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_PropellorModelRenderer = this.m_PropellorModel.GetComponent<Renderer>();
			this.m_PropellorBlurRenderer = this.m_PropellorBlur.GetComponent<Renderer>();
			this.m_PropellorBlur.parent = this.m_PropellorModel;
		}

		// Token: 0x060021B5 RID: 8629 RVA: 0x001E85C4 File Offset: 0x001E67C4
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

		// Token: 0x0400497E RID: 18814
		[SerializeField]
		private Transform m_PropellorModel;

		// Token: 0x0400497F RID: 18815
		[SerializeField]
		private Transform m_PropellorBlur;

		// Token: 0x04004980 RID: 18816
		[SerializeField]
		private Texture2D[] m_PropellorBlurTextures;

		// Token: 0x04004981 RID: 18817
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurStart = 0.25f;

		// Token: 0x04004982 RID: 18818
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurEnd = 0.5f;

		// Token: 0x04004983 RID: 18819
		[SerializeField]
		private float m_MaxRpm = 2000f;

		// Token: 0x04004984 RID: 18820
		private AeroplaneController m_Plane;

		// Token: 0x04004985 RID: 18821
		private int m_PropellorBlurState = -1;

		// Token: 0x04004986 RID: 18822
		private const float k_RpmToDps = 60f;

		// Token: 0x04004987 RID: 18823
		private Renderer m_PropellorModelRenderer;

		// Token: 0x04004988 RID: 18824
		private Renderer m_PropellorBlurRenderer;
	}
}
