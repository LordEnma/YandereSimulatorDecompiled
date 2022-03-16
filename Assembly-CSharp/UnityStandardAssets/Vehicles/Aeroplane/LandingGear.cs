using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053A RID: 1338
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x0600221B RID: 8731 RVA: 0x001F0588 File Offset: 0x001EE788
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x0600221C RID: 8732 RVA: 0x001F05B0 File Offset: 0x001EE7B0
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

		// Token: 0x04004AA4 RID: 19108
		public float raiseAtAltitude = 40f;

		// Token: 0x04004AA5 RID: 19109
		public float lowerAtAltitude = 40f;

		// Token: 0x04004AA6 RID: 19110
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x04004AA7 RID: 19111
		private Animator m_Animator;

		// Token: 0x04004AA8 RID: 19112
		private Rigidbody m_Rigidbody;

		// Token: 0x04004AA9 RID: 19113
		private AeroplaneController m_Plane;

		// Token: 0x0200068A RID: 1674
		private enum GearState
		{
			// Token: 0x04005069 RID: 20585
			Raised = -1,
			// Token: 0x0400506A RID: 20586
			Lowered = 1
		}
	}
}
