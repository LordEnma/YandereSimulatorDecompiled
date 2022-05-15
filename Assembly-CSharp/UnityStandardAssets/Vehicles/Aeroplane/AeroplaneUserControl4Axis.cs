using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000540 RID: 1344
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl4Axis : MonoBehaviour
	{
		// Token: 0x06002246 RID: 8774 RVA: 0x001F56E4 File Offset: 0x001F38E4
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x06002247 RID: 8775 RVA: 0x001F56F4 File Offset: 0x001F38F4
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
			this.m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
			this.m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");
			this.m_Aeroplane.Move(axis, axis2, this.m_Yaw, this.m_Throttle, this.m_AirBrakes);
		}

		// Token: 0x06002248 RID: 8776 RVA: 0x001F5768 File Offset: 0x001F3968
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
		}

		// Token: 0x04004B1D RID: 19229
		public float maxRollAngle = 80f;

		// Token: 0x04004B1E RID: 19230
		public float maxPitchAngle = 80f;

		// Token: 0x04004B1F RID: 19231
		private AeroplaneController m_Aeroplane;

		// Token: 0x04004B20 RID: 19232
		private float m_Throttle;

		// Token: 0x04004B21 RID: 19233
		private bool m_AirBrakes;

		// Token: 0x04004B22 RID: 19234
		private float m_Yaw;
	}
}
