using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000524 RID: 1316
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x06002180 RID: 8576 RVA: 0x001E8BA1 File Offset: 0x001E6DA1
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x06002181 RID: 8577 RVA: 0x001E8BB4 File Offset: 0x001E6DB4
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x04004973 RID: 18803
		public CarController carController;

		// Token: 0x04004974 RID: 18804
		private Quaternion m_OriginalRotation;
	}
}
