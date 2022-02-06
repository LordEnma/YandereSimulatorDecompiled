using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056C RID: 1388
	[Serializable]
	public class MotionBlurModel : PostProcessingModel
	{
		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x06002351 RID: 9041 RVA: 0x001F38F5 File Offset: 0x001F1AF5
		// (set) Token: 0x06002352 RID: 9042 RVA: 0x001F38FD File Offset: 0x001F1AFD
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

		// Token: 0x06002353 RID: 9043 RVA: 0x001F3906 File Offset: 0x001F1B06
		public override void Reset()
		{
			this.m_Settings = MotionBlurModel.Settings.defaultSettings;
		}

		// Token: 0x04004AFC RID: 19196
		[SerializeField]
		private MotionBlurModel.Settings m_Settings = MotionBlurModel.Settings.defaultSettings;

		// Token: 0x020006C6 RID: 1734
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A1 RID: 1441
			// (get) Token: 0x0600273A RID: 10042 RVA: 0x0020205C File Offset: 0x0020025C
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

			// Token: 0x0400514B RID: 20811
			[Range(0f, 360f)]
			[Tooltip("The angle of rotary shutter. Larger values give longer exposure.")]
			public float shutterAngle;

			// Token: 0x0400514C RID: 20812
			[Range(4f, 32f)]
			[Tooltip("The amount of sample points, which affects quality and performances.")]
			public int sampleCount;

			// Token: 0x0400514D RID: 20813
			[Range(0f, 1f)]
			[Tooltip("The strength of multiple frame blending. The opacity of preceding frames are determined from this coefficient and time differences.")]
			public float frameBlending;
		}
	}
}
