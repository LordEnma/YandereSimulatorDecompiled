using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000522 RID: 1314
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x0600217E RID: 8574 RVA: 0x001EBC7D File Offset: 0x001E9E7D
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x0600217F RID: 8575 RVA: 0x001EBC8B File Offset: 0x001E9E8B
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x0400498B RID: 18827
		public CarController car;

		// Token: 0x0400498C RID: 18828
		private Renderer m_Renderer;
	}
}
