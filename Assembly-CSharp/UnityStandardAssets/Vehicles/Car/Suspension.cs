using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000524 RID: 1316
	public class Suspension : MonoBehaviour
	{
		// Token: 0x06002174 RID: 8564 RVA: 0x001E74D1 File Offset: 0x001E56D1
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x06002175 RID: 8565 RVA: 0x001E74FA File Offset: 0x001E56FA
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x04004937 RID: 18743
		public GameObject wheel;

		// Token: 0x04004938 RID: 18744
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x04004939 RID: 18745
		private Vector3 m_Origin;
	}
}
