using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052F RID: 1327
	public class AeroplanePropellerAnimator : MonoBehaviour
	{
		// Token: 0x060021DB RID: 8667 RVA: 0x001EC4C4 File Offset: 0x001EA6C4
		private void Awake()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_PropellorModelRenderer = this.m_PropellorModel.GetComponent<Renderer>();
			this.m_PropellorBlurRenderer = this.m_PropellorBlur.GetComponent<Renderer>();
			this.m_PropellorBlur.parent = this.m_PropellorModel;
		}

		// Token: 0x060021DC RID: 8668 RVA: 0x001EC510 File Offset: 0x001EA710
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

		// Token: 0x040049F2 RID: 18930
		[SerializeField]
		private Transform m_PropellorModel;

		// Token: 0x040049F3 RID: 18931
		[SerializeField]
		private Transform m_PropellorBlur;

		// Token: 0x040049F4 RID: 18932
		[SerializeField]
		private Texture2D[] m_PropellorBlurTextures;

		// Token: 0x040049F5 RID: 18933
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurStart = 0.25f;

		// Token: 0x040049F6 RID: 18934
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurEnd = 0.5f;

		// Token: 0x040049F7 RID: 18935
		[SerializeField]
		private float m_MaxRpm = 2000f;

		// Token: 0x040049F8 RID: 18936
		private AeroplaneController m_Plane;

		// Token: 0x040049F9 RID: 18937
		private int m_PropellorBlurState = -1;

		// Token: 0x040049FA RID: 18938
		private const float k_RpmToDps = 60f;

		// Token: 0x040049FB RID: 18939
		private Renderer m_PropellorModelRenderer;

		// Token: 0x040049FC RID: 18940
		private Renderer m_PropellorBlurRenderer;
	}
}
