using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000540 RID: 1344
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x0600223F RID: 8767 RVA: 0x001F40A4 File Offset: 0x001F22A4
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x06002240 RID: 8768 RVA: 0x001F412C File Offset: 0x001F232C
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x06002241 RID: 8769 RVA: 0x001F41C4 File Offset: 0x001F23C4
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

		// Token: 0x04004AFC RID: 19196
		public Color minColour;

		// Token: 0x04004AFD RID: 19197
		private AeroplaneController m_Jet;

		// Token: 0x04004AFE RID: 19198
		private ParticleSystem m_System;

		// Token: 0x04004AFF RID: 19199
		private float m_OriginalStartSize;

		// Token: 0x04004B00 RID: 19200
		private float m_OriginalLifetime;

		// Token: 0x04004B01 RID: 19201
		private Color m_OriginalStartColor;
	}
}
