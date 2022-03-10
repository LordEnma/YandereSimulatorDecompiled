using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000565 RID: 1381
	[Serializable]
	public class AntialiasingModel : PostProcessingModel
	{
		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06002338 RID: 9016 RVA: 0x001F50FD File Offset: 0x001F32FD
		// (set) Token: 0x06002339 RID: 9017 RVA: 0x001F5105 File Offset: 0x001F3305
		public AntialiasingModel.Settings settings
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

		// Token: 0x0600233A RID: 9018 RVA: 0x001F510E File Offset: 0x001F330E
		public override void Reset()
		{
			this.m_Settings = AntialiasingModel.Settings.defaultSettings;
		}

		// Token: 0x04004B26 RID: 19238
		[SerializeField]
		private AntialiasingModel.Settings m_Settings = AntialiasingModel.Settings.defaultSettings;

		// Token: 0x020006AB RID: 1707
		public enum Method
		{
			// Token: 0x040050FD RID: 20733
			Fxaa,
			// Token: 0x040050FE RID: 20734
			Taa
		}

		// Token: 0x020006AC RID: 1708
		public enum FxaaPreset
		{
			// Token: 0x04005100 RID: 20736
			ExtremePerformance,
			// Token: 0x04005101 RID: 20737
			Performance,
			// Token: 0x04005102 RID: 20738
			Default,
			// Token: 0x04005103 RID: 20739
			Quality,
			// Token: 0x04005104 RID: 20740
			ExtremeQuality
		}

		// Token: 0x020006AD RID: 1709
		[Serializable]
		public struct FxaaQualitySettings
		{
			// Token: 0x04005105 RID: 20741
			[Tooltip("The amount of desired sub-pixel aliasing removal. Effects the sharpeness of the output.")]
			[Range(0f, 1f)]
			public float subpixelAliasingRemovalAmount;

			// Token: 0x04005106 RID: 20742
			[Tooltip("The minimum amount of local contrast required to qualify a region as containing an edge.")]
			[Range(0.063f, 0.333f)]
			public float edgeDetectionThreshold;

			// Token: 0x04005107 RID: 20743
			[Tooltip("Local contrast adaptation value to disallow the algorithm from executing on the darker regions.")]
			[Range(0f, 0.0833f)]
			public float minimumRequiredLuminance;

			// Token: 0x04005108 RID: 20744
			public static AntialiasingModel.FxaaQualitySettings[] presets = new AntialiasingModel.FxaaQualitySettings[]
			{
				new AntialiasingModel.FxaaQualitySettings
				{
					subpixelAliasingRemovalAmount = 0f,
					edgeDetectionThreshold = 0.333f,
					minimumRequiredLuminance = 0.0833f
				},
				new AntialiasingModel.FxaaQualitySettings
				{
					subpixelAliasingRemovalAmount = 0.25f,
					edgeDetectionThreshold = 0.25f,
					minimumRequiredLuminance = 0.0833f
				},
				new AntialiasingModel.FxaaQualitySettings
				{
					subpixelAliasingRemovalAmount = 0.75f,
					edgeDetectionThreshold = 0.166f,
					minimumRequiredLuminance = 0.0833f
				},
				new AntialiasingModel.FxaaQualitySettings
				{
					subpixelAliasingRemovalAmount = 1f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.0625f
				},
				new AntialiasingModel.FxaaQualitySettings
				{
					subpixelAliasingRemovalAmount = 1f,
					edgeDetectionThreshold = 0.063f,
					minimumRequiredLuminance = 0.0312f
				}
			};
		}

		// Token: 0x020006AE RID: 1710
		[Serializable]
		public struct FxaaConsoleSettings
		{
			// Token: 0x04005109 RID: 20745
			[Tooltip("The amount of spread applied to the sampling coordinates while sampling for subpixel information.")]
			[Range(0.33f, 0.5f)]
			public float subpixelSpreadAmount;

			// Token: 0x0400510A RID: 20746
			[Tooltip("This value dictates how sharp the edges in the image are kept; a higher value implies sharper edges.")]
			[Range(2f, 8f)]
			public float edgeSharpnessAmount;

			// Token: 0x0400510B RID: 20747
			[Tooltip("The minimum amount of local contrast required to qualify a region as containing an edge.")]
			[Range(0.125f, 0.25f)]
			public float edgeDetectionThreshold;

			// Token: 0x0400510C RID: 20748
			[Tooltip("Local contrast adaptation value to disallow the algorithm from executing on the darker regions.")]
			[Range(0.04f, 0.06f)]
			public float minimumRequiredLuminance;

			// Token: 0x0400510D RID: 20749
			public static AntialiasingModel.FxaaConsoleSettings[] presets = new AntialiasingModel.FxaaConsoleSettings[]
			{
				new AntialiasingModel.FxaaConsoleSettings
				{
					subpixelSpreadAmount = 0.33f,
					edgeSharpnessAmount = 8f,
					edgeDetectionThreshold = 0.25f,
					minimumRequiredLuminance = 0.06f
				},
				new AntialiasingModel.FxaaConsoleSettings
				{
					subpixelSpreadAmount = 0.33f,
					edgeSharpnessAmount = 8f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.06f
				},
				new AntialiasingModel.FxaaConsoleSettings
				{
					subpixelSpreadAmount = 0.5f,
					edgeSharpnessAmount = 8f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.05f
				},
				new AntialiasingModel.FxaaConsoleSettings
				{
					subpixelSpreadAmount = 0.5f,
					edgeSharpnessAmount = 4f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.04f
				},
				new AntialiasingModel.FxaaConsoleSettings
				{
					subpixelSpreadAmount = 0.5f,
					edgeSharpnessAmount = 2f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.04f
				}
			};
		}

		// Token: 0x020006AF RID: 1711
		[Serializable]
		public struct FxaaSettings
		{
			// Token: 0x1700058C RID: 1420
			// (get) Token: 0x06002740 RID: 10048 RVA: 0x0020332C File Offset: 0x0020152C
			public static AntialiasingModel.FxaaSettings defaultSettings
			{
				get
				{
					return new AntialiasingModel.FxaaSettings
					{
						preset = AntialiasingModel.FxaaPreset.Default
					};
				}
			}

			// Token: 0x0400510E RID: 20750
			public AntialiasingModel.FxaaPreset preset;
		}

		// Token: 0x020006B0 RID: 1712
		[Serializable]
		public struct TaaSettings
		{
			// Token: 0x1700058D RID: 1421
			// (get) Token: 0x06002741 RID: 10049 RVA: 0x0020334C File Offset: 0x0020154C
			public static AntialiasingModel.TaaSettings defaultSettings
			{
				get
				{
					return new AntialiasingModel.TaaSettings
					{
						jitterSpread = 0.75f,
						sharpen = 0.3f,
						stationaryBlending = 0.95f,
						motionBlending = 0.85f
					};
				}
			}

			// Token: 0x0400510F RID: 20751
			[Tooltip("The diameter (in texels) inside which jitter samples are spread. Smaller values result in crisper but more aliased output, while larger values result in more stable but blurrier output.")]
			[Range(0.1f, 1f)]
			public float jitterSpread;

			// Token: 0x04005110 RID: 20752
			[Tooltip("Controls the amount of sharpening applied to the color buffer.")]
			[Range(0f, 3f)]
			public float sharpen;

			// Token: 0x04005111 RID: 20753
			[Tooltip("The blend coefficient for a stationary fragment. Controls the percentage of history sample blended into the final color.")]
			[Range(0f, 0.99f)]
			public float stationaryBlending;

			// Token: 0x04005112 RID: 20754
			[Tooltip("The blend coefficient for a fragment with significant motion. Controls the percentage of history sample blended into the final color.")]
			[Range(0f, 0.99f)]
			public float motionBlending;
		}

		// Token: 0x020006B1 RID: 1713
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700058E RID: 1422
			// (get) Token: 0x06002742 RID: 10050 RVA: 0x00203394 File Offset: 0x00201594
			public static AntialiasingModel.Settings defaultSettings
			{
				get
				{
					return new AntialiasingModel.Settings
					{
						method = AntialiasingModel.Method.Fxaa,
						fxaaSettings = AntialiasingModel.FxaaSettings.defaultSettings,
						taaSettings = AntialiasingModel.TaaSettings.defaultSettings
					};
				}
			}

			// Token: 0x04005113 RID: 20755
			public AntialiasingModel.Method method;

			// Token: 0x04005114 RID: 20756
			public AntialiasingModel.FxaaSettings fxaaSettings;

			// Token: 0x04005115 RID: 20757
			public AntialiasingModel.TaaSettings taaSettings;
		}
	}
}
