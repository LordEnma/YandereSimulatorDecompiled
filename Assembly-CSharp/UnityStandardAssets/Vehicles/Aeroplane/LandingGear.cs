using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000534 RID: 1332
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x060021F4 RID: 8692 RVA: 0x001ED068 File Offset: 0x001EB268
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021F5 RID: 8693 RVA: 0x001ED090 File Offset: 0x001EB290
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

		// Token: 0x04004A18 RID: 18968
		public float raiseAtAltitude = 40f;

		// Token: 0x04004A19 RID: 18969
		public float lowerAtAltitude = 40f;

		// Token: 0x04004A1A RID: 18970
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x04004A1B RID: 18971
		private Animator m_Animator;

		// Token: 0x04004A1C RID: 18972
		private Rigidbody m_Rigidbody;

		// Token: 0x04004A1D RID: 18973
		private AeroplaneController m_Plane;

		// Token: 0x02000682 RID: 1666
		private enum GearState
		{
			// Token: 0x04004FD8 RID: 20440
			Raised = -1,
			// Token: 0x04004FD9 RID: 20441
			Lowered = 1
		}
	}
}
