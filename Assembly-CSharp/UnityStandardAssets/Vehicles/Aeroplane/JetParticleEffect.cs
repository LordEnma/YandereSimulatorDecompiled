using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053F RID: 1343
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x0600222F RID: 8751 RVA: 0x001F21BC File Offset: 0x001F03BC
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x06002230 RID: 8752 RVA: 0x001F2244 File Offset: 0x001F0444
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x06002231 RID: 8753 RVA: 0x001F22DC File Offset: 0x001F04DC
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

		// Token: 0x04004AD4 RID: 19156
		public Color minColour;

		// Token: 0x04004AD5 RID: 19157
		private AeroplaneController m_Jet;

		// Token: 0x04004AD6 RID: 19158
		private ParticleSystem m_System;

		// Token: 0x04004AD7 RID: 19159
		private float m_OriginalStartSize;

		// Token: 0x04004AD8 RID: 19160
		private float m_OriginalLifetime;

		// Token: 0x04004AD9 RID: 19161
		private Color m_OriginalStartColor;
	}
}
