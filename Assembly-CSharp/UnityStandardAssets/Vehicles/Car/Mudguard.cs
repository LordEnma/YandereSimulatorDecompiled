using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000526 RID: 1318
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x0600218E RID: 8590 RVA: 0x001E9B31 File Offset: 0x001E7D31
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x0600218F RID: 8591 RVA: 0x001E9B44 File Offset: 0x001E7D44
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x04004990 RID: 18832
		public CarController carController;

		// Token: 0x04004991 RID: 18833
		private Quaternion m_OriginalRotation;
	}
}
