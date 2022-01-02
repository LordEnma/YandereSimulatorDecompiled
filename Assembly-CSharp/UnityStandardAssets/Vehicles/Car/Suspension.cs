using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000526 RID: 1318
	public class Suspension : MonoBehaviour
	{
		// Token: 0x06002188 RID: 8584 RVA: 0x001E91F5 File Offset: 0x001E73F5
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x06002189 RID: 8585 RVA: 0x001E921E File Offset: 0x001E741E
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x0400497F RID: 18815
		public GameObject wheel;

		// Token: 0x04004980 RID: 18816
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x04004981 RID: 18817
		private Vector3 m_Origin;
	}
}
