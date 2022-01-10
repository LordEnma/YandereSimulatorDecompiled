using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200051E RID: 1310
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x0600215D RID: 8541 RVA: 0x001E8785 File Offset: 0x001E6985
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x0600215E RID: 8542 RVA: 0x001E8793 File Offset: 0x001E6993
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x0400493A RID: 18746
		public CarController car;

		// Token: 0x0400493B RID: 18747
		private Renderer m_Renderer;
	}
}
