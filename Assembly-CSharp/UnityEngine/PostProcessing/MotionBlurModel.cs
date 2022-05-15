using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057B RID: 1403
	[Serializable]
	public class MotionBlurModel : PostProcessingModel
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x060023B2 RID: 9138 RVA: 0x001FC69D File Offset: 0x001FA89D
		// (set) Token: 0x060023B3 RID: 9139 RVA: 0x001FC6A5 File Offset: 0x001FA8A5
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

		// Token: 0x060023B4 RID: 9140 RVA: 0x001FC6AE File Offset: 0x001FA8AE
		public override void Reset()
		{
			this.m_Settings = MotionBlurModel.Settings.defaultSettings;
		}

		// Token: 0x04004C16 RID: 19478
		[SerializeField]
		private MotionBlurModel.Settings m_Settings = MotionBlurModel.Settings.defaultSettings;

		// Token: 0x020006D7 RID: 1751
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A7 RID: 1447
			// (get) Token: 0x060027A4 RID: 10148 RVA: 0x0020B130 File Offset: 0x00209330
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

			// Token: 0x04005272 RID: 21106
			[Range(0f, 360f)]
			[Tooltip("The angle of rotary shutter. Larger values give longer exposure.")]
			public float shutterAngle;

			// Token: 0x04005273 RID: 21107
			[Range(4f, 32f)]
			[Tooltip("The amount of sample points, which affects quality and performances.")]
			public int sampleCount;

			// Token: 0x04005274 RID: 21108
			[Range(0f, 1f)]
			[Tooltip("The strength of multiple frame blending. The opacity of preceding frames are determined from this coefficient and time differences.")]
			public float frameBlending;
		}
	}
}
