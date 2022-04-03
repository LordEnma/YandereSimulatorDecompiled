using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053D RID: 1341
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl4Axis : MonoBehaviour
	{
		// Token: 0x06002223 RID: 8739 RVA: 0x001F1B80 File Offset: 0x001EFD80
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x06002224 RID: 8740 RVA: 0x001F1B90 File Offset: 0x001EFD90
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
			this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
			this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
			this.m_Aeroplane.Move(axis, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
		}

		// Token: 0x06002225 RID: 8741 RVA: 0x001F1C04 File Offset: 0x001EFE04
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
		}

		// Token: 0x04004ACA RID: 19146
		public float maxRollAngle = 80f;

		// Token: 0x04004ACB RID: 19147
		public float maxPitchAngle = 80f;

		// Token: 0x04004ACC RID: 19148
		private AeroplaneController m_Aeroplane;

		// Token: 0x04004ACD RID: 19149
		private float m_Throttle;

		// Token: 0x04004ACE RID: 19150
		private bool m_AirBrakes;

		// Token: 0x04004ACF RID: 19151
		private float m_Yaw;
	}
}
