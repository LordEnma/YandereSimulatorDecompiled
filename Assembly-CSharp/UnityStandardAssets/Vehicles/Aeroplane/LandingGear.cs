using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000535 RID: 1333
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x060021FD RID: 8701 RVA: 0x001EDC48 File Offset: 0x001EBE48
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021FE RID: 8702 RVA: 0x001EDC70 File Offset: 0x001EBE70
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

		// Token: 0x04004A28 RID: 18984
		public float raiseAtAltitude = 40f;

		// Token: 0x04004A29 RID: 18985
		public float lowerAtAltitude = 40f;

		// Token: 0x04004A2A RID: 18986
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x04004A2B RID: 18987
		private Animator m_Animator;

		// Token: 0x04004A2C RID: 18988
		private Rigidbody m_Rigidbody;

		// Token: 0x04004A2D RID: 18989
		private AeroplaneController m_Plane;

		// Token: 0x02000685 RID: 1669
		private enum GearState
		{
			// Token: 0x04004FED RID: 20461
			Raised = -1,
			// Token: 0x04004FEE RID: 20462
			Lowered = 1
		}
	}
}
