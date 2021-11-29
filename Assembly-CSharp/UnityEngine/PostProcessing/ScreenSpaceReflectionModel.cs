using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000568 RID: 1384
	[Serializable]
	public class ScreenSpaceReflectionModel : PostProcessingModel
	{
		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x0600232B RID: 9003 RVA: 0x001EF7D6 File Offset: 0x001ED9D6
		// (set) Token: 0x0600232C RID: 9004 RVA: 0x001EF7DE File Offset: 0x001ED9DE
		public ScreenSpaceReflectionModel.Settings settings
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

		// Token: 0x0600232D RID: 9005 RVA: 0x001EF7E7 File Offset: 0x001ED9E7
		public override void Reset()
		{
			this.m_Settings = ScreenSpaceReflectionModel.Settings.defaultSettings;
		}

		// Token: 0x04004A86 RID: 19078
		[SerializeField]
		private ScreenSpaceReflectionModel.Settings m_Settings = ScreenSpaceReflectionModel.Settings.defaultSettings;

		// Token: 0x020006C7 RID: 1735
		public enum SSRResolution
		{
			// Token: 0x040050FA RID: 20730
			High,
			// Token: 0x040050FB RID: 20731
			Low = 2
		}

		// Token: 0x020006C8 RID: 1736
		public enum SSRReflectionBlendType
		{
			// Token: 0x040050FD RID: 20733
			PhysicallyBased,
			// Token: 0x040050FE RID: 20734
			Additive
		}

		// Token: 0x020006C9 RID: 1737
		[Serializable]
		public struct IntensitySettings
		{
			// Token: 0x040050FF RID: 20735
			[Tooltip("Nonphysical multiplier for the SSR reflections. 1.0 is physically based.")]
			[Range(0f, 2f)]
			public float reflectionMultiplier;

			// Token: 0x04005100 RID: 20736
			[Tooltip("How far away from the maxDistance to begin fading SSR.")]
			[Range(0f, 1000f)]
			public float fadeDistance;

			// Token: 0x04005101 RID: 20737
			[Tooltip("Amplify Fresnel fade out. Increase if floor reflections look good close to the surface and bad farther 'under' the floor.")]
			[Range(0f, 1f)]
			public float fresnelFade;

			// Token: 0x04005102 RID: 20738
			[Tooltip("Higher values correspond to a faster Fresnel fade as the reflection changes from the grazing angle.")]
			[Range(0.1f, 10f)]
			public float fresnelFadePower;
		}

		// Token: 0x020006CA RID: 1738
		[Serializable]
		public struct ReflectionSettings
		{
			// Token: 0x04005103 RID: 20739
			[Tooltip("How the reflections are blended into the render.")]
			public ScreenSpaceReflectionModel.SSRReflectionBlendType blendType;

			// Token: 0x04005104 RID: 20740
			[Tooltip("Half resolution SSRR is much faster, but less accurate.")]
			public ScreenSpaceReflectionModel.SSRResolution reflectionQuality;

			// Token: 0x04005105 RID: 20741
			[Tooltip("Maximum reflection distance in world units.")]
			[Range(0.1f, 300f)]
			public float maxDistance;

			// Token: 0x04005106 RID: 20742
			[Tooltip("Max raytracing length.")]
			[Range(16f, 1024f)]
			public int iterationCount;

			// Token: 0x04005107 RID: 20743
			[Tooltip("Log base 2 of ray tracing coarse step size. Higher traces farther, lower gives better quality silhouettes.")]
			[Range(1f, 16f)]
			public int stepSize;

			// Token: 0x04005108 RID: 20744
			[Tooltip("Typical thickness of columns, walls, furniture, and other objects that reflection rays might pass behind.")]
			[Range(0.01f, 10f)]
			public float widthModifier;

			// Token: 0x04005109 RID: 20745
			[Tooltip("Blurriness of reflections.")]
			[Range(0.1f, 8f)]
			public float reflectionBlur;

			// Token: 0x0400510A RID: 20746
			[Tooltip("Disable for a performance gain in scenes where most glossy objects are horizontal, like floors, water, and tables. Leave on for scenes with glossy vertical objects.")]
			public bool reflectBackfaces;
		}

		// Token: 0x020006CB RID: 1739
		[Serializable]
		public struct ScreenEdgeMask
		{
			// Token: 0x0400510B RID: 20747
			[Tooltip("Higher = fade out SSRR near the edge of the screen so that reflections don't pop under camera motion.")]
			[Range(0f, 1f)]
			public float intensity;
		}

		// Token: 0x020006CC RID: 1740
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A0 RID: 1440
			// (get) Token: 0x06002725 RID: 10021 RVA: 0x001FE604 File Offset: 0x001FC804
			public static ScreenSpaceReflectionModel.Settings defaultSettings
			{
				get
				{
					return new ScreenSpaceReflectionModel.Settings
					{
						reflection = new ScreenSpaceReflectionModel.ReflectionSettings
						{
							blendType = ScreenSpaceReflectionModel.SSRReflectionBlendType.PhysicallyBased,
							reflectionQuality = ScreenSpaceReflectionModel.SSRResolution.Low,
							maxDistance = 100f,
							iterationCount = 256,
							stepSize = 3,
							widthModifier = 0.5f,
							reflectionBlur = 1f,
							reflectBackfaces = false
						},
						intensity = new ScreenSpaceReflectionModel.IntensitySettings
						{
							reflectionMultiplier = 1f,
							fadeDistance = 100f,
							fresnelFade = 1f,
							fresnelFadePower = 1f
						},
						screenEdgeMask = new ScreenSpaceReflectionModel.ScreenEdgeMask
						{
							intensity = 0.03f
						}
					};
				}
			}

			// Token: 0x0400510C RID: 20748
			public ScreenSpaceReflectionModel.ReflectionSettings reflection;

			// Token: 0x0400510D RID: 20749
			public ScreenSpaceReflectionModel.IntensitySettings intensity;

			// Token: 0x0400510E RID: 20750
			public ScreenSpaceReflectionModel.ScreenEdgeMask screenEdgeMask;
		}
	}
}
