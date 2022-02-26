using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000531 RID: 1329
	public class AeroplanePropellerAnimator : MonoBehaviour
	{
		// Token: 0x060021EE RID: 8686 RVA: 0x001ED75C File Offset: 0x001EB95C
		private void Awake()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_PropellorModelRenderer = this.m_PropellorModel.GetComponent<Renderer>();
			this.m_PropellorBlurRenderer = this.m_PropellorBlur.GetComponent<Renderer>();
			this.m_PropellorBlur.parent = this.m_PropellorModel;
		}

		// Token: 0x060021EF RID: 8687 RVA: 0x001ED7A8 File Offset: 0x001EB9A8
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

		// Token: 0x04004A0E RID: 18958
		[SerializeField]
		private Transform m_PropellorModel;

		// Token: 0x04004A0F RID: 18959
		[SerializeField]
		private Transform m_PropellorBlur;

		// Token: 0x04004A10 RID: 18960
		[SerializeField]
		private Texture2D[] m_PropellorBlurTextures;

		// Token: 0x04004A11 RID: 18961
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurStart = 0.25f;

		// Token: 0x04004A12 RID: 18962
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurEnd = 0.5f;

		// Token: 0x04004A13 RID: 18963
		[SerializeField]
		private float m_MaxRpm = 2000f;

		// Token: 0x04004A14 RID: 18964
		private AeroplaneController m_Plane;

		// Token: 0x04004A15 RID: 18965
		private int m_PropellorBlurState = -1;

		// Token: 0x04004A16 RID: 18966
		private const float k_RpmToDps = 60f;

		// Token: 0x04004A17 RID: 18967
		private Renderer m_PropellorModelRenderer;

		// Token: 0x04004A18 RID: 18968
		private Renderer m_PropellorBlurRenderer;
	}
}
