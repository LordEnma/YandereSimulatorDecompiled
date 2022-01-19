using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052F RID: 1327
	public class AeroplanePropellerAnimator : MonoBehaviour
	{
		// Token: 0x060021D5 RID: 8661 RVA: 0x001EB90C File Offset: 0x001E9B0C
		private void Awake()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_PropellorModelRenderer = this.m_PropellorModel.GetComponent<Renderer>();
			this.m_PropellorBlurRenderer = this.m_PropellorBlur.GetComponent<Renderer>();
			this.m_PropellorBlur.parent = this.m_PropellorModel;
		}

		// Token: 0x060021D6 RID: 8662 RVA: 0x001EB958 File Offset: 0x001E9B58
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

		// Token: 0x040049E1 RID: 18913
		[SerializeField]
		private Transform m_PropellorModel;

		// Token: 0x040049E2 RID: 18914
		[SerializeField]
		private Transform m_PropellorBlur;

		// Token: 0x040049E3 RID: 18915
		[SerializeField]
		private Texture2D[] m_PropellorBlurTextures;

		// Token: 0x040049E4 RID: 18916
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurStart = 0.25f;

		// Token: 0x040049E5 RID: 18917
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurEnd = 0.5f;

		// Token: 0x040049E6 RID: 18918
		[SerializeField]
		private float m_MaxRpm = 2000f;

		// Token: 0x040049E7 RID: 18919
		private AeroplaneController m_Plane;

		// Token: 0x040049E8 RID: 18920
		private int m_PropellorBlurState = -1;

		// Token: 0x040049E9 RID: 18921
		private const float k_RpmToDps = 60f;

		// Token: 0x040049EA RID: 18922
		private Renderer m_PropellorModelRenderer;

		// Token: 0x040049EB RID: 18923
		private Renderer m_PropellorBlurRenderer;
	}
}
