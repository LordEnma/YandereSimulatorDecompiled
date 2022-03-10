using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000566 RID: 1382
	[Serializable]
	public class BloomModel : PostProcessingModel
	{
		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x0600233C RID: 9020 RVA: 0x001F512E File Offset: 0x001F332E
		// (set) Token: 0x0600233D RID: 9021 RVA: 0x001F5136 File Offset: 0x001F3336
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

		// Token: 0x0600233E RID: 9022 RVA: 0x001F513F File Offset: 0x001F333F
		public override void Reset()
		{
			this.m_Settings = BloomModel.Settings.defaultSettings;
		}

		// Token: 0x04004B27 RID: 19239
		[SerializeField]
		private BloomModel.Settings m_Settings = BloomModel.Settings.defaultSettings;

		// Token: 0x020006B2 RID: 1714
		[Serializable]
		public struct BloomSettings
		{
			// Token: 0x1700058F RID: 1423
			// (get) Token: 0x06002744 RID: 10052 RVA: 0x002033D8 File Offset: 0x002015D8
			// (set) Token: 0x06002743 RID: 10051 RVA: 0x002033CA File Offset: 0x002015CA
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
			// (get) Token: 0x06002745 RID: 10053 RVA: 0x002033E8 File Offset: 0x002015E8
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

			// Token: 0x04005116 RID: 20758
			[Min(0f)]
			[Tooltip("Strength of the bloom filter.")]
			public float intensity;

			// Token: 0x04005117 RID: 20759
			[Min(0f)]
			[Tooltip("Filters out pixels under this level of brightness.")]
			public float threshold;

			// Token: 0x04005118 RID: 20760
			[Range(0f, 1f)]
			[Tooltip("Makes transition between under/over-threshold gradual (0 = hard threshold, 1 = soft threshold).")]
			public float softKnee;

			// Token: 0x04005119 RID: 20761
			[Range(1f, 7f)]
			[Tooltip("Changes extent of veiling effects in a screen resolution-independent fashion.")]
			public float radius;

			// Token: 0x0400511A RID: 20762
			[Tooltip("Reduces flashing noise with an additional filter.")]
			public bool antiFlicker;
		}

		// Token: 0x020006B3 RID: 1715
		[Serializable]
		public struct LensDirtSettings
		{
			// Token: 0x17000591 RID: 1425
			// (get) Token: 0x06002746 RID: 10054 RVA: 0x00203438 File Offset: 0x00201638
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

			// Token: 0x0400511B RID: 20763
			[Tooltip("Dirtiness texture to add smudges or dust to the lens.")]
			public Texture texture;

			// Token: 0x0400511C RID: 20764
			[Min(0f)]
			[Tooltip("Amount of lens dirtiness.")]
			public float intensity;
		}

		// Token: 0x020006B4 RID: 1716
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000592 RID: 1426
			// (get) Token: 0x06002747 RID: 10055 RVA: 0x00203464 File Offset: 0x00201664
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

			// Token: 0x0400511D RID: 20765
			public BloomModel.BloomSettings bloom;

			// Token: 0x0400511E RID: 20766
			public BloomModel.LensDirtSettings lensDirt;
		}
	}
}
