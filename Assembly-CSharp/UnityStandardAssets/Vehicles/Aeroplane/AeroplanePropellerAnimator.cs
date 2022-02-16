using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000530 RID: 1328
	public class AeroplanePropellerAnimator : MonoBehaviour
	{
		// Token: 0x060021E5 RID: 8677 RVA: 0x001ECB7C File Offset: 0x001EAD7C
		private void Awake()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_PropellorModelRenderer = this.m_PropellorModel.GetComponent<Renderer>();
			this.m_PropellorBlurRenderer = this.m_PropellorBlur.GetComponent<Renderer>();
			this.m_PropellorBlur.parent = this.m_PropellorModel;
		}

		// Token: 0x060021E6 RID: 8678 RVA: 0x001ECBC8 File Offset: 0x001EADC8
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

		// Token: 0x040049FE RID: 18942
		[SerializeField]
		private Transform m_PropellorModel;

		// Token: 0x040049FF RID: 18943
		[SerializeField]
		private Transform m_PropellorBlur;

		// Token: 0x04004A00 RID: 18944
		[SerializeField]
		private Texture2D[] m_PropellorBlurTextures;

		// Token: 0x04004A01 RID: 18945
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurStart = 0.25f;

		// Token: 0x04004A02 RID: 18946
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurEnd = 0.5f;

		// Token: 0x04004A03 RID: 18947
		[SerializeField]
		private float m_MaxRpm = 2000f;

		// Token: 0x04004A04 RID: 18948
		private AeroplaneController m_Plane;

		// Token: 0x04004A05 RID: 18949
		private int m_PropellorBlurState = -1;

		// Token: 0x04004A06 RID: 18950
		private const float k_RpmToDps = 60f;

		// Token: 0x04004A07 RID: 18951
		private Renderer m_PropellorModelRenderer;

		// Token: 0x04004A08 RID: 18952
		private Renderer m_PropellorBlurRenderer;
	}
}
