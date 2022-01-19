using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000529 RID: 1321
	public class Suspension : MonoBehaviour
	{
		// Token: 0x06002195 RID: 8597 RVA: 0x001EA865 File Offset: 0x001E8A65
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x06002196 RID: 8598 RVA: 0x001EA88E File Offset: 0x001E8A8E
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x0400499A RID: 18842
		public GameObject wheel;

		// Token: 0x0400499B RID: 18843
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x0400499C RID: 18844
		private Vector3 m_Origin;
	}
}
