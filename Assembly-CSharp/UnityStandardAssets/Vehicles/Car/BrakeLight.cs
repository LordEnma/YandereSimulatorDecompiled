using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052D RID: 1325
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x060021BF RID: 8639 RVA: 0x001F1969 File Offset: 0x001EFB69
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x060021C0 RID: 8640 RVA: 0x001F1977 File Offset: 0x001EFB77
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x04004A48 RID: 19016
		public CarController car;

		// Token: 0x04004A49 RID: 19017
		private Renderer m_Renderer;
	}
}
