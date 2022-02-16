using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000520 RID: 1312
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x0600216F RID: 8559 RVA: 0x001EA6C5 File Offset: 0x001E88C5
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x06002170 RID: 8560 RVA: 0x001EA6D3 File Offset: 0x001E88D3
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x0400495E RID: 18782
		public CarController car;

		// Token: 0x0400495F RID: 18783
		private Renderer m_Renderer;
	}
}
