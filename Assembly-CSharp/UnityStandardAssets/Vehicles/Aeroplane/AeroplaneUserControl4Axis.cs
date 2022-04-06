using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053E RID: 1342
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl4Axis : MonoBehaviour
	{
		// Token: 0x0600222B RID: 8747 RVA: 0x001F20B0 File Offset: 0x001F02B0
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x0600222C RID: 8748 RVA: 0x001F20C0 File Offset: 0x001F02C0
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
			this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
			this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
			this.m_Aeroplane.Move(axis, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
		}

		// Token: 0x0600222D RID: 8749 RVA: 0x001F2134 File Offset: 0x001F0334
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
		}

		// Token: 0x04004ACE RID: 19150
		public float maxRollAngle = 80f;

		// Token: 0x04004ACF RID: 19151
		public float maxPitchAngle = 80f;

		// Token: 0x04004AD0 RID: 19152
		private AeroplaneController m_Aeroplane;

		// Token: 0x04004AD1 RID: 19153
		private float m_Throttle;

		// Token: 0x04004AD2 RID: 19154
		private bool m_AirBrakes;

		// Token: 0x04004AD3 RID: 19155
		private float m_Yaw;
	}
}
