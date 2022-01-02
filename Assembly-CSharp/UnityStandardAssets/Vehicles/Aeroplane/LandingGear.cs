using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000530 RID: 1328
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x060021D7 RID: 8663 RVA: 0x001EA788 File Offset: 0x001E8988
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021D8 RID: 8664 RVA: 0x001EA7B0 File Offset: 0x001E89B0
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

		// Token: 0x040049E0 RID: 18912
		public float raiseAtAltitude = 40f;

		// Token: 0x040049E1 RID: 18913
		public float lowerAtAltitude = 40f;

		// Token: 0x040049E2 RID: 18914
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x040049E3 RID: 18915
		private Animator m_Animator;

		// Token: 0x040049E4 RID: 18916
		private Rigidbody m_Rigidbody;

		// Token: 0x040049E5 RID: 18917
		private AeroplaneController m_Plane;

		// Token: 0x02000684 RID: 1668
		private enum GearState
		{
			// Token: 0x04004FCE RID: 20430
			Raised = -1,
			// Token: 0x04004FCF RID: 20431
			Lowered = 1
		}
	}
}
