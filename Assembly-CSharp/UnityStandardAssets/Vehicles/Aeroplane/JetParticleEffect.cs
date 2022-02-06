using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000532 RID: 1330
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x060021E9 RID: 8681 RVA: 0x001ECA48 File Offset: 0x001EAC48
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x060021EA RID: 8682 RVA: 0x001ECAD0 File Offset: 0x001EACD0
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x001ECB68 File Offset: 0x001EAD68
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

		// Token: 0x04004A09 RID: 18953
		public Color minColour;

		// Token: 0x04004A0A RID: 18954
		private AeroplaneController m_Jet;

		// Token: 0x04004A0B RID: 18955
		private ParticleSystem m_System;

		// Token: 0x04004A0C RID: 18956
		private float m_OriginalStartSize;

		// Token: 0x04004A0D RID: 18957
		private float m_OriginalLifetime;

		// Token: 0x04004A0E RID: 18958
		private Color m_OriginalStartColor;
	}
}
