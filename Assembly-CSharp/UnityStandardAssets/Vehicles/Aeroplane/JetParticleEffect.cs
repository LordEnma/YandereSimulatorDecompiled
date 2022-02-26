using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000534 RID: 1332
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x060021F9 RID: 8697 RVA: 0x001EDADC File Offset: 0x001EBCDC
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x060021FA RID: 8698 RVA: 0x001EDB64 File Offset: 0x001EBD64
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x060021FB RID: 8699 RVA: 0x001EDBFC File Offset: 0x001EBDFC
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

		// Token: 0x04004A22 RID: 18978
		public Color minColour;

		// Token: 0x04004A23 RID: 18979
		private AeroplaneController m_Jet;

		// Token: 0x04004A24 RID: 18980
		private ParticleSystem m_System;

		// Token: 0x04004A25 RID: 18981
		private float m_OriginalStartSize;

		// Token: 0x04004A26 RID: 18982
		private float m_OriginalLifetime;

		// Token: 0x04004A27 RID: 18983
		private Color m_OriginalStartColor;
	}
}
