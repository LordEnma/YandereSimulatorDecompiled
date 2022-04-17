using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053E RID: 1342
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl4Axis : MonoBehaviour
	{
		// Token: 0x06002232 RID: 8754 RVA: 0x001F2B0C File Offset: 0x001F0D0C
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x06002233 RID: 8755 RVA: 0x001F2B1C File Offset: 0x001F0D1C
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
			this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
			this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
			this.m_Aeroplane.Move(axis, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
		}

		// Token: 0x06002234 RID: 8756 RVA: 0x001F2B90 File Offset: 0x001F0D90
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
		}

		// Token: 0x04004AE0 RID: 19168
		public float maxRollAngle = 80f;

		// Token: 0x04004AE1 RID: 19169
		public float maxPitchAngle = 80f;

		// Token: 0x04004AE2 RID: 19170
		private AeroplaneController m_Aeroplane;

		// Token: 0x04004AE3 RID: 19171
		private float m_Throttle;

		// Token: 0x04004AE4 RID: 19172
		private bool m_AirBrakes;

		// Token: 0x04004AE5 RID: 19173
		private float m_Yaw;
	}
}
