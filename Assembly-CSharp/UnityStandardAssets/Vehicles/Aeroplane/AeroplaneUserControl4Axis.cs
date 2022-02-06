using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000531 RID: 1329
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl4Axis : MonoBehaviour
	{
		// Token: 0x060021E5 RID: 8677 RVA: 0x001EC93C File Offset: 0x001EAB3C
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x060021E6 RID: 8678 RVA: 0x001EC94C File Offset: 0x001EAB4C
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
			this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
			this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
			this.m_Aeroplane.Move(axis, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
		}

		// Token: 0x060021E7 RID: 8679 RVA: 0x001EC9C0 File Offset: 0x001EABC0
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
		}

		// Token: 0x04004A03 RID: 18947
		public float maxRollAngle = 80f;

		// Token: 0x04004A04 RID: 18948
		public float maxPitchAngle = 80f;

		// Token: 0x04004A05 RID: 18949
		private AeroplaneController m_Aeroplane;

		// Token: 0x04004A06 RID: 18950
		private float m_Throttle;

		// Token: 0x04004A07 RID: 18951
		private bool m_AirBrakes;

		// Token: 0x04004A08 RID: 18952
		private float m_Yaw;
	}
}
