using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000569 RID: 1385
	[Serializable]
	public class MotionBlurModel : PostProcessingModel
	{
		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06002338 RID: 9016 RVA: 0x001F0ED9 File Offset: 0x001EF0D9
		// (set) Token: 0x06002339 RID: 9017 RVA: 0x001F0EE1 File Offset: 0x001EF0E1
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

		// Token: 0x0600233A RID: 9018 RVA: 0x001F0EEA File Offset: 0x001EF0EA
		public override void Reset()
		{
			this.m_Settings = MotionBlurModel.Settings.defaultSettings;
		}

		// Token: 0x04004AC4 RID: 19140
		[SerializeField]
		private MotionBlurModel.Settings m_Settings = MotionBlurModel.Settings.defaultSettings;

		// Token: 0x020006C9 RID: 1737
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059F RID: 1439
			// (get) Token: 0x06002735 RID: 10037 RVA: 0x001FFD00 File Offset: 0x001FDF00
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

			// Token: 0x04005141 RID: 20801
			[Range(0f, 360f)]
			[Tooltip("The angle of rotary shutter. Larger values give longer exposure.")]
			public float shutterAngle;

			// Token: 0x04005142 RID: 20802
			[Range(4f, 32f)]
			[Tooltip("The amount of sample points, which affects quality and performances.")]
			public int sampleCount;

			// Token: 0x04005143 RID: 20803
			[Range(0f, 1f)]
			[Tooltip("The strength of multiple frame blending. The opacity of preceding frames are determined from this coefficient and time differences.")]
			public float frameBlending;
		}
	}
}
