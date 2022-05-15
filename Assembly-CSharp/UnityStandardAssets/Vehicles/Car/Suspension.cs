using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000538 RID: 1336
	public class Suspension : MonoBehaviour
	{
		// Token: 0x060021FF RID: 8703 RVA: 0x001F43C9 File Offset: 0x001F25C9
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x06002200 RID: 8704 RVA: 0x001F43F2 File Offset: 0x001F25F2
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x04004AC8 RID: 19144
		public GameObject wheel;

		// Token: 0x04004AC9 RID: 19145
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x04004ACA RID: 19146
		private Vector3 m_Origin;
	}
}
