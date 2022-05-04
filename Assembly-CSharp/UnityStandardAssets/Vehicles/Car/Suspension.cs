using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000537 RID: 1335
	public class Suspension : MonoBehaviour
	{
		// Token: 0x060021F5 RID: 8693 RVA: 0x001F2D79 File Offset: 0x001F0F79
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x060021F6 RID: 8694 RVA: 0x001F2DA2 File Offset: 0x001F0FA2
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
