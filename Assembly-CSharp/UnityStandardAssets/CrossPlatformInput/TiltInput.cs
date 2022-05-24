using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000549 RID: 1353
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x0600228A RID: 8842 RVA: 0x001F65FC File Offset: 0x001F47FC
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x0600228B RID: 8843 RVA: 0x001F662C File Offset: 0x001F482C
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

		// Token: 0x0600228C RID: 8844 RVA: 0x001F672B File Offset: 0x001F492B
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x04004B4C RID: 19276
		public TiltInput.AxisMapping mapping;

		// Token: 0x04004B4D RID: 19277
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x04004B4E RID: 19278
		public float fullTiltAngle = 25f;

		// Token: 0x04004B4F RID: 19279
		public float centreAngleOffset;

		// Token: 0x04004B50 RID: 19280
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x02000697 RID: 1687
		public enum AxisOptions
		{
			// Token: 0x04005111 RID: 20753
			ForwardAxis,
			// Token: 0x04005112 RID: 20754
			SidewaysAxis
		}

		// Token: 0x02000698 RID: 1688
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x04005113 RID: 20755
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x04005114 RID: 20756
			public string axisName;

			// Token: 0x020006FA RID: 1786
			public enum MappingType
			{
				// Token: 0x0400530E RID: 21262
				NamedAxis,
				// Token: 0x0400530F RID: 21263
				MousePositionX,
				// Token: 0x04005310 RID: 21264
				MousePositionY,
				// Token: 0x04005311 RID: 21265
				MousePositionZ
			}
		}
	}
}
