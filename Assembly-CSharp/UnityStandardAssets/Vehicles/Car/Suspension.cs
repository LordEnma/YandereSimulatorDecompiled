using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000529 RID: 1321
	public class Suspension : MonoBehaviour
	{
		// Token: 0x0600219E RID: 8606 RVA: 0x001EB621 File Offset: 0x001E9821
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x0600219F RID: 8607 RVA: 0x001EB64A File Offset: 0x001E984A
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x040049AE RID: 18862
		public GameObject wheel;

		// Token: 0x040049AF RID: 18863
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x040049B0 RID: 18864
		private Vector3 m_Origin;
	}
}
