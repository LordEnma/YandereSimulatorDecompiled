using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057A RID: 1402
	[Serializable]
	public class MotionBlurModel : PostProcessingModel
	{
		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x060023A7 RID: 9127 RVA: 0x001FAF51 File Offset: 0x001F9151
		// (set) Token: 0x060023A8 RID: 9128 RVA: 0x001FAF59 File Offset: 0x001F9159
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

		// Token: 0x060023A9 RID: 9129 RVA: 0x001FAF62 File Offset: 0x001F9162
		public override void Reset()
		{
			this.m_Settings = MotionBlurModel.Settings.defaultSettings;
		}

		// Token: 0x04004BEF RID: 19439
		[SerializeField]
		private MotionBlurModel.Settings m_Settings = MotionBlurModel.Settings.defaultSettings;

		// Token: 0x020006D6 RID: 1750
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A6 RID: 1446
			// (get) Token: 0x06002799 RID: 10137 RVA: 0x002099E4 File Offset: 0x00207BE4
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

			// Token: 0x0400524B RID: 21067
			[Range(0f, 360f)]
			[Tooltip("The angle of rotary shutter. Larger values give longer exposure.")]
			public float shutterAngle;

			// Token: 0x0400524C RID: 21068
			[Range(4f, 32f)]
			[Tooltip("The amount of sample points, which affects quality and performances.")]
			public int sampleCount;

			// Token: 0x0400524D RID: 21069
			[Range(0f, 1f)]
			[Tooltip("The strength of multiple frame blending. The opacity of preceding frames are determined from this coefficient and time differences.")]
			public float frameBlending;
		}
	}
}
