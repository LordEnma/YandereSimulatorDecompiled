using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000536 RID: 1334
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x06002203 RID: 8707 RVA: 0x001EE620 File Offset: 0x001EC820
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x06002204 RID: 8708 RVA: 0x001EE648 File Offset: 0x001EC848
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

		// Token: 0x04004A45 RID: 19013
		public float raiseAtAltitude = 40f;

		// Token: 0x04004A46 RID: 19014
		public float lowerAtAltitude = 40f;

		// Token: 0x04004A47 RID: 19015
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x04004A48 RID: 19016
		private Animator m_Animator;

		// Token: 0x04004A49 RID: 19017
		private Rigidbody m_Rigidbody;

		// Token: 0x04004A4A RID: 19018
		private AeroplaneController m_Plane;

		// Token: 0x02000686 RID: 1670
		private enum GearState
		{
			// Token: 0x0400500A RID: 20490
			Raised = -1,
			// Token: 0x0400500B RID: 20491
			Lowered = 1
		}
	}
}
