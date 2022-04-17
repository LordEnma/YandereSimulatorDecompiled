using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000547 RID: 1351
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x06002275 RID: 8821 RVA: 0x001F34BC File Offset: 0x001F16BC
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x06002276 RID: 8822 RVA: 0x001F34EC File Offset: 0x001F16EC
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

		// Token: 0x06002277 RID: 8823 RVA: 0x001F35EB File Offset: 0x001F17EB
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x04004B06 RID: 19206
		public TiltInput.AxisMapping mapping;

		// Token: 0x04004B07 RID: 19207
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x04004B08 RID: 19208
		public float fullTiltAngle = 25f;

		// Token: 0x04004B09 RID: 19209
		public float centreAngleOffset;

		// Token: 0x04004B0A RID: 19210
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x02000695 RID: 1685
		public enum AxisOptions
		{
			// Token: 0x040050C3 RID: 20675
			ForwardAxis,
			// Token: 0x040050C4 RID: 20676
			SidewaysAxis
		}

		// Token: 0x02000696 RID: 1686
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x040050C5 RID: 20677
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x040050C6 RID: 20678
			public string axisName;

			// Token: 0x020006F8 RID: 1784
			public enum MappingType
			{
				// Token: 0x040052C0 RID: 21184
				NamedAxis,
				// Token: 0x040052C1 RID: 21185
				MousePositionX,
				// Token: 0x040052C2 RID: 21186
				MousePositionY,
				// Token: 0x040052C3 RID: 21187
				MousePositionZ
			}
		}
	}
}
