using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000535 RID: 1333
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x060021EF RID: 8687 RVA: 0x001F2C19 File Offset: 0x001F0E19
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x060021F0 RID: 8688 RVA: 0x001F2C2C File Offset: 0x001F0E2C
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x04004A9E RID: 19102
		public CarController carController;

		// Token: 0x04004A9F RID: 19103
		private Quaternion m_OriginalRotation;
	}
}
