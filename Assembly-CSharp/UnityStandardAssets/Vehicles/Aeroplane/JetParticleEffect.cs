using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053F RID: 1343
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x06002236 RID: 8758 RVA: 0x001F2C18 File Offset: 0x001F0E18
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x06002237 RID: 8759 RVA: 0x001F2CA0 File Offset: 0x001F0EA0
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x06002238 RID: 8760 RVA: 0x001F2D38 File Offset: 0x001F0F38
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

		// Token: 0x04004AE6 RID: 19174
		public Color minColour;

		// Token: 0x04004AE7 RID: 19175
		private AeroplaneController m_Jet;

		// Token: 0x04004AE8 RID: 19176
		private ParticleSystem m_System;

		// Token: 0x04004AE9 RID: 19177
		private float m_OriginalStartSize;

		// Token: 0x04004AEA RID: 19178
		private float m_OriginalLifetime;

		// Token: 0x04004AEB RID: 19179
		private Color m_OriginalStartColor;
	}
}
