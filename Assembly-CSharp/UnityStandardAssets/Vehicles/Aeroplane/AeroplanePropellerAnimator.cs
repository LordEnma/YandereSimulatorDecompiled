using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052C RID: 1324
	public class AeroplanePropellerAnimator : MonoBehaviour
	{
		// Token: 0x060021C8 RID: 8648 RVA: 0x001EA29C File Offset: 0x001E849C
		private void Awake()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_PropellorModelRenderer = this.m_PropellorModel.GetComponent<Renderer>();
			this.m_PropellorBlurRenderer = this.m_PropellorBlur.GetComponent<Renderer>();
			this.m_PropellorBlur.parent = this.m_PropellorModel;
		}

		// Token: 0x060021C9 RID: 8649 RVA: 0x001EA2E8 File Offset: 0x001E84E8
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

		// Token: 0x040049C6 RID: 18886
		[SerializeField]
		private Transform m_PropellorModel;

		// Token: 0x040049C7 RID: 18887
		[SerializeField]
		private Transform m_PropellorBlur;

		// Token: 0x040049C8 RID: 18888
		[SerializeField]
		private Texture2D[] m_PropellorBlurTextures;

		// Token: 0x040049C9 RID: 18889
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurStart = 0.25f;

		// Token: 0x040049CA RID: 18890
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurEnd = 0.5f;

		// Token: 0x040049CB RID: 18891
		[SerializeField]
		private float m_MaxRpm = 2000f;

		// Token: 0x040049CC RID: 18892
		private AeroplaneController m_Plane;

		// Token: 0x040049CD RID: 18893
		private int m_PropellorBlurState = -1;

		// Token: 0x040049CE RID: 18894
		private const float k_RpmToDps = 60f;

		// Token: 0x040049CF RID: 18895
		private Renderer m_PropellorModelRenderer;

		// Token: 0x040049D0 RID: 18896
		private Renderer m_PropellorBlurRenderer;
	}
}
