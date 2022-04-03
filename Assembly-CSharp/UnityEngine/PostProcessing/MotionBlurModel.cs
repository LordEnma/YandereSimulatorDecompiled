using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000578 RID: 1400
	[Serializable]
	public class MotionBlurModel : PostProcessingModel
	{
		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x0600238F RID: 9103 RVA: 0x001F8B39 File Offset: 0x001F6D39
		// (set) Token: 0x06002390 RID: 9104 RVA: 0x001F8B41 File Offset: 0x001F6D41
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

		// Token: 0x06002391 RID: 9105 RVA: 0x001F8B4A File Offset: 0x001F6D4A
		public override void Reset()
		{
			this.m_Settings = MotionBlurModel.Settings.defaultSettings;
		}

		// Token: 0x04004BC3 RID: 19395
		[SerializeField]
		private MotionBlurModel.Settings m_Settings = MotionBlurModel.Settings.defaultSettings;

		// Token: 0x020006D4 RID: 1748
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A5 RID: 1445
			// (get) Token: 0x06002781 RID: 10113 RVA: 0x002074B8 File Offset: 0x002056B8
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

			// Token: 0x04005217 RID: 21015
			[Range(0f, 360f)]
			[Tooltip("The angle of rotary shutter. Larger values give longer exposure.")]
			public float shutterAngle;

			// Token: 0x04005218 RID: 21016
			[Range(4f, 32f)]
			[Tooltip("The amount of sample points, which affects quality and performances.")]
			public int sampleCount;

			// Token: 0x04005219 RID: 21017
			[Range(0f, 1f)]
			[Tooltip("The strength of multiple frame blending. The opacity of preceding frames are determined from this coefficient and time differences.")]
			public float frameBlending;
		}
	}
}
