using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000538 RID: 1336
	public class Suspension : MonoBehaviour
	{
		// Token: 0x06002200 RID: 8704 RVA: 0x001F4931 File Offset: 0x001F2B31
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x06002201 RID: 8705 RVA: 0x001F495A File Offset: 0x001F2B5A
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x04004AD1 RID: 19153
		public GameObject wheel;

		// Token: 0x04004AD2 RID: 19154
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x04004AD3 RID: 19155
		private Vector3 m_Origin;
	}
}
