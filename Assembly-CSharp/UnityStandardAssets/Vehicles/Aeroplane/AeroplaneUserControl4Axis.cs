using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000538 RID: 1336
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl4Axis : MonoBehaviour
	{
		// Token: 0x06002213 RID: 8723 RVA: 0x001F0310 File Offset: 0x001EE510
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x06002214 RID: 8724 RVA: 0x001F0320 File Offset: 0x001EE520
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
			this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
			this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
			this.m_Aeroplane.Move(axis, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
		}

		// Token: 0x06002215 RID: 8725 RVA: 0x001F0394 File Offset: 0x001EE594
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
		}

		// Token: 0x04004A98 RID: 19096
		public float maxRollAngle = 80f;

		// Token: 0x04004A99 RID: 19097
		public float maxPitchAngle = 80f;

		// Token: 0x04004A9A RID: 19098
		private AeroplaneController m_Aeroplane;

		// Token: 0x04004A9B RID: 19099
		private float m_Throttle;

		// Token: 0x04004A9C RID: 19100
		private bool m_AirBrakes;

		// Token: 0x04004A9D RID: 19101
		private float m_Yaw;
	}
}
