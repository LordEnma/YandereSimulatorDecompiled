using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053D RID: 1341
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x0600223E RID: 8766 RVA: 0x001EED58 File Offset: 0x001ECF58
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x0600223F RID: 8767 RVA: 0x001EED88 File Offset: 0x001ECF88
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

		// Token: 0x06002240 RID: 8768 RVA: 0x001EEE87 File Offset: 0x001ED087
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x04004A5F RID: 19039
		public TiltInput.AxisMapping mapping;

		// Token: 0x04004A60 RID: 19040
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x04004A61 RID: 19041
		public float fullTiltAngle = 25f;

		// Token: 0x04004A62 RID: 19042
		public float centreAngleOffset;

		// Token: 0x04004A63 RID: 19043
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x0200068B RID: 1675
		public enum AxisOptions
		{
			// Token: 0x0400501C RID: 20508
			ForwardAxis,
			// Token: 0x0400501D RID: 20509
			SidewaysAxis
		}

		// Token: 0x0200068C RID: 1676
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x0400501E RID: 20510
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x0400501F RID: 20511
			public string axisName;

			// Token: 0x020006EE RID: 1774
			public enum MappingType
			{
				// Token: 0x04005219 RID: 21017
				NamedAxis,
				// Token: 0x0400521A RID: 21018
				MousePositionX,
				// Token: 0x0400521B RID: 21019
				MousePositionY,
				// Token: 0x0400521C RID: 21020
				MousePositionZ
			}
		}
	}
}
