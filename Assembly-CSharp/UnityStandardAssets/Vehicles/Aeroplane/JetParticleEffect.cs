using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052F RID: 1327
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x060021D3 RID: 8659 RVA: 0x001EA61C File Offset: 0x001E881C
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x060021D4 RID: 8660 RVA: 0x001EA6A4 File Offset: 0x001E88A4
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x060021D5 RID: 8661 RVA: 0x001EA73C File Offset: 0x001E893C
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

		// Token: 0x040049DA RID: 18906
		public Color minColour;

		// Token: 0x040049DB RID: 18907
		private AeroplaneController m_Jet;

		// Token: 0x040049DC RID: 18908
		private ParticleSystem m_System;

		// Token: 0x040049DD RID: 18909
		private float m_OriginalStartSize;

		// Token: 0x040049DE RID: 18910
		private float m_OriginalLifetime;

		// Token: 0x040049DF RID: 18911
		private Color m_OriginalStartColor;
	}
}
