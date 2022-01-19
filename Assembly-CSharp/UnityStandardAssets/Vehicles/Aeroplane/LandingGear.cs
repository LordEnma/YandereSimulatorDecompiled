using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000533 RID: 1331
	public class LandingGear : MonoBehaviour
	{
		// Token: 0x060021E4 RID: 8676 RVA: 0x001EBDF8 File Offset: 0x001E9FF8
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Animator = base.GetComponent<Animator>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021E5 RID: 8677 RVA: 0x001EBE20 File Offset: 0x001EA020
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

		// Token: 0x040049FB RID: 18939
		public float raiseAtAltitude = 40f;

		// Token: 0x040049FC RID: 18940
		public float lowerAtAltitude = 40f;

		// Token: 0x040049FD RID: 18941
		private LandingGear.GearState m_State = LandingGear.GearState.Lowered;

		// Token: 0x040049FE RID: 18942
		private Animator m_Animator;

		// Token: 0x040049FF RID: 18943
		private Rigidbody m_Rigidbody;

		// Token: 0x04004A00 RID: 18944
		private AeroplaneController m_Plane;

		// Token: 0x02000687 RID: 1671
		private enum GearState
		{
			// Token: 0x04004FE9 RID: 20457
			Raised = -1,
			// Token: 0x04004FEA RID: 20458
			Lowered = 1
		}
	}
}
