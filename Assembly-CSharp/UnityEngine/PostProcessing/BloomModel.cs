using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000565 RID: 1381
	[Serializable]
	public class BloomModel : PostProcessingModel
	{
		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06002336 RID: 9014 RVA: 0x001F4756 File Offset: 0x001F2956
		// (set) Token: 0x06002337 RID: 9015 RVA: 0x001F475E File Offset: 0x001F295E
		public BloomModel.Settings settings
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

		// Token: 0x06002338 RID: 9016 RVA: 0x001F4767 File Offset: 0x001F2967
		public override void Reset()
		{
			this.m_Settings = BloomModel.Settings.defaultSettings;
		}

		// Token: 0x04004B0A RID: 19210
		[SerializeField]
		private BloomModel.Settings m_Settings = BloomModel.Settings.defaultSettings;

		// Token: 0x020006B1 RID: 1713
		[Serializable]
		public struct BloomSettings
		{
			// Token: 0x1700058F RID: 1423
			// (get) Token: 0x0600273E RID: 10046 RVA: 0x00202A00 File Offset: 0x00200C00
			// (set) Token: 0x0600273D RID: 10045 RVA: 0x002029F2 File Offset: 0x00200BF2
			public float thresholdLinear
			{
				get
				{
					return Mathf.GammaToLinearSpace(this.threshold);
				}
				set
				{
					this.threshold = Mathf.LinearToGammaSpace(value);
				}
			}

			// Token: 0x17000590 RID: 1424
			// (get) Token: 0x0600273F RID: 10047 RVA: 0x00202A10 File Offset: 0x00200C10
			public static BloomModel.BloomSettings defaultSettings
			{
				get
				{
					return new BloomModel.BloomSettings
					{
						intensity = 0.5f,
						threshold = 1.1f,
						softKnee = 0.5f,
						radius = 4f,
						antiFlicker = false
					};
				}
			}

			// Token: 0x040050F9 RID: 20729
			[Min(0f)]
			[Tooltip("Strength of the bloom filter.")]
			public float intensity;

			// Token: 0x040050FA RID: 20730
			[Min(0f)]
			[Tooltip("Filters out pixels under this level of brightness.")]
			public float threshold;

			// Token: 0x040050FB RID: 20731
			[Range(0f, 1f)]
			[Tooltip("Makes transition between under/over-threshold gradual (0 = hard threshold, 1 = soft threshold).")]
			public float softKnee;

			// Token: 0x040050FC RID: 20732
			[Range(1f, 7f)]
			[Tooltip("Changes extent of veiling effects in a screen resolution-independent fashion.")]
			public float radius;

			// Token: 0x040050FD RID: 20733
			[Tooltip("Reduces flashing noise with an additional filter.")]
			public bool antiFlicker;
		}

		// Token: 0x020006B2 RID: 1714
		[Serializable]
		public struct LensDirtSettings
		{
			// Token: 0x17000591 RID: 1425
			// (get) Token: 0x06002740 RID: 10048 RVA: 0x00202A60 File Offset: 0x00200C60
			public static BloomModel.LensDirtSettings defaultSettings
			{
				get
				{
					return new BloomModel.LensDirtSettings
					{
						texture = null,
						intensity = 3f
					};
				}
			}

			// Token: 0x040050FE RID: 20734
			[Tooltip("Dirtiness texture to add smudges or dust to the lens.")]
			public Texture texture;

			// Token: 0x040050FF RID: 20735
			[Min(0f)]
			[Tooltip("Amount of lens dirtiness.")]
			public float intensity;
		}

		// Token: 0x020006B3 RID: 1715
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000592 RID: 1426
			// (get) Token: 0x06002741 RID: 10049 RVA: 0x00202A8C File Offset: 0x00200C8C
			public static BloomModel.Settings defaultSettings
			{
				get
				{
					return new BloomModel.Settings
					{
						bloom = BloomModel.BloomSettings.defaultSettings,
						lensDirt = BloomModel.LensDirtSettings.defaultSettings
					};
				}
			}

			// Token: 0x04005100 RID: 20736
			public BloomModel.BloomSettings bloom;

			// Token: 0x04005101 RID: 20737
			public BloomModel.LensDirtSettings lensDirt;
		}
	}
}
