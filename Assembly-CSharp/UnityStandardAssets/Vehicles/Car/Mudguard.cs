using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000527 RID: 1319
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x06002190 RID: 8592 RVA: 0x001EA801 File Offset: 0x001E8A01
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x06002191 RID: 8593 RVA: 0x001EA814 File Offset: 0x001E8A14
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x04004997 RID: 18839
		public CarController carController;

		// Token: 0x04004998 RID: 18840
		private Quaternion m_OriginalRotation;
	}
}
