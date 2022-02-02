using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000527 RID: 1319
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x06002194 RID: 8596 RVA: 0x001EB0A1 File Offset: 0x001E92A1
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x06002195 RID: 8597 RVA: 0x001EB0B4 File Offset: 0x001E92B4
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x040049A2 RID: 18850
		public CarController carController;

		// Token: 0x040049A3 RID: 18851
		private Quaternion m_OriginalRotation;
	}
}
