using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053F RID: 1343
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl4Axis : MonoBehaviour
	{
		// Token: 0x0600223C RID: 8764 RVA: 0x001F4094 File Offset: 0x001F2294
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x0600223D RID: 8765 RVA: 0x001F40A4 File Offset: 0x001F22A4
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
			this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
			this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
			this.m_Aeroplane.Move(axis, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
		}

		// Token: 0x0600223E RID: 8766 RVA: 0x001F4118 File Offset: 0x001F2318
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
		}

		// Token: 0x04004AF6 RID: 19190
		public float maxRollAngle = 80f;

		// Token: 0x04004AF7 RID: 19191
		public float maxPitchAngle = 80f;

		// Token: 0x04004AF8 RID: 19192
		private AeroplaneController m_Aeroplane;

		// Token: 0x04004AF9 RID: 19193
		private float m_Throttle;

		// Token: 0x04004AFA RID: 19194
		private bool m_AirBrakes;

		// Token: 0x04004AFB RID: 19195
		private float m_Yaw;
	}
}
