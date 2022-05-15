using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000549 RID: 1353
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x06002289 RID: 8841 RVA: 0x001F6094 File Offset: 0x001F4294
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x0600228A RID: 8842 RVA: 0x001F60C4 File Offset: 0x001F42C4
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

		// Token: 0x0600228B RID: 8843 RVA: 0x001F61C3 File Offset: 0x001F43C3
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x04004B43 RID: 19267
		public TiltInput.AxisMapping mapping;

		// Token: 0x04004B44 RID: 19268
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x04004B45 RID: 19269
		public float fullTiltAngle = 25f;

		// Token: 0x04004B46 RID: 19270
		public float centreAngleOffset;

		// Token: 0x04004B47 RID: 19271
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x02000697 RID: 1687
		public enum AxisOptions
		{
			// Token: 0x04005108 RID: 20744
			ForwardAxis,
			// Token: 0x04005109 RID: 20745
			SidewaysAxis
		}

		// Token: 0x02000698 RID: 1688
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x0400510A RID: 20746
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x0400510B RID: 20747
			public string axisName;

			// Token: 0x020006FA RID: 1786
			public enum MappingType
			{
				// Token: 0x04005305 RID: 21253
				NamedAxis,
				// Token: 0x04005306 RID: 21254
				MousePositionX,
				// Token: 0x04005307 RID: 21255
				MousePositionY,
				// Token: 0x04005308 RID: 21256
				MousePositionZ
			}
		}
	}
}
