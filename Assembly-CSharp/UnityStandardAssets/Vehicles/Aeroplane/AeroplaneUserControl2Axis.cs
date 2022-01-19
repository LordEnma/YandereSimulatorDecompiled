using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000530 RID: 1328
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneUserControl2Axis : MonoBehaviour
	{
		// Token: 0x060021D8 RID: 8664 RVA: 0x001EBA71 File Offset: 0x001E9C71
		private void Awake()
		{
			this.m_Aeroplane = base.GetComponent<AeroplaneController>();
		}

		// Token: 0x060021D9 RID: 8665 RVA: 0x001EBA80 File Offset: 0x001E9C80
		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Horizontal");
			float axis2 = CrossPlatformInputManager.GetAxis("Vertical");
			bool button = CrossPlatformInputManager.GetButton("Fire1");
			float throttleInput = (float)(button ? -1 : 1);
			this.m_Aeroplane.Move(axis, axis2, 0f, throttleInput, button);
		}

		// Token: 0x060021DA RID: 8666 RVA: 0x001EBACC File Offset: 0x001E9CCC
		private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
		{
			float num = roll * this.maxRollAngle * 0.017453292f;
			float num2 = pitch * this.maxPitchAngle * 0.017453292f;
			roll = Mathf.Clamp(num - this.m_Aeroplane.RollAngle, -1f, 1f);
			pitch = Mathf.Clamp(num2 - this.m_Aeroplane.PitchAngle, -1f, 1f);
			float num3 = throttle * 0.5f + 0.5f;
			throttle = Mathf.Clamp(num3 - this.m_Aeroplane.Throttle, -1f, 1f);
		}

		// Token: 0x040049EC RID: 18924
		public float maxRollAngle = 80f;

		// Token: 0x040049ED RID: 18925
		public float maxPitchAngle = 80f;

		// Token: 0x040049EE RID: 18926
		private AeroplaneController m_Aeroplane;
	}
}
