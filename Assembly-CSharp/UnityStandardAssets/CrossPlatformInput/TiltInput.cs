using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000548 RID: 1352
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x0600227F RID: 8831 RVA: 0x001F4A44 File Offset: 0x001F2C44
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x06002280 RID: 8832 RVA: 0x001F4A74 File Offset: 0x001F2C74
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

		// Token: 0x06002281 RID: 8833 RVA: 0x001F4B73 File Offset: 0x001F2D73
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x04004B1C RID: 19228
		public TiltInput.AxisMapping mapping;

		// Token: 0x04004B1D RID: 19229
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x04004B1E RID: 19230
		public float fullTiltAngle = 25f;

		// Token: 0x04004B1F RID: 19231
		public float centreAngleOffset;

		// Token: 0x04004B20 RID: 19232
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x02000696 RID: 1686
		public enum AxisOptions
		{
			// Token: 0x040050E1 RID: 20705
			ForwardAxis,
			// Token: 0x040050E2 RID: 20706
			SidewaysAxis
		}

		// Token: 0x02000697 RID: 1687
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x040050E3 RID: 20707
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x040050E4 RID: 20708
			public string axisName;

			// Token: 0x020006F9 RID: 1785
			public enum MappingType
			{
				// Token: 0x040052DE RID: 21214
				NamedAxis,
				// Token: 0x040052DF RID: 21215
				MousePositionX,
				// Token: 0x040052E0 RID: 21216
				MousePositionY,
				// Token: 0x040052E1 RID: 21217
				MousePositionZ
			}
		}
	}
}
