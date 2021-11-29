using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000522 RID: 1314
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x0600216F RID: 8559 RVA: 0x001E746D File Offset: 0x001E566D
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x06002170 RID: 8560 RVA: 0x001E7480 File Offset: 0x001E5680
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x04004934 RID: 18740
		public CarController carController;

		// Token: 0x04004935 RID: 18741
		private Quaternion m_OriginalRotation;
	}
}
