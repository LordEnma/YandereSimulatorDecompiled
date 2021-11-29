using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052B RID: 1323
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl2Axis : MonoBehaviour
	{
		// Token: 0x060021B7 RID: 8631 RVA: 0x001E86DD File Offset: 0x001E68DD
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x060021B8 RID: 8632 RVA: 0x001E86EC File Offset: 0x001E68EC
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Horizontal");
			float axis2 = CrossPlatformInputManager.GetAxis("Vertical");
			bool button = CrossPlatformInputManager.GetButton("Fire1");
			float throttleInput = (float)(button ? -1 : 1);
			this.m_Aeroplane.Move(axis, axis2, 0f, throttleInput, button);
		}

		// Token: 0x060021B9 RID: 8633 RVA: 0x001E8738 File Offset: 0x001E6938
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
			float num3 = throttle * 0.5f + 0.5f;
			throttle = Mathf.Clamp(num3 - this.m_Aeroplane.Throttle, -1f, 1f);
		}

		// Token: 0x04004989 RID: 18825
		public float maxRollAngle = 80f;

		// Token: 0x0400498A RID: 18826
		public float maxPitchAngle = 80f;

		// Token: 0x0400498B RID: 18827
		private AeroplaneController m_Aeroplane;
	}
}
