using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000533 RID: 1331
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x060021EA RID: 8682 RVA: 0x001EC9B0 File Offset: 0x001EABB0
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x001EC9D8 File Offset: 0x001EABD8
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

		// Token: 0x04004A0C RID: 18956
		public float raiseAtAltitude = 40f;

		// Token: 0x04004A0D RID: 18957
		public float lowerAtAltitude = 40f;

		// Token: 0x04004A0E RID: 18958
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x04004A0F RID: 18959
		private Animator m_Animator;

		// Token: 0x04004A10 RID: 18960
		private Rigidbody m_Rigidbody;

		// Token: 0x04004A11 RID: 18961
		private AeroplaneController m_Plane;

		// Token: 0x02000681 RID: 1665
		private enum GearState
		{
			// Token: 0x04004FCC RID: 20428
			Raised = -1,
			// Token: 0x04004FCD RID: 20429
			Lowered = 1
		}
	}
}
