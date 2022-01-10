using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000531 RID: 1329
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x060021DE RID: 8670 RVA: 0x001EAFBC File Offset: 0x001E91BC
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x060021DF RID: 8671 RVA: 0x001EB044 File Offset: 0x001E9244
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x060021E0 RID: 8672 RVA: 0x001EB0DC File Offset: 0x001E92DC
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

		// Token: 0x040049EE RID: 18926
		public Color minColour;

		// Token: 0x040049EF RID: 18927
		private AeroplaneController m_Jet;

		// Token: 0x040049F0 RID: 18928
		private ParticleSystem m_System;

		// Token: 0x040049F1 RID: 18929
		private float m_OriginalStartSize;

		// Token: 0x040049F2 RID: 18930
		private float m_OriginalLifetime;

		// Token: 0x040049F3 RID: 18931
		private Color m_OriginalStartColor;
	}
}
