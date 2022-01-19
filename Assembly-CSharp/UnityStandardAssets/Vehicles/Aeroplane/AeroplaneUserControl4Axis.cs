using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000531 RID: 1329
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl4Axis : MonoBehaviour
	{
		// Token: 0x060021DC RID: 8668 RVA: 0x001EBB80 File Offset: 0x001E9D80
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x060021DD RID: 8669 RVA: 0x001EBB90 File Offset: 0x001E9D90
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
			this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
			this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
			this.m_Aeroplane.Move(axis, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
		}

		// Token: 0x060021DE RID: 8670 RVA: 0x001EBC04 File Offset: 0x001E9E04
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
		}

		// Token: 0x040049EF RID: 18927
		public float maxRollAngle = 80f;

		// Token: 0x040049F0 RID: 18928
		public float maxPitchAngle = 80f;

		// Token: 0x040049F1 RID: 18929
		private AeroplaneController m_Aeroplane;

		// Token: 0x040049F2 RID: 18930
		private float m_Throttle;

		// Token: 0x040049F3 RID: 18931
		private bool m_AirBrakes;

		// Token: 0x040049F4 RID: 18932
		private float m_Yaw;
	}
}
