using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	public sealed class ScreenSpaceReflectionComponent : PostProcessingComponentCommandBuffer<ScreenSpaceReflectionModel>
	{
		private static class Uniforms
		{
			internal static readonly int _RayStepSize = Shader.PropertyToID("_RayStepSize");

			internal static readonly int _AdditiveReflection = Shader.PropertyToID("_AdditiveReflection");

			internal static readonly int _BilateralUpsampling = Shader.PropertyToID("_BilateralUpsampling");

			internal static readonly int _TreatBackfaceHitAsMiss = Shader.PropertyToID("_TreatBackfaceHitAsMiss");

			internal static readonly int _AllowBackwardsRays = Shader.PropertyToID("_AllowBackwardsRays");

			internal static readonly int _TraceBehindObjects = Shader.PropertyToID("_TraceBehindObjects");

			internal static readonly int _MaxSteps = Shader.PropertyToID("_MaxSteps");

			internal static readonly int _FullResolutionFiltering = Shader.PropertyToID("_FullResolutionFiltering");

			internal static readonly int _HalfResolution = Shader.PropertyToID("_HalfResolution");

			internal static readonly int _HighlightSuppression = Shader.PropertyToID("_HighlightSuppression");

			internal static readonly int _PixelsPerMeterAtOneMeter = Shader.PropertyToID("_PixelsPerMeterAtOneMeter");

			internal static readonly int _ScreenEdgeFading = Shader.PropertyToID("_ScreenEdgeFading");

			internal static readonly int _ReflectionBlur = Shader.PropertyToID("_ReflectionBlur");

			internal static readonly int _MaxRayTraceDistance = Shader.PropertyToID("_MaxRayTraceDistance");

			internal static readonly int _FadeDistance = Shader.PropertyToID("_FadeDistance");

			internal static readonly int _LayerThickness = Shader.PropertyToID("_LayerThickness");

			internal static readonly int _SSRMultiplier = Shader.PropertyToID("_SSRMultiplier");

			internal static readonly int _FresnelFade = Shader.PropertyToID("_FresnelFade");

			internal static readonly int _FresnelFadePower = Shader.PropertyToID("_FresnelFadePower");

			internal static readonly int _ReflectionBufferSize = Shader.PropertyToID("_ReflectionBufferSize");

			internal static readonly int _ScreenSize = Shader.PropertyToID("_ScreenSize");

			internal static readonly int _InvScreenSize = Shader.PropertyToID("_InvScreenSize");

			internal static readonly int _ProjInfo = Shader.PropertyToID("_ProjInfo");

			internal static readonly int _CameraClipInfo = Shader.PropertyToID("_CameraClipInfo");

			internal static readonly int _ProjectToPixelMatrix = Shader.PropertyToID("_ProjectToPixelMatrix");

			internal static readonly int _WorldToCameraMatrix = Shader.PropertyToID("_WorldToCameraMatrix");

			internal static readonly int _CameraToWorldMatrix = Shader.PropertyToID("_CameraToWorldMatrix");

			internal static readonly int _Axis = Shader.PropertyToID("_Axis");

			internal static readonly int _CurrentMipLevel = Shader.PropertyToID("_CurrentMipLevel");

			internal static readonly int _NormalAndRoughnessTexture = Shader.PropertyToID("_NormalAndRoughnessTexture");

			internal static readonly int _HitPointTexture = Shader.PropertyToID("_HitPointTexture");

			internal static readonly int _BlurTexture = Shader.PropertyToID("_BlurTexture");

			internal static readonly int _FilteredReflections = Shader.PropertyToID("_FilteredReflections");

			internal static readonly int _FinalReflectionTexture = Shader.PropertyToID("_FinalReflectionTexture");

			internal static readonly int _TempTexture = Shader.PropertyToID("_TempTexture");
		}

		private enum PassIndex
		{
			RayTraceStep = 0,
			CompositeFinal = 1,
			Blur = 2,
			CompositeSSR = 3,
			MinMipGeneration = 4,
			HitPointToReflections = 5,
			BilateralKeyPack = 6,
			BlitDepthAsCSZ = 7,
			PoissonBlur = 8
		}

		private bool k_HighlightSuppression;

		private bool k_TraceBehindObjects = true;

		private bool k_TreatBackfaceHitAsMiss;

		private bool k_BilateralUpsample = true;

		private readonly int[] m_ReflectionTextures = new int[5];

		public override bool active
		{
			get
			{
				if (base.model.enabled && context.isGBufferAvailable)
				{
					return !context.interrupted;
				}
				return false;
			}
		}

		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		public override void OnEnable()
		{
			m_ReflectionTextures[0] = Shader.PropertyToID("_ReflectionTexture0");
			m_ReflectionTextures[1] = Shader.PropertyToID("_ReflectionTexture1");
			m_ReflectionTextures[2] = Shader.PropertyToID("_ReflectionTexture2");
			m_ReflectionTextures[3] = Shader.PropertyToID("_ReflectionTexture3");
			m_ReflectionTextures[4] = Shader.PropertyToID("_ReflectionTexture4");
		}

		public override string GetName()
		{
			return "Screen Space Reflection";
		}

		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterFinalPass;
		}

		public override void PopulateCommandBuffer(CommandBuffer cb)
		{
			ScreenSpaceReflectionModel.Settings settings = base.model.settings;
			Camera camera = context.camera;
			int num = ((settings.reflection.reflectionQuality == ScreenSpaceReflectionModel.SSRResolution.High) ? 1 : 2);
			int num2 = context.width / num;
			int num3 = context.height / num;
			float num4 = context.width;
			float num5 = context.height;
			float num6 = num4 / 2f;
			float num7 = num5 / 2f;
			Material material = context.materialFactory.Get("Hidden/Post FX/Screen Space Reflection");
			material.SetInt(Uniforms._RayStepSize, settings.reflection.stepSize);
			material.SetInt(Uniforms._AdditiveReflection, (settings.reflection.blendType == ScreenSpaceReflectionModel.SSRReflectionBlendType.Additive) ? 1 : 0);
			material.SetInt(Uniforms._BilateralUpsampling, k_BilateralUpsample ? 1 : 0);
			material.SetInt(Uniforms._TreatBackfaceHitAsMiss, k_TreatBackfaceHitAsMiss ? 1 : 0);
			material.SetInt(Uniforms._AllowBackwardsRays, settings.reflection.reflectBackfaces ? 1 : 0);
			material.SetInt(Uniforms._TraceBehindObjects, k_TraceBehindObjects ? 1 : 0);
			material.SetInt(Uniforms._MaxSteps, settings.reflection.iterationCount);
			material.SetInt(Uniforms._FullResolutionFiltering, 0);
			material.SetInt(Uniforms._HalfResolution, (settings.reflection.reflectionQuality != ScreenSpaceReflectionModel.SSRResolution.High) ? 1 : 0);
			material.SetInt(Uniforms._HighlightSuppression, k_HighlightSuppression ? 1 : 0);
			float value = num4 / (-2f * Mathf.Tan(camera.fieldOfView / 180f * MathF.PI * 0.5f));
			material.SetFloat(Uniforms._PixelsPerMeterAtOneMeter, value);
			material.SetFloat(Uniforms._ScreenEdgeFading, settings.screenEdgeMask.intensity);
			material.SetFloat(Uniforms._ReflectionBlur, settings.reflection.reflectionBlur);
			material.SetFloat(Uniforms._MaxRayTraceDistance, settings.reflection.maxDistance);
			material.SetFloat(Uniforms._FadeDistance, settings.intensity.fadeDistance);
			material.SetFloat(Uniforms._LayerThickness, settings.reflection.widthModifier);
			material.SetFloat(Uniforms._SSRMultiplier, settings.intensity.reflectionMultiplier);
			material.SetFloat(Uniforms._FresnelFade, settings.intensity.fresnelFade);
			material.SetFloat(Uniforms._FresnelFadePower, settings.intensity.fresnelFadePower);
			Matrix4x4 projectionMatrix = camera.projectionMatrix;
			Vector4 value2 = new Vector4(-2f / (num4 * projectionMatrix[0]), -2f / (num5 * projectionMatrix[5]), (1f - projectionMatrix[2]) / projectionMatrix[0], (1f + projectionMatrix[6]) / projectionMatrix[5]);
			Vector3 vector = (float.IsPositiveInfinity(camera.farClipPlane) ? new Vector3(camera.nearClipPlane, -1f, 1f) : new Vector3(camera.nearClipPlane * camera.farClipPlane, camera.nearClipPlane - camera.farClipPlane, camera.farClipPlane));
			material.SetVector(Uniforms._ReflectionBufferSize, new Vector2(num2, num3));
			material.SetVector(Uniforms._ScreenSize, new Vector2(num4, num5));
			material.SetVector(Uniforms._InvScreenSize, new Vector2(1f / num4, 1f / num5));
			material.SetVector(Uniforms._ProjInfo, value2);
			material.SetVector(Uniforms._CameraClipInfo, vector);
			Matrix4x4 matrix4x = default(Matrix4x4);
			matrix4x.SetRow(0, new Vector4(num6, 0f, 0f, num6));
			matrix4x.SetRow(1, new Vector4(0f, num7, 0f, num7));
			matrix4x.SetRow(2, new Vector4(0f, 0f, 1f, 0f));
			matrix4x.SetRow(3, new Vector4(0f, 0f, 0f, 1f));
			Matrix4x4 value3 = matrix4x * projectionMatrix;
			material.SetMatrix(Uniforms._ProjectToPixelMatrix, value3);
			material.SetMatrix(Uniforms._WorldToCameraMatrix, camera.worldToCameraMatrix);
			material.SetMatrix(Uniforms._CameraToWorldMatrix, camera.worldToCameraMatrix.inverse);
			RenderTextureFormat format = (context.isHdr ? RenderTextureFormat.ARGBHalf : RenderTextureFormat.ARGB32);
			int normalAndRoughnessTexture = Uniforms._NormalAndRoughnessTexture;
			int hitPointTexture = Uniforms._HitPointTexture;
			int blurTexture = Uniforms._BlurTexture;
			int filteredReflections = Uniforms._FilteredReflections;
			int finalReflectionTexture = Uniforms._FinalReflectionTexture;
			int tempTexture = Uniforms._TempTexture;
			cb.GetTemporaryRT(normalAndRoughnessTexture, -1, -1, 0, FilterMode.Point, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
			cb.GetTemporaryRT(hitPointTexture, num2, num3, 0, FilterMode.Bilinear, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear);
			for (int i = 0; i < 5; i++)
			{
				cb.GetTemporaryRT(m_ReflectionTextures[i], num2 >> i, num3 >> i, 0, FilterMode.Bilinear, format);
			}
			cb.GetTemporaryRT(filteredReflections, num2, num3, 0, (!k_BilateralUpsample) ? FilterMode.Bilinear : FilterMode.Point, format);
			cb.GetTemporaryRT(finalReflectionTexture, num2, num3, 0, FilterMode.Point, format);
			cb.Blit(BuiltinRenderTextureType.CameraTarget, normalAndRoughnessTexture, material, 6);
			cb.Blit(BuiltinRenderTextureType.CameraTarget, hitPointTexture, material, 0);
			cb.Blit(BuiltinRenderTextureType.CameraTarget, filteredReflections, material, 5);
			cb.Blit(filteredReflections, m_ReflectionTextures[0], material, 8);
			for (int j = 1; j < 5; j++)
			{
				int num8 = m_ReflectionTextures[j - 1];
				int num9 = j;
				cb.GetTemporaryRT(blurTexture, num2 >> num9, num3 >> num9, 0, FilterMode.Bilinear, format);
				cb.SetGlobalVector(Uniforms._Axis, new Vector4(1f, 0f, 0f, 0f));
				cb.SetGlobalFloat(Uniforms._CurrentMipLevel, (float)j - 1f);
				cb.Blit(num8, blurTexture, material, 2);
				cb.SetGlobalVector(Uniforms._Axis, new Vector4(0f, 1f, 0f, 0f));
				num8 = m_ReflectionTextures[j];
				cb.Blit(blurTexture, num8, material, 2);
				cb.ReleaseTemporaryRT(blurTexture);
			}
			cb.Blit(m_ReflectionTextures[0], finalReflectionTexture, material, 3);
			cb.GetTemporaryRT(tempTexture, camera.pixelWidth, camera.pixelHeight, 0, FilterMode.Bilinear, format);
			cb.Blit(BuiltinRenderTextureType.CameraTarget, tempTexture, material, 1);
			cb.Blit(tempTexture, BuiltinRenderTextureType.CameraTarget);
			cb.ReleaseTemporaryRT(tempTexture);
		}
	}
}
