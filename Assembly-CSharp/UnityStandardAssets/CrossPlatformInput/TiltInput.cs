using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053A RID: 1338
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x06002225 RID: 8741 RVA: 0x001ED0E8 File Offset: 0x001EB2E8
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x06002226 RID: 8742 RVA: 0x001ED118 File Offset: 0x001EB318
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

		// Token: 0x06002227 RID: 8743 RVA: 0x001ED217 File Offset: 0x001EB417
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x04004A26 RID: 18982
		public TiltInput.AxisMapping mapping;

		// Token: 0x04004A27 RID: 18983
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x04004A28 RID: 18984
		public float fullTiltAngle = 25f;

		// Token: 0x04004A29 RID: 18985
		public float centreAngleOffset;

		// Token: 0x04004A2A RID: 18986
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x02000686 RID: 1670
		public enum AxisOptions
		{
			// Token: 0x04004FDE RID: 20446
			ForwardAxis,
			// Token: 0x04004FDF RID: 20447
			SidewaysAxis
		}

		// Token: 0x02000687 RID: 1671
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x04004FE0 RID: 20448
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x04004FE1 RID: 20449
			public string axisName;

			// Token: 0x020006E9 RID: 1769
			public enum MappingType
			{
				// Token: 0x040051DB RID: 20955
				NamedAxis,
				// Token: 0x040051DC RID: 20956
				MousePositionX,
				// Token: 0x040051DD RID: 20957
				MousePositionY,
				// Token: 0x040051DE RID: 20958
				MousePositionZ
			}
		}
	}
}
