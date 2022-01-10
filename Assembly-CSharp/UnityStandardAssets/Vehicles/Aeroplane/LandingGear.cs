using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000532 RID: 1330
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x060021E2 RID: 8674 RVA: 0x001EB128 File Offset: 0x001E9328
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021E3 RID: 8675 RVA: 0x001EB150 File Offset: 0x001E9350
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

		// Token: 0x040049F4 RID: 18932
		public float raiseAtAltitude = 40f;

		// Token: 0x040049F5 RID: 18933
		public float lowerAtAltitude = 40f;

		// Token: 0x040049F6 RID: 18934
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x040049F7 RID: 18935
		private Animator m_Animator;

		// Token: 0x040049F8 RID: 18936
		private Rigidbody m_Rigidbody;

		// Token: 0x040049F9 RID: 18937
		private AeroplaneController m_Plane;

		// Token: 0x02000686 RID: 1670
		private enum GearState
		{
			// Token: 0x04004FE2 RID: 20450
			Raised = -1,
			// Token: 0x04004FE3 RID: 20451
			Lowered = 1
		}
	}
}
