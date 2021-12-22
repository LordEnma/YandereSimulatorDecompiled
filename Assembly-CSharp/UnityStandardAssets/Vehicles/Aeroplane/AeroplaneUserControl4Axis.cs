using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052E RID: 1326
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl4Axis : MonoBehaviour
	{
		// Token: 0x060021CC RID: 8652 RVA: 0x001E9F20 File Offset: 0x001E8120
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x060021CD RID: 8653 RVA: 0x001E9F30 File Offset: 0x001E8130
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
			this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
			this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
			this.m_Aeroplane.Move(axis, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
		}

		// Token: 0x060021CE RID: 8654 RVA: 0x001E9FA4 File Offset: 0x001E81A4
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
		}

		// Token: 0x040049CB RID: 18891
		public float maxRollAngle = 80f;

		// Token: 0x040049CC RID: 18892
		public float maxPitchAngle = 80f;

		// Token: 0x040049CD RID: 18893
		private AeroplaneController m_Aeroplane;

		// Token: 0x040049CE RID: 18894
		private float m_Throttle;

		// Token: 0x040049CF RID: 18895
		private bool m_AirBrakes;

		// Token: 0x040049D0 RID: 18896
		private float m_Yaw;
	}
}
