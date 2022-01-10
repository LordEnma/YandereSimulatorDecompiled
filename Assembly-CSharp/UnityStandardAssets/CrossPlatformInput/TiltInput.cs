using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000539 RID: 1337
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x0600221D RID: 8733 RVA: 0x001EB860 File Offset: 0x001E9A60
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x0600221E RID: 8734 RVA: 0x001EB890 File Offset: 0x001E9A90
		private void Update()
		{
			float value = 0f;
			if (Input.acceleration != Vector3.zero)
			{
				TiltInput.AxisOptions axisOptions = this.tiltAroundAxis;
				if (axisOptions != TiltInput.AxisOptions.ForwardAxis)
				{
					if (axisOptions == TiltInput.AxisOptions.SidewaysAxis)
					{
						value = Mathf.Atan2(Input.acceleration.z, -Input.acceleration.y) * 57.29578f + this.centreAngleOffset;
					}
				}
				else
				{
					value = Mathf.Atan2(Input.acceleration.x, -Input.acceleration.y) * 57.29578f + this.centreAngleOffset;
				}
			}
			float num = Mathf.InverseLerp(-this.fullTiltAngle, this.fullTiltAngle, value) * 2f - 1f;
			switch (this.mapping.type)
			{
			case TiltInput.AxisMapping.MappingType.NamedAxis:
				this.m_SteerAxis.Update(num);
				return;
			case TiltInput.AxisMapping.MappingType.MousePositionX:
				CrossPlatformInputManager.SetVirtualMousePositionX(num * (float)Screen.width);
				return;
			case TiltInput.AxisMapping.MappingType.MousePositionY:
				CrossPlatformInputManager.SetVirtualMousePositionY(num * (float)Screen.width);
				return;
			case TiltInput.AxisMapping.MappingType.MousePositionZ:
				CrossPlatformInputManager.SetVirtualMousePositionZ(num * (float)Screen.width);
				return;
			default:
				return;
			}
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x001EB98F File Offset: 0x001E9B8F
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x04004A0E RID: 18958
		public TiltInput.AxisMapping mapping;

		// Token: 0x04004A0F RID: 18959
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x04004A10 RID: 18960
		public float fullTiltAngle = 25f;

		// Token: 0x04004A11 RID: 18961
		public float centreAngleOffset;

		// Token: 0x04004A12 RID: 18962
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x0200068B RID: 1675
		public enum AxisOptions
		{
			// Token: 0x04004FF4 RID: 20468
			ForwardAxis,
			// Token: 0x04004FF5 RID: 20469
			SidewaysAxis
		}

		// Token: 0x0200068C RID: 1676
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x04004FF6 RID: 20470
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x04004FF7 RID: 20471
			public string axisName;

			// Token: 0x020006EF RID: 1775
			public enum MappingType
			{
				// Token: 0x040051F3 RID: 20979
				NamedAxis,
				// Token: 0x040051F4 RID: 20980
				MousePositionX,
				// Token: 0x040051F5 RID: 20981
				MousePositionY,
				// Token: 0x040051F6 RID: 20982
				MousePositionZ
			}
		}
	}
}
