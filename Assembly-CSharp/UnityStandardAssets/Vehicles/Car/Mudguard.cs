using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052E RID: 1326
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x060021C7 RID: 8647 RVA: 0x001EEF91 File Offset: 0x001ED191
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x060021C8 RID: 8648 RVA: 0x001EEFA4 File Offset: 0x001ED1A4
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x04004A40 RID: 19008
		public CarController carController;

		// Token: 0x04004A41 RID: 19009
		private Quaternion m_OriginalRotation;
	}
}
