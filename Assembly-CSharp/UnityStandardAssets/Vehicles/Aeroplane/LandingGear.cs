using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000533 RID: 1331
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x060021ED RID: 8685 RVA: 0x001ECBB4 File Offset: 0x001EADB4
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021EE RID: 8686 RVA: 0x001ECBDC File Offset: 0x001EADDC
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

		// Token: 0x04004A0F RID: 18959
		public float raiseAtAltitude = 40f;

		// Token: 0x04004A10 RID: 18960
		public float lowerAtAltitude = 40f;

		// Token: 0x04004A11 RID: 18961
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x04004A12 RID: 18962
		private Animator m_Animator;

		// Token: 0x04004A13 RID: 18963
		private Rigidbody m_Rigidbody;

		// Token: 0x04004A14 RID: 18964
		private AeroplaneController m_Plane;

		// Token: 0x02000681 RID: 1665
		private enum GearState
		{
			// Token: 0x04004FCF RID: 20431
			Raised = -1,
			// Token: 0x04004FD0 RID: 20432
			Lowered = 1
		}
	}
}
