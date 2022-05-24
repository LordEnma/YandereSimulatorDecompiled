using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000541 RID: 1345
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x0600224B RID: 8779 RVA: 0x001F5D58 File Offset: 0x001F3F58
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x0600224C RID: 8780 RVA: 0x001F5DE0 File Offset: 0x001F3FE0
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x0600224D RID: 8781 RVA: 0x001F5E78 File Offset: 0x001F4078
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

		// Token: 0x04004B2C RID: 19244
		public Color minColour;

		// Token: 0x04004B2D RID: 19245
		private AeroplaneController m_Jet;

		// Token: 0x04004B2E RID: 19246
		private ParticleSystem m_System;

		// Token: 0x04004B2F RID: 19247
		private float m_OriginalStartSize;

		// Token: 0x04004B30 RID: 19248
		private float m_OriginalLifetime;

		// Token: 0x04004B31 RID: 19249
		private Color m_OriginalStartColor;
	}
}
