using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053B RID: 1339
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x0600222F RID: 8751 RVA: 0x001ED7A0 File Offset: 0x001EB9A0
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x06002230 RID: 8752 RVA: 0x001ED7D0 File Offset: 0x001EB9D0
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

		// Token: 0x06002231 RID: 8753 RVA: 0x001ED8CF File Offset: 0x001EBACF
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x04004A32 RID: 18994
		public TiltInput.AxisMapping mapping;

		// Token: 0x04004A33 RID: 18995
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x04004A34 RID: 18996
		public float fullTiltAngle = 25f;

		// Token: 0x04004A35 RID: 18997
		public float centreAngleOffset;

		// Token: 0x04004A36 RID: 18998
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x02000687 RID: 1671
		public enum AxisOptions
		{
			// Token: 0x04004FEA RID: 20458
			ForwardAxis,
			// Token: 0x04004FEB RID: 20459
			SidewaysAxis
		}

		// Token: 0x02000688 RID: 1672
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x04004FEC RID: 20460
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x04004FED RID: 20461
			public string axisName;

			// Token: 0x020006EA RID: 1770
			public enum MappingType
			{
				// Token: 0x040051E7 RID: 20967
				NamedAxis,
				// Token: 0x040051E8 RID: 20968
				MousePositionX,
				// Token: 0x040051E9 RID: 20969
				MousePositionY,
				// Token: 0x040051EA RID: 20970
				MousePositionZ
			}
		}
	}
}
