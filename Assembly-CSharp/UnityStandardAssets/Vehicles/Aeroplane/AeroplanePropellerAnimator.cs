using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053D RID: 1341
	public class AeroplanePropellerAnimator : MonoBehaviour
	{
		// Token: 0x06002234 RID: 8756 RVA: 0x001F3D24 File Offset: 0x001F1F24
		private void Awake()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_PropellorModelRenderer = this.m_PropellorModel.GetComponent<Renderer>();
			this.m_PropellorBlurRenderer = this.m_PropellorBlur.GetComponent<Renderer>();
			this.m_PropellorBlur.parent = this.m_PropellorModel;
		}

		// Token: 0x06002235 RID: 8757 RVA: 0x001F3D70 File Offset: 0x001F1F70
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

		// Token: 0x04004AE8 RID: 19176
		[SerializeField]
		private Transform m_PropellorModel;

		// Token: 0x04004AE9 RID: 19177
		[SerializeField]
		private Transform m_PropellorBlur;

		// Token: 0x04004AEA RID: 19178
		[SerializeField]
		private Texture2D[] m_PropellorBlurTextures;

		// Token: 0x04004AEB RID: 19179
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurStart = 0.25f;

		// Token: 0x04004AEC RID: 19180
		[SerializeField]
		[Range(0f, 1f)]
		private float m_ThrottleBlurEnd = 0.5f;

		// Token: 0x04004AED RID: 19181
		[SerializeField]
		private float m_MaxRpm = 2000f;

		// Token: 0x04004AEE RID: 19182
		private AeroplaneController m_Plane;

		// Token: 0x04004AEF RID: 19183
		private int m_PropellorBlurState = -1;

		// Token: 0x04004AF0 RID: 19184
		private const float k_RpmToDps = 60f;

		// Token: 0x04004AF1 RID: 19185
		private Renderer m_PropellorModelRenderer;

		// Token: 0x04004AF2 RID: 19186
		private Renderer m_PropellorBlurRenderer;
	}
}
