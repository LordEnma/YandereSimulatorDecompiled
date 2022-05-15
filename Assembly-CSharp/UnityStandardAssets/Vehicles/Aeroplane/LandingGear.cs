using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000542 RID: 1346
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x0600224E RID: 8782 RVA: 0x001F595C File Offset: 0x001F3B5C
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x0600224F RID: 8783 RVA: 0x001F5984 File Offset: 0x001F3B84
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

		// Token: 0x04004B29 RID: 19241
		public float raiseAtAltitude = 40f;

		// Token: 0x04004B2A RID: 19242
		public float lowerAtAltitude = 40f;

		// Token: 0x04004B2B RID: 19243
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x04004B2C RID: 19244
		private Animator m_Animator;

		// Token: 0x04004B2D RID: 19245
		private Rigidbody m_Rigidbody;

		// Token: 0x04004B2E RID: 19246
		private AeroplaneController m_Plane;

		// Token: 0x02000692 RID: 1682
		private enum GearState
		{
			// Token: 0x040050F6 RID: 20726
			Raised = -1,
			// Token: 0x040050F7 RID: 20727
			Lowered = 1
		}
	}
}
