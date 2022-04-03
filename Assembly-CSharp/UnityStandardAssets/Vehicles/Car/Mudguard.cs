using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000533 RID: 1331
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x060021D7 RID: 8663 RVA: 0x001F0801 File Offset: 0x001EEA01
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x060021D8 RID: 8664 RVA: 0x001F0814 File Offset: 0x001EEA14
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x04004A72 RID: 19058
		public CarController carController;

		// Token: 0x04004A73 RID: 19059
		private Quaternion m_OriginalRotation;
	}
}
