using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000567 RID: 1383
	[Serializable]
	public class MotionBlurModel : PostProcessingModel
	{
		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06002327 RID: 8999 RVA: 0x001EF7A5 File Offset: 0x001ED9A5
		// (set) Token: 0x06002328 RID: 9000 RVA: 0x001EF7AD File Offset: 0x001ED9AD
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

		// Token: 0x06002329 RID: 9001 RVA: 0x001EF7B6 File Offset: 0x001ED9B6
		public override void Reset()
		{
			this.m_Settings = MotionBlurModel.Settings.defaultSettings;
		}

		// Token: 0x04004A85 RID: 19077
		[SerializeField]
		private MotionBlurModel.Settings m_Settings = MotionBlurModel.Settings.defaultSettings;

		// Token: 0x020006C6 RID: 1734
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059F RID: 1439
			// (get) Token: 0x06002724 RID: 10020 RVA: 0x001FE5CC File Offset: 0x001FC7CC
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

			// Token: 0x040050F6 RID: 20726
			[Range(0f, 360f)]
			[Tooltip("The angle of rotary shutter. Larger values give longer exposure.")]
			public float shutterAngle;

			// Token: 0x040050F7 RID: 20727
			[Range(4f, 32f)]
			[Tooltip("The amount of sample points, which affects quality and performances.")]
			public int sampleCount;

			// Token: 0x040050F8 RID: 20728
			[Range(0f, 1f)]
			[Tooltip("The strength of multiple frame blending. The opacity of preceding frames are determined from this coefficient and time differences.")]
			public float frameBlending;
		}
	}
}
