using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000539 RID: 1337
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x06002217 RID: 8727 RVA: 0x001F041C File Offset: 0x001EE61C
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x06002218 RID: 8728 RVA: 0x001F04A4 File Offset: 0x001EE6A4
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x06002219 RID: 8729 RVA: 0x001F053C File Offset: 0x001EE73C
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

		// Token: 0x04004A9E RID: 19102
		public Color minColour;

		// Token: 0x04004A9F RID: 19103
		private AeroplaneController m_Jet;

		// Token: 0x04004AA0 RID: 19104
		private ParticleSystem m_System;

		// Token: 0x04004AA1 RID: 19105
		private float m_OriginalStartSize;

		// Token: 0x04004AA2 RID: 19106
		private float m_OriginalLifetime;

		// Token: 0x04004AA3 RID: 19107
		private Color m_OriginalStartColor;
	}
}
