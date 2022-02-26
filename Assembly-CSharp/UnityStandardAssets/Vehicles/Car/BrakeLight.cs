using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000521 RID: 1313
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x06002178 RID: 8568 RVA: 0x001EB2A5 File Offset: 0x001E94A5
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x06002179 RID: 8569 RVA: 0x001EB2B3 File Offset: 0x001E94B3
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x0400496E RID: 18798
		public CarController car;

		// Token: 0x0400496F RID: 18799
		private Renderer m_Renderer;
	}
}
