using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000537 RID: 1335
	public class Suspension : MonoBehaviour
	{
		// Token: 0x060021F4 RID: 8692 RVA: 0x001F2C7D File Offset: 0x001F0E7D
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x060021F5 RID: 8693 RVA: 0x001F2CA6 File Offset: 0x001F0EA6
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x04004AA1 RID: 19105
		public GameObject wheel;

		// Token: 0x04004AA2 RID: 19106
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x04004AA3 RID: 19107
		private Vector3 m_Origin;
	}
}
