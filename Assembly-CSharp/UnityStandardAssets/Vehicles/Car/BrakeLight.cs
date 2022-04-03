using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052B RID: 1323
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x060021A6 RID: 8614 RVA: 0x001EF455 File Offset: 0x001ED655
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x060021A7 RID: 8615 RVA: 0x001EF463 File Offset: 0x001ED663
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x04004A1C RID: 18972
		public CarController car;

		// Token: 0x04004A1D RID: 18973
		private Renderer m_Renderer;
	}
}
