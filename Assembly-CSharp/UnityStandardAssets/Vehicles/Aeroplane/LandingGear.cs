using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053F RID: 1343
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x0600222B RID: 8747 RVA: 0x001F1DF8 File Offset: 0x001EFFF8
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x0600222C RID: 8748 RVA: 0x001F1E20 File Offset: 0x001F0020
		private void Update()
		{
			if (this.m_State == LandingGear.GearState.Lowered && this.m_Plane.Altitude > this.raiseAtAltitude && this.m_Rigidbody.velocity.y > 0f)
			{
				this.m_State = LandingGear.GearState.Raised;
			}
			if (this.m_State == LandingGear.GearState.Raised && this.m_Plane.Altitude < this.lowerAtAltitude && this.m_Rigidbody.velocity.y < 0f)
			{
				this.m_State = LandingGear.GearState.Lowered;
			}
			this.m_Animator.SetInteger("GearState", (int)this.m_State);
		}

		// Token: 0x04004AD6 RID: 19158
		public float raiseAtAltitude = 40f;

		// Token: 0x04004AD7 RID: 19159
		public float lowerAtAltitude = 40f;

		// Token: 0x04004AD8 RID: 19160
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x04004AD9 RID: 19161
		private Animator m_Animator;

		// Token: 0x04004ADA RID: 19162
		private Rigidbody m_Rigidbody;

		// Token: 0x04004ADB RID: 19163
		private AeroplaneController m_Plane;

		// Token: 0x0200068F RID: 1679
		private enum GearState
		{
			// Token: 0x0400509B RID: 20635
			Raised = -1,
			// Token: 0x0400509C RID: 20636
			Lowered = 1
		}
	}
}
