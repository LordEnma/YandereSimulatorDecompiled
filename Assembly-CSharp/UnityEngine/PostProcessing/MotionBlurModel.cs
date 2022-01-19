using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056C RID: 1388
	[Serializable]
	public class MotionBlurModel : PostProcessingModel
	{
		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x06002348 RID: 9032 RVA: 0x001F2B39 File Offset: 0x001F0D39
		// (set) Token: 0x06002349 RID: 9033 RVA: 0x001F2B41 File Offset: 0x001F0D41
		public MotionBlurModel.Settings settings
		{
			get
			{
				return this.m_Settings;
			}
			set
			{
				this.m_Settings = value;
			}
		}

		// Token: 0x0600234A RID: 9034 RVA: 0x001F2B4A File Offset: 0x001F0D4A
		public override void Reset()
		{
			this.m_Settings = MotionBlurModel.Settings.defaultSettings;
		}

		// Token: 0x04004AE8 RID: 19176
		[SerializeField]
		private MotionBlurModel.Settings m_Settings = MotionBlurModel.Settings.defaultSettings;

		// Token: 0x020006CC RID: 1740
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A0 RID: 1440
			// (get) Token: 0x06002745 RID: 10053 RVA: 0x00201984 File Offset: 0x001FFB84
			public static MotionBlurModel.Settings defaultSettings
			{
				get
				{
					return new MotionBlurModel.Settings
					{
						shutterAngle = 270f,
						sampleCount = 10,
						frameBlending = 0f
					};
				}
			}

			// Token: 0x04005165 RID: 20837
			[Range(0f, 360f)]
			[Tooltip("The angle of rotary shutter. Larger values give longer exposure.")]
			public float shutterAngle;

			// Token: 0x04005166 RID: 20838
			[Range(4f, 32f)]
			[Tooltip("The amount of sample points, which affects quality and performances.")]
			public int sampleCount;

			// Token: 0x04005167 RID: 20839
			[Range(0f, 1f)]
			[Tooltip("The strength of multiple frame blending. The opacity of preceding frames are determined from this coefficient and time differences.")]
			public float frameBlending;
		}
	}
}
