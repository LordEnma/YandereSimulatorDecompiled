using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053A RID: 1338
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x0600221F RID: 8735 RVA: 0x001EC530 File Offset: 0x001EA730
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001EC560 File Offset: 0x001EA760
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

		// Token: 0x06002221 RID: 8737 RVA: 0x001EC65F File Offset: 0x001EA85F
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x04004A15 RID: 18965
		public TiltInput.AxisMapping mapping;

		// Token: 0x04004A16 RID: 18966
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x04004A17 RID: 18967
		public float fullTiltAngle = 25f;

		// Token: 0x04004A18 RID: 18968
		public float centreAngleOffset;

		// Token: 0x04004A19 RID: 18969
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x0200068C RID: 1676
		public enum AxisOptions
		{
			// Token: 0x04004FFB RID: 20475
			ForwardAxis,
			// Token: 0x04004FFC RID: 20476
			SidewaysAxis
		}

		// Token: 0x0200068D RID: 1677
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x04004FFD RID: 20477
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x04004FFE RID: 20478
			public string axisName;

			// Token: 0x020006F0 RID: 1776
			public enum MappingType
			{
				// Token: 0x040051FA RID: 20986
				NamedAxis,
				// Token: 0x040051FB RID: 20987
				MousePositionX,
				// Token: 0x040051FC RID: 20988
				MousePositionY,
				// Token: 0x040051FD RID: 20989
				MousePositionZ
			}
		}
	}
}
