using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000540 RID: 1344
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x06002233 RID: 8755 RVA: 0x001F2328 File Offset: 0x001F0528
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x06002234 RID: 8756 RVA: 0x001F2350 File Offset: 0x001F0550
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

		// Token: 0x04004ADA RID: 19162
		public float raiseAtAltitude = 40f;

		// Token: 0x04004ADB RID: 19163
		public float lowerAtAltitude = 40f;

		// Token: 0x04004ADC RID: 19164
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x04004ADD RID: 19165
		private Animator m_Animator;

		// Token: 0x04004ADE RID: 19166
		private Rigidbody m_Rigidbody;

		// Token: 0x04004ADF RID: 19167
		private AeroplaneController m_Plane;

		// Token: 0x02000690 RID: 1680
		private enum GearState
		{
			// Token: 0x0400509F RID: 20639
			Raised = -1,
			// Token: 0x040050A0 RID: 20640
			Lowered = 1
		}
	}
}
