using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000530 RID: 1328
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x060021D4 RID: 8660 RVA: 0x001EA198 File Offset: 0x001E8398
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021D5 RID: 8661 RVA: 0x001EA1C0 File Offset: 0x001E83C0
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

		// Token: 0x040049D7 RID: 18903
		public float raiseAtAltitude = 40f;

		// Token: 0x040049D8 RID: 18904
		public float lowerAtAltitude = 40f;

		// Token: 0x040049D9 RID: 18905
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x040049DA RID: 18906
		private Animator m_Animator;

		// Token: 0x040049DB RID: 18907
		private Rigidbody m_Rigidbody;

		// Token: 0x040049DC RID: 18908
		private AeroplaneController m_Plane;

		// Token: 0x02000684 RID: 1668
		private enum GearState
		{
			// Token: 0x04004FC5 RID: 20421
			Raised = -1,
			// Token: 0x04004FC6 RID: 20422
			Lowered = 1
		}
	}
}
