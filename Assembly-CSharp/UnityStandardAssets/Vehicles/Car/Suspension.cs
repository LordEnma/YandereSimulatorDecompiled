using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000526 RID: 1318
	public class Suspension : MonoBehaviour
	{
		// Token: 0x06002185 RID: 8581 RVA: 0x001E8C05 File Offset: 0x001E6E05
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x06002186 RID: 8582 RVA: 0x001E8C2E File Offset: 0x001E6E2E
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x04004976 RID: 18806
		public GameObject wheel;

		// Token: 0x04004977 RID: 18807
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x04004978 RID: 18808
		private Vector3 m_Origin;
	}
}
