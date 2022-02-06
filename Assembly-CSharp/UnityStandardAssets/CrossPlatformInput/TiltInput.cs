using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053A RID: 1338
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x06002228 RID: 8744 RVA: 0x001ED2EC File Offset: 0x001EB4EC
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x06002229 RID: 8745 RVA: 0x001ED31C File Offset: 0x001EB51C
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

		// Token: 0x0600222A RID: 8746 RVA: 0x001ED41B File Offset: 0x001EB61B
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x04004A29 RID: 18985
		public TiltInput.AxisMapping mapping;

		// Token: 0x04004A2A RID: 18986
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x04004A2B RID: 18987
		public float fullTiltAngle = 25f;

		// Token: 0x04004A2C RID: 18988
		public float centreAngleOffset;

		// Token: 0x04004A2D RID: 18989
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x02000686 RID: 1670
		public enum AxisOptions
		{
			// Token: 0x04004FE1 RID: 20449
			ForwardAxis,
			// Token: 0x04004FE2 RID: 20450
			SidewaysAxis
		}

		// Token: 0x02000687 RID: 1671
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x04004FE3 RID: 20451
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x04004FE4 RID: 20452
			public string axisName;

			// Token: 0x020006E9 RID: 1769
			public enum MappingType
			{
				// Token: 0x040051DE RID: 20958
				NamedAxis,
				// Token: 0x040051DF RID: 20959
				MousePositionX,
				// Token: 0x040051E0 RID: 20960
				MousePositionY,
				// Token: 0x040051E1 RID: 20961
				MousePositionZ
			}
		}
	}
}
