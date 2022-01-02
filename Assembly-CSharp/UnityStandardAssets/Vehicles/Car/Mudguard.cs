using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000524 RID: 1316
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x06002183 RID: 8579 RVA: 0x001E9191 File Offset: 0x001E7391
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x06002184 RID: 8580 RVA: 0x001E91A4 File Offset: 0x001E73A4
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x0400497C RID: 18812
		public CarController carController;

		// Token: 0x0400497D RID: 18813
		private Quaternion m_OriginalRotation;
	}
}
