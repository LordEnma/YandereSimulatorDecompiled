using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000534 RID: 1332
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl4Axis : MonoBehaviour
	{
		// Token: 0x060021FB RID: 8699 RVA: 0x001EE3A8 File Offset: 0x001EC5A8
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x060021FC RID: 8700 RVA: 0x001EE3B8 File Offset: 0x001EC5B8
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
			this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
			this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
			this.m_Aeroplane.Move(axis, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
		}

		// Token: 0x060021FD RID: 8701 RVA: 0x001EE42C File Offset: 0x001EC62C
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
		}

		// Token: 0x04004A39 RID: 19001
		public float maxRollAngle = 80f;

		// Token: 0x04004A3A RID: 19002
		public float maxPitchAngle = 80f;

		// Token: 0x04004A3B RID: 19003
		private AeroplaneController m_Aeroplane;

		// Token: 0x04004A3C RID: 19004
		private float m_Throttle;

		// Token: 0x04004A3D RID: 19005
		private bool m_AirBrakes;

		// Token: 0x04004A3E RID: 19006
		private float m_Yaw;
	}
}
