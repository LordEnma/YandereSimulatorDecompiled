using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052D RID: 1325
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl2Axis : MonoBehaviour
	{
		// Token: 0x060021C8 RID: 8648 RVA: 0x001E9E11 File Offset: 0x001E8011
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x060021C9 RID: 8649 RVA: 0x001E9E20 File Offset: 0x001E8020
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Horizontal");
			float axis2 = CrossPlatformInputManager.GetAxis("Vertical");
			bool button = CrossPlatformInputManager.GetButton("Fire1");
			float throttleInput = (float)(button ? -1 : 1);
			this.m_Aeroplane.Move(axis, axis2, 0f, throttleInput, button);
		}

		// Token: 0x060021CA RID: 8650 RVA: 0x001E9E6C File Offset: 0x001E806C
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
			float num3 = throttle * 0.5f + 0.5f;
			throttle = Mathf.Clamp(num3 - this.m_Aeroplane.Throttle, -1f, 1f);
		}

		// Token: 0x040049C8 RID: 18888
		public float maxRollAngle = 80f;

		// Token: 0x040049C9 RID: 18889
		public float maxPitchAngle = 80f;

		// Token: 0x040049CA RID: 18890
		private AeroplaneController m_Aeroplane;
	}
}
