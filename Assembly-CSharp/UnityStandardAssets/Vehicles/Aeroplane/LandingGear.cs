using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000542 RID: 1346
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x0600224F RID: 8783 RVA: 0x001F5EC4 File Offset: 0x001F40C4
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x06002250 RID: 8784 RVA: 0x001F5EEC File Offset: 0x001F40EC
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

		// Token: 0x04004B32 RID: 19250
		public float raiseAtAltitude = 40f;

		// Token: 0x04004B33 RID: 19251
		public float lowerAtAltitude = 40f;

		// Token: 0x04004B34 RID: 19252
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x04004B35 RID: 19253
		private Animator m_Animator;

		// Token: 0x04004B36 RID: 19254
		private Rigidbody m_Rigidbody;

		// Token: 0x04004B37 RID: 19255
		private AeroplaneController m_Plane;

		// Token: 0x02000692 RID: 1682
		private enum GearState
		{
			// Token: 0x040050FF RID: 20735
			Raised = -1,
			// Token: 0x04005100 RID: 20736
			Lowered = 1
		}
	}
}
