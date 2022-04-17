using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000579 RID: 1401
	[Serializable]
	public class MotionBlurModel : PostProcessingModel
	{
		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x0600239E RID: 9118 RVA: 0x001F9AC5 File Offset: 0x001F7CC5
		// (set) Token: 0x0600239F RID: 9119 RVA: 0x001F9ACD File Offset: 0x001F7CCD
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

		// Token: 0x060023A0 RID: 9120 RVA: 0x001F9AD6 File Offset: 0x001F7CD6
		public override void Reset()
		{
			this.m_Settings = MotionBlurModel.Settings.defaultSettings;
		}

		// Token: 0x04004BD9 RID: 19417
		[SerializeField]
		private MotionBlurModel.Settings m_Settings = MotionBlurModel.Settings.defaultSettings;

		// Token: 0x020006D5 RID: 1749
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A6 RID: 1446
			// (get) Token: 0x06002790 RID: 10128 RVA: 0x00208444 File Offset: 0x00206644
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

			// Token: 0x0400522D RID: 21037
			[Range(0f, 360f)]
			[Tooltip("The angle of rotary shutter. Larger values give longer exposure.")]
			public float shutterAngle;

			// Token: 0x0400522E RID: 21038
			[Range(4f, 32f)]
			[Tooltip("The amount of sample points, which affects quality and performances.")]
			public int sampleCount;

			// Token: 0x0400522F RID: 21039
			[Range(0f, 1f)]
			[Tooltip("The strength of multiple frame blending. The opacity of preceding frames are determined from this coefficient and time differences.")]
			public float frameBlending;
		}
	}
}
