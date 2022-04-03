using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000579 RID: 1401
	[Serializable]
	public class ScreenSpaceReflectionModel : PostProcessingModel
	{
		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x06002393 RID: 9107 RVA: 0x001F8B6A File Offset: 0x001F6D6A
		// (set) Token: 0x06002394 RID: 9108 RVA: 0x001F8B72 File Offset: 0x001F6D72
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

		// Token: 0x06002395 RID: 9109 RVA: 0x001F8B7B File Offset: 0x001F6D7B
		public override void Reset()
		{
			this.m_Settings = ScreenSpaceReflectionModel.Settings.defaultSettings;
		}

		// Token: 0x04004BC4 RID: 19396
		[SerializeField]
		private ScreenSpaceReflectionModel.Settings m_Settings = ScreenSpaceReflectionModel.Settings.defaultSettings;

		// Token: 0x020006D5 RID: 1749
		public enum SSRResolution
		{
			// Token: 0x0400521B RID: 21019
			High,
			// Token: 0x0400521C RID: 21020
			Low = 2
		}

		// Token: 0x020006D6 RID: 1750
		public enum SSRReflectionBlendType
		{
			// Token: 0x0400521E RID: 21022
			PhysicallyBased,
			// Token: 0x0400521F RID: 21023
			Additive
		}

		// Token: 0x020006D7 RID: 1751
		[Serializable]
		public struct IntensitySettings
		{
			// Token: 0x04005220 RID: 21024
			[Tooltip("Nonphysical multiplier for the SSR reflections. 1.0 is physically based.")]
			[Range(0f, 2f)]
			public float reflectionMultiplier;

			// Token: 0x04005221 RID: 21025
			[Tooltip("How far away from the maxDistance to begin fading SSR.")]
			[Range(0f, 1000f)]
			public float fadeDistance;

			// Token: 0x04005222 RID: 21026
			[Tooltip("Amplify Fresnel fade out. Increase if floor reflections look good close to the surface and bad farther 'under' the floor.")]
			[Range(0f, 1f)]
			public float fresnelFade;

			// Token: 0x04005223 RID: 21027
			[Tooltip("Higher values correspond to a faster Fresnel fade as the reflection changes from the grazing angle.")]
			[Range(0.1f, 10f)]
			public float fresnelFadePower;
		}

		// Token: 0x020006D8 RID: 1752
		[Serializable]
		public struct ReflectionSettings
		{
			// Token: 0x04005224 RID: 21028
			[Tooltip("How the reflections are blended into the render.")]
			public ScreenSpaceReflectionModel.SSRReflectionBlendType blendType;

			// Token: 0x04005225 RID: 21029
			[Tooltip("Half resolution SSRR is much faster, but less accurate.")]
			public ScreenSpaceReflectionModel.SSRResolution reflectionQuality;

			// Token: 0x04005226 RID: 21030
			[Tooltip("Maximum reflection distance in world units.")]
			[Range(0.1f, 300f)]
			public float maxDistance;

			// Token: 0x04005227 RID: 21031
			[Tooltip("Max raytracing length.")]
			[Range(16f, 1024f)]
			public int iterationCount;

			// Token: 0x04005228 RID: 21032
			[Tooltip("Log base 2 of ray tracing coarse step size. Higher traces farther, lower gives better quality silhouettes.")]
			[Range(1f, 16f)]
			public int stepSize;

			// Token: 0x04005229 RID: 21033
			[Tooltip("Typical thickness of columns, walls, furniture, and other objects that reflection rays might pass behind.")]
			[Range(0.01f, 10f)]
			public float widthModifier;

			// Token: 0x0400522A RID: 21034
			[Tooltip("Blurriness of reflections.")]
			[Range(0.1f, 8f)]
			public float reflectionBlur;

			// Token: 0x0400522B RID: 21035
			[Tooltip("Disable for a performance gain in scenes where most glossy objects are horizontal, like floors, water, and tables. Leave on for scenes with glossy vertical objects.")]
			public bool reflectBackfaces;
		}

		// Token: 0x020006D9 RID: 1753
		[Serializable]
		public struct ScreenEdgeMask
		{
			// Token: 0x0400522C RID: 21036
			[Tooltip("Higher = fade out SSRR near the edge of the screen so that reflections don't pop under camera motion.")]
			[Range(0f, 1f)]
			public float intensity;
		}

		// Token: 0x020006DA RID: 1754
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A6 RID: 1446
			// (get) Token: 0x06002782 RID: 10114 RVA: 0x002074F0 File Offset: 0x002056F0
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

			// Token: 0x0400522D RID: 21037
			public ScreenSpaceReflectionModel.ReflectionSettings reflection;

			// Token: 0x0400522E RID: 21038
			public ScreenSpaceReflectionModel.IntensitySettings intensity;

			// Token: 0x0400522F RID: 21039
			public ScreenSpaceReflectionModel.ScreenEdgeMask screenEdgeMask;
		}
	}
}
