using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000531 RID: 1329
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl4Axis : MonoBehaviour
	{
		// Token: 0x060021E0 RID: 8672 RVA: 0x001EC420 File Offset: 0x001EA620
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x060021E1 RID: 8673 RVA: 0x001EC430 File Offset: 0x001EA630
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
			this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
			this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
			this.m_Aeroplane.Move(axis, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
		}

		// Token: 0x060021E2 RID: 8674 RVA: 0x001EC4A4 File Offset: 0x001EA6A4
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
		}

		// Token: 0x040049FA RID: 18938
		public float maxRollAngle = 80f;

		// Token: 0x040049FB RID: 18939
		public float maxPitchAngle = 80f;

		// Token: 0x040049FC RID: 18940
		private AeroplaneController m_Aeroplane;

		// Token: 0x040049FD RID: 18941
		private float m_Throttle;

		// Token: 0x040049FE RID: 18942
		private bool m_AirBrakes;

		// Token: 0x040049FF RID: 18943
		private float m_Yaw;
	}
}
