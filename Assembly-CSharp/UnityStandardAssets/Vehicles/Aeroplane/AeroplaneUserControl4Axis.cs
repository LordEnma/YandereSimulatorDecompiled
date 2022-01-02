using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052E RID: 1326
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl4Axis : MonoBehaviour
	{
		// Token: 0x060021CF RID: 8655 RVA: 0x001EA510 File Offset: 0x001E8710
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x060021D0 RID: 8656 RVA: 0x001EA520 File Offset: 0x001E8720
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
			this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
			this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
			this.m_Aeroplane.Move(axis, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
		}

		// Token: 0x060021D1 RID: 8657 RVA: 0x001EA594 File Offset: 0x001E8794
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
		}

		// Token: 0x040049D4 RID: 18900
		public float maxRollAngle = 80f;

		// Token: 0x040049D5 RID: 18901
		public float maxPitchAngle = 80f;

		// Token: 0x040049D6 RID: 18902
		private AeroplaneController m_Aeroplane;

		// Token: 0x040049D7 RID: 18903
		private float m_Throttle;

		// Token: 0x040049D8 RID: 18904
		private bool m_AirBrakes;

		// Token: 0x040049D9 RID: 18905
		private float m_Yaw;
	}
}
