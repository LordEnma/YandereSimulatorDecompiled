using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000541 RID: 1345
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x06002256 RID: 8790 RVA: 0x001F0CC0 File Offset: 0x001EEEC0
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x06002257 RID: 8791 RVA: 0x001F0CF0 File Offset: 0x001EEEF0
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

		// Token: 0x06002258 RID: 8792 RVA: 0x001F0DEF File Offset: 0x001EEFEF
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x04004ABE RID: 19134
		public TiltInput.AxisMapping mapping;

		// Token: 0x04004ABF RID: 19135
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x04004AC0 RID: 19136
		public float fullTiltAngle = 25f;

		// Token: 0x04004AC1 RID: 19137
		public float centreAngleOffset;

		// Token: 0x04004AC2 RID: 19138
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x0200068F RID: 1679
		public enum AxisOptions
		{
			// Token: 0x0400507B RID: 20603
			ForwardAxis,
			// Token: 0x0400507C RID: 20604
			SidewaysAxis
		}

		// Token: 0x02000690 RID: 1680
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x0400507D RID: 20605
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x0400507E RID: 20606
			public string axisName;

			// Token: 0x020006F2 RID: 1778
			public enum MappingType
			{
				// Token: 0x04005278 RID: 21112
				NamedAxis,
				// Token: 0x04005279 RID: 21113
				MousePositionX,
				// Token: 0x0400527A RID: 21114
				MousePositionY,
				// Token: 0x0400527B RID: 21115
				MousePositionZ
			}
		}
	}
}
