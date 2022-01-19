using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000532 RID: 1330
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x060021E0 RID: 8672 RVA: 0x001EBC8C File Offset: 0x001E9E8C
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x060021E1 RID: 8673 RVA: 0x001EBD14 File Offset: 0x001E9F14
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x060021E2 RID: 8674 RVA: 0x001EBDAC File Offset: 0x001E9FAC
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

		// Token: 0x040049F5 RID: 18933
		public Color minColour;

		// Token: 0x040049F6 RID: 18934
		private AeroplaneController m_Jet;

		// Token: 0x040049F7 RID: 18935
		private ParticleSystem m_System;

		// Token: 0x040049F8 RID: 18936
		private float m_OriginalStartSize;

		// Token: 0x040049F9 RID: 18937
		private float m_OriginalLifetime;

		// Token: 0x040049FA RID: 18938
		private Color m_OriginalStartColor;
	}
}
