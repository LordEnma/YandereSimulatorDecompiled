using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053C RID: 1340
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x06002238 RID: 8760 RVA: 0x001EE380 File Offset: 0x001EC580
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x06002239 RID: 8761 RVA: 0x001EE3B0 File Offset: 0x001EC5B0
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

		// Token: 0x0600223A RID: 8762 RVA: 0x001EE4AF File Offset: 0x001EC6AF
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x04004A42 RID: 19010
		public TiltInput.AxisMapping mapping;

		// Token: 0x04004A43 RID: 19011
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x04004A44 RID: 19012
		public float fullTiltAngle = 25f;

		// Token: 0x04004A45 RID: 19013
		public float centreAngleOffset;

		// Token: 0x04004A46 RID: 19014
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x0200068A RID: 1674
		public enum AxisOptions
		{
			// Token: 0x04004FFF RID: 20479
			ForwardAxis,
			// Token: 0x04005000 RID: 20480
			SidewaysAxis
		}

		// Token: 0x0200068B RID: 1675
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x04005001 RID: 20481
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x04005002 RID: 20482
			public string axisName;

			// Token: 0x020006ED RID: 1773
			public enum MappingType
			{
				// Token: 0x040051FC RID: 20988
				NamedAxis,
				// Token: 0x040051FD RID: 20989
				MousePositionX,
				// Token: 0x040051FE RID: 20990
				MousePositionY,
				// Token: 0x040051FF RID: 20991
				MousePositionZ
			}
		}
	}
}
