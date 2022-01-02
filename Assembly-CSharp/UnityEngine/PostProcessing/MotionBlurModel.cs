using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000569 RID: 1385
	[Serializable]
	public class MotionBlurModel : PostProcessingModel
	{
		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x0600233B RID: 9019 RVA: 0x001F14C9 File Offset: 0x001EF6C9
		// (set) Token: 0x0600233C RID: 9020 RVA: 0x001F14D1 File Offset: 0x001EF6D1
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

		// Token: 0x0600233D RID: 9021 RVA: 0x001F14DA File Offset: 0x001EF6DA
		public override void Reset()
		{
			this.m_Settings = MotionBlurModel.Settings.defaultSettings;
		}

		// Token: 0x04004ACD RID: 19149
		[SerializeField]
		private MotionBlurModel.Settings m_Settings = MotionBlurModel.Settings.defaultSettings;

		// Token: 0x020006C9 RID: 1737
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A0 RID: 1440
			// (get) Token: 0x06002738 RID: 10040 RVA: 0x00200314 File Offset: 0x001FE514
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

			// Token: 0x0400514A RID: 20810
			[Range(0f, 360f)]
			[Tooltip("The angle of rotary shutter. Larger values give longer exposure.")]
			public float shutterAngle;

			// Token: 0x0400514B RID: 20811
			[Range(4f, 32f)]
			[Tooltip("The amount of sample points, which affects quality and performances.")]
			public int sampleCount;

			// Token: 0x0400514C RID: 20812
			[Range(0f, 1f)]
			[Tooltip("The strength of multiple frame blending. The opacity of preceding frames are determined from this coefficient and time differences.")]
			public float frameBlending;
		}
	}
}
