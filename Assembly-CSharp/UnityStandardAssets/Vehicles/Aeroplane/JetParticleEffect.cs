using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000532 RID: 1330
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x060021E4 RID: 8676 RVA: 0x001EC52C File Offset: 0x001EA72C
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x060021E5 RID: 8677 RVA: 0x001EC5B4 File Offset: 0x001EA7B4
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x060021E6 RID: 8678 RVA: 0x001EC64C File Offset: 0x001EA84C
		private AeroplaneController FindAeroplaneParent()
		{
			Transform transform = base.transform;
			while (transform != null)
			{
				AeroplaneController component = transform.GetComponent<AeroplaneController>();
				if (!(component == null))
				{
					return component;
				}
				transform = transform.parent;
			}
			throw new Exception(" AeroplaneContoller not found in object hierarchy");
		}

		// Token: 0x04004A00 RID: 18944
		public Color minColour;

		// Token: 0x04004A01 RID: 18945
		private AeroplaneController m_Jet;

		// Token: 0x04004A02 RID: 18946
		private ParticleSystem m_System;

		// Token: 0x04004A03 RID: 18947
		private float m_OriginalStartSize;

		// Token: 0x04004A04 RID: 18948
		private float m_OriginalLifetime;

		// Token: 0x04004A05 RID: 18949
		private Color m_OriginalStartColor;
	}
}
