using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000541 RID: 1345
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x06002244 RID: 8772 RVA: 0x001F430C File Offset: 0x001F250C
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x06002245 RID: 8773 RVA: 0x001F4334 File Offset: 0x001F2534
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

		// Token: 0x04004B02 RID: 19202
		public float raiseAtAltitude = 40f;

		// Token: 0x04004B03 RID: 19203
		public float lowerAtAltitude = 40f;

		// Token: 0x04004B04 RID: 19204
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x04004B05 RID: 19205
		private Animator m_Animator;

		// Token: 0x04004B06 RID: 19206
		private Rigidbody m_Rigidbody;

		// Token: 0x04004B07 RID: 19207
		private AeroplaneController m_Plane;

		// Token: 0x02000691 RID: 1681
		private enum GearState
		{
			// Token: 0x040050CF RID: 20687
			Raised = -1,
			// Token: 0x040050D0 RID: 20688
			Lowered = 1
		}
	}
}
