using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000541 RID: 1345
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x0600224A RID: 8778 RVA: 0x001F57F0 File Offset: 0x001F39F0
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x0600224B RID: 8779 RVA: 0x001F5878 File Offset: 0x001F3A78
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x0600224C RID: 8780 RVA: 0x001F5910 File Offset: 0x001F3B10
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

		// Token: 0x04004B23 RID: 19235
		public Color minColour;

		// Token: 0x04004B24 RID: 19236
		private AeroplaneController m_Jet;

		// Token: 0x04004B25 RID: 19237
		private ParticleSystem m_System;

		// Token: 0x04004B26 RID: 19238
		private float m_OriginalStartSize;

		// Token: 0x04004B27 RID: 19239
		private float m_OriginalLifetime;

		// Token: 0x04004B28 RID: 19240
		private Color m_OriginalStartColor;
	}
}
