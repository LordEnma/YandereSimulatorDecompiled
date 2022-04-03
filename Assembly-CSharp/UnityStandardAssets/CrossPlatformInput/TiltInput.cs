using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000546 RID: 1350
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x06002266 RID: 8806 RVA: 0x001F2530 File Offset: 0x001F0730
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x06002267 RID: 8807 RVA: 0x001F2560 File Offset: 0x001F0760
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

		// Token: 0x06002268 RID: 8808 RVA: 0x001F265F File Offset: 0x001F085F
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x04004AF0 RID: 19184
		public TiltInput.AxisMapping mapping;

		// Token: 0x04004AF1 RID: 19185
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x04004AF2 RID: 19186
		public float fullTiltAngle = 25f;

		// Token: 0x04004AF3 RID: 19187
		public float centreAngleOffset;

		// Token: 0x04004AF4 RID: 19188
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x02000694 RID: 1684
		public enum AxisOptions
		{
			// Token: 0x040050AD RID: 20653
			ForwardAxis,
			// Token: 0x040050AE RID: 20654
			SidewaysAxis
		}

		// Token: 0x02000695 RID: 1685
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x040050AF RID: 20655
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x040050B0 RID: 20656
			public string axisName;

			// Token: 0x020006F7 RID: 1783
			public enum MappingType
			{
				// Token: 0x040052AA RID: 21162
				NamedAxis,
				// Token: 0x040052AB RID: 21163
				MousePositionX,
				// Token: 0x040052AC RID: 21164
				MousePositionY,
				// Token: 0x040052AD RID: 21165
				MousePositionZ
			}
		}
	}
}
