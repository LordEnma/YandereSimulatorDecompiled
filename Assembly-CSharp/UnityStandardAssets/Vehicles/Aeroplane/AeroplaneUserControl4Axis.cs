using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052C RID: 1324
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl4Axis : MonoBehaviour
	{
		// Token: 0x060021BB RID: 8635 RVA: 0x001E87EC File Offset: 0x001E69EC
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x060021BC RID: 8636 RVA: 0x001E87FC File Offset: 0x001E69FC
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
			this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
			this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
			this.m_Aeroplane.Move(axis, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
		}

		// Token: 0x060021BD RID: 8637 RVA: 0x001E8870 File Offset: 0x001E6A70
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
		}

		// Token: 0x0400498C RID: 18828
		public float maxRollAngle = 80f;

		// Token: 0x0400498D RID: 18829
		public float maxPitchAngle = 80f;

		// Token: 0x0400498E RID: 18830
		private AeroplaneController m_Aeroplane;

		// Token: 0x0400498F RID: 18831
		private float m_Throttle;

		// Token: 0x04004990 RID: 18832
		private bool m_AirBrakes;

		// Token: 0x04004991 RID: 18833
		private float m_Yaw;
	}
}
