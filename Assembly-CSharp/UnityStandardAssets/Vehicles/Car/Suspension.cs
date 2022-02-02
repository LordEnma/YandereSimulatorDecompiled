using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000529 RID: 1321
	public class Suspension : MonoBehaviour
	{
		// Token: 0x06002199 RID: 8601 RVA: 0x001EB105 File Offset: 0x001E9305
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x0600219A RID: 8602 RVA: 0x001EB12E File Offset: 0x001E932E
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x040049A5 RID: 18853
		public GameObject wheel;

		// Token: 0x040049A6 RID: 18854
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x040049A7 RID: 18855
		private Vector3 m_Origin;
	}
}
