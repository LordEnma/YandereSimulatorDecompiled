using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000532 RID: 1330
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl4Axis : MonoBehaviour
	{
		// Token: 0x060021EC RID: 8684 RVA: 0x001ECDF0 File Offset: 0x001EAFF0
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x060021ED RID: 8685 RVA: 0x001ECE00 File Offset: 0x001EB000
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
			this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
			this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
			this.m_Aeroplane.Move(axis, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
		}

		// Token: 0x060021EE RID: 8686 RVA: 0x001ECE74 File Offset: 0x001EB074
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
		}

		// Token: 0x04004A0C RID: 18956
		public float maxRollAngle = 80f;

		// Token: 0x04004A0D RID: 18957
		public float maxPitchAngle = 80f;

		// Token: 0x04004A0E RID: 18958
		private AeroplaneController m_Aeroplane;

		// Token: 0x04004A0F RID: 18959
		private float m_Throttle;

		// Token: 0x04004A10 RID: 18960
		private bool m_AirBrakes;

		// Token: 0x04004A11 RID: 18961
		private float m_Yaw;
	}
}
