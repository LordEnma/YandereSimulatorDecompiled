using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053E RID: 1342
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x06002227 RID: 8743 RVA: 0x001F1C8C File Offset: 0x001EFE8C
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x06002228 RID: 8744 RVA: 0x001F1D14 File Offset: 0x001EFF14
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x06002229 RID: 8745 RVA: 0x001F1DAC File Offset: 0x001EFFAC
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

		// Token: 0x04004AD0 RID: 19152
		public Color minColour;

		// Token: 0x04004AD1 RID: 19153
		private AeroplaneController m_Jet;

		// Token: 0x04004AD2 RID: 19154
		private ParticleSystem m_System;

		// Token: 0x04004AD3 RID: 19155
		private float m_OriginalStartSize;

		// Token: 0x04004AD4 RID: 19156
		private float m_OriginalLifetime;

		// Token: 0x04004AD5 RID: 19157
		private Color m_OriginalStartColor;
	}
}
