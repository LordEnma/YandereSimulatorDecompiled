using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000530 RID: 1328
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl4Axis : MonoBehaviour
	{
		// Token: 0x060021DA RID: 8666 RVA: 0x001EAEB0 File Offset: 0x001E90B0
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x060021DB RID: 8667 RVA: 0x001EAEC0 File Offset: 0x001E90C0
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
			this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
			this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
			this.m_Aeroplane.Move(axis, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
		}

		// Token: 0x060021DC RID: 8668 RVA: 0x001EAF34 File Offset: 0x001E9134
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
		}

		// Token: 0x040049E8 RID: 18920
		public float maxRollAngle = 80f;

		// Token: 0x040049E9 RID: 18921
		public float maxPitchAngle = 80f;

		// Token: 0x040049EA RID: 18922
		private AeroplaneController m_Aeroplane;

		// Token: 0x040049EB RID: 18923
		private float m_Throttle;

		// Token: 0x040049EC RID: 18924
		private bool m_AirBrakes;

		// Token: 0x040049ED RID: 18925
		private float m_Yaw;
	}
}
