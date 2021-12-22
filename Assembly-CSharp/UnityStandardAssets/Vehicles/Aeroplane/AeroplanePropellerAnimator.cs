using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052C RID: 1324
	public class AeroplanePropellerAnimator : MonoBehaviour
	{
		// Token: 0x060021C5 RID: 8645 RVA: 0x001E9CAC File Offset: 0x001E7EAC
		private void Awake()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_PropellorModelRenderer = this.m_PropellorModel.GetComponent<Renderer>();
			this.m_PropellorBlurRenderer = this.m_PropellorBlur.GetComponent<Renderer>();
			this.m_PropellorBlur.parent = this.m_PropellorModel;
		}

		// Token: 0x060021C6 RID: 8646 RVA: 0x001E9CF8 File Offset: 0x001E7EF8
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

		// Token: 0x040049BD RID: 18877
		[SerializeField]
		private Transform m_PropellorModel;

		// Token: 0x040049BE RID: 18878
		[SerializeField]
		private Transform m_PropellorBlur;

		// Token: 0x040049BF RID: 18879
		[SerializeField]
		private Texture2D[] m_PropellorBlurTextures;

		// Token: 0x040049C0 RID: 18880
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurStart = 0.25f;

		// Token: 0x040049C1 RID: 18881
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurEnd = 0.5f;

		// Token: 0x040049C2 RID: 18882
		[SerializeField]
		private float m_MaxRpm = 2000f;

		// Token: 0x040049C3 RID: 18883
		private AeroplaneController m_Plane;

		// Token: 0x040049C4 RID: 18884
		private int m_PropellorBlurState = -1;

		// Token: 0x040049C5 RID: 18885
		private const float k_RpmToDps = 60f;

		// Token: 0x040049C6 RID: 18886
		private Renderer m_PropellorModelRenderer;

		// Token: 0x040049C7 RID: 18887
		private Renderer m_PropellorBlurRenderer;
	}
}
