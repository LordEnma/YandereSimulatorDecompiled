using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000535 RID: 1333
	public class Suspension : MonoBehaviour
	{
		// Token: 0x060021DC RID: 8668 RVA: 0x001F0865 File Offset: 0x001EEA65
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x060021DD RID: 8669 RVA: 0x001F088E File Offset: 0x001EEA8E
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x04004A75 RID: 19061
		public GameObject wheel;

		// Token: 0x04004A76 RID: 19062
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x04004A77 RID: 19063
		private Vector3 m_Origin;
	}
}
