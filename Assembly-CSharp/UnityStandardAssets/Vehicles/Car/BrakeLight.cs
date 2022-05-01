using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052D RID: 1325
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x060021BE RID: 8638 RVA: 0x001F186D File Offset: 0x001EFA6D
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x060021BF RID: 8639 RVA: 0x001F187B File Offset: 0x001EFA7B
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
