using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056F RID: 1391
	[Serializable]
	public class MotionBlurModel : PostProcessingModel
	{
		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x06002367 RID: 9063 RVA: 0x001F5361 File Offset: 0x001F3561
		// (set) Token: 0x06002368 RID: 9064 RVA: 0x001F5369 File Offset: 0x001F3569
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

		// Token: 0x06002369 RID: 9065 RVA: 0x001F5372 File Offset: 0x001F3572
		public override void Reset()
		{
			this.m_Settings = MotionBlurModel.Settings.defaultSettings;
		}

		// Token: 0x04004B32 RID: 19250
		[SerializeField]
		private MotionBlurModel.Settings m_Settings = MotionBlurModel.Settings.defaultSettings;

		// Token: 0x020006CB RID: 1739
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A4 RID: 1444
			// (get) Token: 0x06002759 RID: 10073 RVA: 0x00203B90 File Offset: 0x00201D90
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

			// Token: 0x04005186 RID: 20870
			[Range(0f, 360f)]
			[Tooltip("The angle of rotary shutter. Larger values give longer exposure.")]
			public float shutterAngle;

			// Token: 0x04005187 RID: 20871
			[Range(4f, 32f)]
			[Tooltip("The amount of sample points, which affects quality and performances.")]
			public int sampleCount;

			// Token: 0x04005188 RID: 20872
			[Range(0f, 1f)]
			[Tooltip("The strength of multiple frame blending. The opacity of preceding frames are determined from this coefficient and time differences.")]
			public float frameBlending;
		}
	}
}
