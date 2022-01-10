using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052E RID: 1326
	public class AeroplanePropellerAnimator : MonoBehaviour
	{
		// Token: 0x060021D3 RID: 8659 RVA: 0x001EAC3C File Offset: 0x001E8E3C
		private void Awake()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_PropellorModelRenderer = this.m_PropellorModel.GetComponent<Renderer>();
			this.m_PropellorBlurRenderer = this.m_PropellorBlur.GetComponent<Renderer>();
			this.m_PropellorBlur.parent = this.m_PropellorModel;
		}

		// Token: 0x060021D4 RID: 8660 RVA: 0x001EAC88 File Offset: 0x001E8E88
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

		// Token: 0x040049DA RID: 18906
		[SerializeField]
		private Transform m_PropellorModel;

		// Token: 0x040049DB RID: 18907
		[SerializeField]
		private Transform m_PropellorBlur;

		// Token: 0x040049DC RID: 18908
		[SerializeField]
		private Texture2D[] m_PropellorBlurTextures;

		// Token: 0x040049DD RID: 18909
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurStart = 0.25f;

		// Token: 0x040049DE RID: 18910
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurEnd = 0.5f;

		// Token: 0x040049DF RID: 18911
		[SerializeField]
		private float m_MaxRpm = 2000f;

		// Token: 0x040049E0 RID: 18912
		private AeroplaneController m_Plane;

		// Token: 0x040049E1 RID: 18913
		private int m_PropellorBlurState = -1;

		// Token: 0x040049E2 RID: 18914
		private const float k_RpmToDps = 60f;

		// Token: 0x040049E3 RID: 18915
		private Renderer m_PropellorModelRenderer;

		// Token: 0x040049E4 RID: 18916
		private Renderer m_PropellorBlurRenderer;
	}
}
