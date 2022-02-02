using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000533 RID: 1331
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x060021E8 RID: 8680 RVA: 0x001EC698 File Offset: 0x001EA898
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021E9 RID: 8681 RVA: 0x001EC6C0 File Offset: 0x001EA8C0
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

		// Token: 0x04004A06 RID: 18950
		public float raiseAtAltitude = 40f;

		// Token: 0x04004A07 RID: 18951
		public float lowerAtAltitude = 40f;

		// Token: 0x04004A08 RID: 18952
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x04004A09 RID: 18953
		private Animator m_Animator;

		// Token: 0x04004A0A RID: 18954
		private Rigidbody m_Rigidbody;

		// Token: 0x04004A0B RID: 18955
		private AeroplaneController m_Plane;

		// Token: 0x02000681 RID: 1665
		private enum GearState
		{
			// Token: 0x04004FC6 RID: 20422
			Raised = -1,
			// Token: 0x04004FC7 RID: 20423
			Lowered = 1
		}
	}
}
