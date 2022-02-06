using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000527 RID: 1319
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x06002199 RID: 8601 RVA: 0x001EB5BD File Offset: 0x001E97BD
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x0600219A RID: 8602 RVA: 0x001EB5D0 File Offset: 0x001E97D0
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x040049AB RID: 18859
		public CarController carController;

		// Token: 0x040049AC RID: 18860
		private Quaternion m_OriginalRotation;
	}
}
