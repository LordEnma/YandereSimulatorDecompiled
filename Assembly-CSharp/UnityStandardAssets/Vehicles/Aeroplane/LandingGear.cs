using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000540 RID: 1344
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x0600223A RID: 8762 RVA: 0x001F2D84 File Offset: 0x001F0F84
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x0600223B RID: 8763 RVA: 0x001F2DAC File Offset: 0x001F0FAC
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

		// Token: 0x04004AEC RID: 19180
		public float raiseAtAltitude = 40f;

		// Token: 0x04004AED RID: 19181
		public float lowerAtAltitude = 40f;

		// Token: 0x04004AEE RID: 19182
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x04004AEF RID: 19183
		private Animator m_Animator;

		// Token: 0x04004AF0 RID: 19184
		private Rigidbody m_Rigidbody;

		// Token: 0x04004AF1 RID: 19185
		private AeroplaneController m_Plane;

		// Token: 0x02000690 RID: 1680
		private enum GearState
		{
			// Token: 0x040050B1 RID: 20657
			Raised = -1,
			// Token: 0x040050B2 RID: 20658
			Lowered = 1
		}
	}
}
