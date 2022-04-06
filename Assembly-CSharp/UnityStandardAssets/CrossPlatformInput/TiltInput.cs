using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000547 RID: 1351
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x0600226E RID: 8814 RVA: 0x001F2A60 File Offset: 0x001F0C60
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x0600226F RID: 8815 RVA: 0x001F2A90 File Offset: 0x001F0C90
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

		// Token: 0x06002270 RID: 8816 RVA: 0x001F2B8F File Offset: 0x001F0D8F
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x04004AF4 RID: 19188
		public TiltInput.AxisMapping mapping;

		// Token: 0x04004AF5 RID: 19189
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x04004AF6 RID: 19190
		public float fullTiltAngle = 25f;

		// Token: 0x04004AF7 RID: 19191
		public float centreAngleOffset;

		// Token: 0x04004AF8 RID: 19192
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x02000695 RID: 1685
		public enum AxisOptions
		{
			// Token: 0x040050B1 RID: 20657
			ForwardAxis,
			// Token: 0x040050B2 RID: 20658
			SidewaysAxis
		}

		// Token: 0x02000696 RID: 1686
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x040050B3 RID: 20659
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x040050B4 RID: 20660
			public string axisName;

			// Token: 0x020006F8 RID: 1784
			public enum MappingType
			{
				// Token: 0x040052AE RID: 21166
				NamedAxis,
				// Token: 0x040052AF RID: 21167
				MousePositionX,
				// Token: 0x040052B0 RID: 21168
				MousePositionY,
				// Token: 0x040052B1 RID: 21169
				MousePositionZ
			}
		}
	}
}
