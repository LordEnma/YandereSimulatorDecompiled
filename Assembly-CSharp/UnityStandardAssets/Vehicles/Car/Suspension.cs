using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000528 RID: 1320
	public class Suspension : MonoBehaviour
	{
		// Token: 0x06002193 RID: 8595 RVA: 0x001E9B95 File Offset: 0x001E7D95
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x06002194 RID: 8596 RVA: 0x001E9BBE File Offset: 0x001E7DBE
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x04004993 RID: 18835
		public GameObject wheel;

		// Token: 0x04004994 RID: 18836
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x04004995 RID: 18837
		private Vector3 m_Origin;
	}
}
