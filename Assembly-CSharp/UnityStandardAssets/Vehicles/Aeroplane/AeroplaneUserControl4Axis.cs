using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000533 RID: 1331
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl4Axis : MonoBehaviour
	{
		// Token: 0x060021F5 RID: 8693 RVA: 0x001ED9D0 File Offset: 0x001EBBD0
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x060021F6 RID: 8694 RVA: 0x001ED9E0 File Offset: 0x001EBBE0
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
			this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
			this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
			this.m_Aeroplane.Move(axis, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
		}

		// Token: 0x060021F7 RID: 8695 RVA: 0x001EDA54 File Offset: 0x001EBC54
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
		}

		// Token: 0x04004A1C RID: 18972
		public float maxRollAngle = 80f;

		// Token: 0x04004A1D RID: 18973
		public float maxPitchAngle = 80f;

		// Token: 0x04004A1E RID: 18974
		private AeroplaneController m_Aeroplane;

		// Token: 0x04004A1F RID: 18975
		private float m_Throttle;

		// Token: 0x04004A20 RID: 18976
		private bool m_AirBrakes;

		// Token: 0x04004A21 RID: 18977
		private float m_Yaw;
	}
}
