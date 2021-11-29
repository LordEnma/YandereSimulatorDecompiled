using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052E RID: 1326
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x060021C3 RID: 8643 RVA: 0x001E8A64 File Offset: 0x001E6C64
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021C4 RID: 8644 RVA: 0x001E8A8C File Offset: 0x001E6C8C
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

		// Token: 0x04004998 RID: 18840
		public float raiseAtAltitude = 40f;

		// Token: 0x04004999 RID: 18841
		public float lowerAtAltitude = 40f;

		// Token: 0x0400499A RID: 18842
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x0400499B RID: 18843
		private Animator m_Animator;

		// Token: 0x0400499C RID: 18844
		private Rigidbody m_Rigidbody;

		// Token: 0x0400499D RID: 18845
		private AeroplaneController m_Plane;

		// Token: 0x02000681 RID: 1665
		private enum GearState
		{
			// Token: 0x04004F7A RID: 20346
			Raised = -1,
			// Token: 0x04004F7B RID: 20347
			Lowered = 1
		}
	}
}
