using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000558 RID: 1368
	public sealed class ScreenSpaceReflectionComponent : PostProcessingComponentCommandBuffer<ScreenSpaceReflectionModel>
	{
		// Token: 0x060022D9 RID: 8921 RVA: 0x001EE3A7 File Offset: 0x001EC5A7
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x060022DA RID: 8922 RVA: 0x001EE3AA File Offset: 0x001EC5AA
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && !this.context.interrupted;
			}
		}

		// Token: 0x060022DB RID: 8923 RVA: 0x001EE3D8 File Offset: 0x001EC5D8
		public override void OnEnable()
		{
			this.m_ReflectionTextures[0] = Shader.PropertyToID("_ReflectionTexture0");
			this.m_ReflectionTextures[1] = Shader.PropertyToID("_ReflectionTexture1");
			this.m_ReflectionTextures[2] = Shader.PropertyToID("_ReflectionTexture2");
			this.m_ReflectionTextures[3] = Shader.PropertyToID("_ReflectionTexture3");
			this.m_ReflectionTextures[4] = Shader.PropertyToID("_ReflectionTexture4");
		}

		// Token: 0x060022DC RID: 8924 RVA: 0x001EE43F File Offset: 0x001EC63F
		public override string GetName()
		{
			return "Screen Space Reflection";
		}

		// Token: 0x060022DD RID: 8925 RVA: 0x001EE446 File Offset: 0x001EC646
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterFinalPass;
		}

		// Token: 0x060022DE RID: 8926 RVA: 0x001EE44C File Offset: 0x001EC64C
		public override void PopulateCommandBuffer(CommandBuffer cb)
		{
			ScreenSpaceReflectionModel.Settings settings = base.model.settings;
			Camera camera = this.context.camera;
			int num = (settings.reflection.reflectionQuality == ScreenSpaceReflectionModel.SSRResolution.High) ? 1 : 2;
			int num2 = this.context.width / num;
			int num3 = this.context.height / num;
			float num4 = (float)this.context.width;
			float num5 = (float)this.context.height;
			float num6 = num4 / 2f;
			float num7 = num5 / 2f;
			Material material = this.context.materialFactory.Get("Hidden/Post FX/Screen Space Reflection");
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._RayStepSize, settings.reflection.stepSize);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._AdditiveReflection, (settings.reflection.blendType == ScreenSpaceReflectionModel.SSRReflectionBlendType.Additive) ? 1 : 0);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._BilateralUpsampling, this.k_BilateralUpsample ? 1 : 0);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._TreatBackfaceHitAsMiss, this.k_TreatBackfaceHitAsMiss ? 1 : 0);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._AllowBackwardsRays, settings.reflection.reflectBackfaces ? 1 : 0);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._TraceBehindObjects, this.k_TraceBehindObjects ? 1 : 0);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._MaxSteps, settings.reflection.iterationCount);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._FullResolutionFiltering, 0);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._HalfResolution, (settings.reflection.reflectionQuality != ScreenSpaceReflectionModel.SSRResolution.High) ? 1 : 0);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._HighlightSuppression, this.k_HighlightSuppression ? 1 : 0);
			float value = num4 / (-2f * Mathf.Tan(camera.fieldOfView / 180f * 3.1415927f * 0.5f));
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._PixelsPerMeterAtOneMeter, value);
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._ScreenEdgeFading, settings.screenEdgeMask.intensity);
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._ReflectionBlur, settings.reflection.reflectionBlur);
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._MaxRayTraceDistance, settings.reflection.maxDistance);
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._FadeDistance, settings.intensity.fadeDistance);
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._LayerThickness, settings.reflection.widthModifier);
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._SSRMultiplier, settings.intensity.reflectionMultiplier);
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._FresnelFade, settings.intensity.fresnelFade);
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._FresnelFadePower, settings.intensity.fresnelFadePower);
			Matrix4x4 projectionMatrix = camera.projectionMatrix;
			Vector4 value2 = new Vector4(-2f / (num4 * projectionMatrix[0]), -2f / (num5 * projectionMatrix[5]), (1f - projectionMatrix[2]) / projectionMatrix[0], (1f + projectionMatrix[6]) / projectionMatrix[5]);
			Vector3 v = float.IsPositiveInfinity(camera.farClipPlane) ? new Vector3(camera.nearClipPlane, -1f, 1f) : new Vector3(camera.nearClipPlane * camera.farClipPlane, camera.nearClipPlane - camera.farClipPlane, camera.farClipPlane);
			material.SetVector(ScreenSpaceReflectionComponent.Uniforms._ReflectionBufferSize, new Vector2((float)num2, (float)num3));
			material.SetVector(ScreenSpaceReflectionComponent.Uniforms._ScreenSize, new Vector2(num4, num5));
			material.SetVector(ScreenSpaceReflectionComponent.Uniforms._InvScreenSize, new Vector2(1f / num4, 1f / num5));
			material.SetVector(ScreenSpaceReflectionComponent.Uniforms._ProjInfo, value2);
			material.SetVector(ScreenSpaceReflectionComponent.Uniforms._CameraClipInfo, v);
			Matrix4x4 lhs = default(Matrix4x4);
			lhs.SetRow(0, new Vector4(num6, 0f, 0f, num6));
			lhs.SetRow(1, new Vector4(0f, num7, 0f, num7));
			lhs.SetRow(2, new Vector4(0f, 0f, 1f, 0f));
			lhs.SetRow(3, new Vector4(0f, 0f, 0f, 1f));
			Matrix4x4 value3 = lhs * projectionMatrix;
			material.SetMatrix(ScreenSpaceReflectionComponent.Uniforms._ProjectToPixelMatrix, value3);
			material.SetMatrix(ScreenSpaceReflectionComponent.Uniforms._WorldToCameraMatrix, camera.worldToCameraMatrix);
			material.SetMatrix(ScreenSpaceReflectionComponent.Uniforms._CameraToWorldMatrix, camera.worldToCameraMatrix.inverse);
			RenderTextureFormat format = this.context.isHdr ? RenderTextureFormat.ARGBHalf : RenderTextureFormat.ARGB32;
			int normalAndRoughnessTexture = ScreenSpaceReflectionComponent.Uniforms._NormalAndRoughnessTexture;
			int hitPointTexture = ScreenSpaceReflectionComponent.Uniforms._HitPointTexture;
			int blurTexture = ScreenSpaceReflectionComponent.Uniforms._BlurTexture;
			int filteredReflections = ScreenSpaceReflectionComponent.Uniforms._FilteredReflections;
			int finalReflectionTexture = ScreenSpaceReflectionComponent.Uniforms._FinalReflectionTexture;
			int tempTexture = ScreenSpaceReflectionComponent.Uniforms._TempTexture;
			cb.GetTemporaryRT(normalAndRoughnessTexture, -1, -1, 0, FilterMode.Point, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
			cb.GetTemporaryRT(hitPointTexture, num2, num3, 0, FilterMode.Bilinear, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear);
			for (int i = 0; i < 5; i++)
			{
				cb.GetTemporaryRT(this.m_ReflectionTextures[i], num2 >> i, num3 >> i, 0, FilterMode.Bilinear, format);
			}
			cb.GetTemporaryRT(filteredReflections, num2, num3, 0, this.k_BilateralUpsample ? FilterMode.Point : FilterMode.Bilinear, format);
			cb.GetTemporaryRT(finalReflectionTexture, num2, num3, 0, FilterMode.Point, format);
			cb.Blit(BuiltinRenderTextureType.CameraTarget, normalAndRoughnessTexture, material, 6);
			cb.Blit(BuiltinRenderTextureType.CameraTarget, hitPointTexture, material, 0);
			cb.Blit(BuiltinRenderTextureType.CameraTarget, filteredReflections, material, 5);
			cb.Blit(filteredReflections, this.m_ReflectionTextures[0], material, 8);
			for (int j = 1; j < 5; j++)
			{
				int nameID = this.m_ReflectionTextures[j - 1];
				int num8 = j;
				cb.GetTemporaryRT(blurTexture, num2 >> num8, num3 >> num8, 0, FilterMode.Bilinear, format);
				cb.SetGlobalVector(ScreenSpaceReflectionComponent.Uniforms._Axis, new Vector4(1f, 0f, 0f, 0f));
				cb.SetGlobalFloat(ScreenSpaceReflectionComponent.Uniforms._CurrentMipLevel, (float)j - 1f);
				cb.Blit(nameID, blurTexture, material, 2);
				cb.SetGlobalVector(ScreenSpaceReflectionComponent.Uniforms._Axis, new Vector4(0f, 1f, 0f, 0f));
				nameID = this.m_ReflectionTextures[j];
				cb.Blit(blurTexture, nameID, material, 2);
				cb.ReleaseTemporaryRT(blurTexture);
			}
			cb.Blit(this.m_ReflectionTextures[0], finalReflectionTexture, material, 3);
			cb.GetTemporaryRT(tempTexture, camera.pixelWidth, camera.pixelHeight, 0, FilterMode.Bilinear, format);
			cb.Blit(BuiltinRenderTextureType.CameraTarget, tempTexture, material, 1);
			cb.Blit(tempTexture, BuiltinRenderTextureType.CameraTarget);
			cb.ReleaseTemporaryRT(tempTexture);
		}

		// Token: 0x04004A6C RID: 19052
		private bool k_HighlightSuppression;

		// Token: 0x04004A6D RID: 19053
		private bool k_TraceBehindObjects = true;

		// Token: 0x04004A6E RID: 19054
		private bool k_TreatBackfaceHitAsMiss;

		// Token: 0x04004A6F RID: 19055
		private bool k_BilateralUpsample = true;

		// Token: 0x04004A70 RID: 19056
		private readonly int[] m_ReflectionTextures = new int[5];

		// Token: 0x0200069F RID: 1695
		private static class Uniforms
		{
			// Token: 0x04005027 RID: 20519
			internal static readonly int _RayStepSize = Shader.PropertyToID("_RayStepSize");

			// Token: 0x04005028 RID: 20520
			internal static readonly int _AdditiveReflection = Shader.PropertyToID("_AdditiveReflection");

			// Token: 0x04005029 RID: 20521
			internal static readonly int _BilateralUpsampling = Shader.PropertyToID("_BilateralUpsampling");

			// Token: 0x0400502A RID: 20522
			internal static readonly int _TreatBackfaceHitAsMiss = Shader.PropertyToID("_TreatBackfaceHitAsMiss");

			// Token: 0x0400502B RID: 20523
			internal static readonly int _AllowBackwardsRays = Shader.PropertyToID("_AllowBackwardsRays");

			// Token: 0x0400502C RID: 20524
			internal static readonly int _TraceBehindObjects = Shader.PropertyToID("_TraceBehindObjects");

			// Token: 0x0400502D RID: 20525
			internal static readonly int _MaxSteps = Shader.PropertyToID("_MaxSteps");

			// Token: 0x0400502E RID: 20526
			internal static readonly int _FullResolutionFiltering = Shader.PropertyToID("_FullResolutionFiltering");

			// Token: 0x0400502F RID: 20527
			internal static readonly int _HalfResolution = Shader.PropertyToID("_HalfResolution");

			// Token: 0x04005030 RID: 20528
			internal static readonly int _HighlightSuppression = Shader.PropertyToID("_HighlightSuppression");

			// Token: 0x04005031 RID: 20529
			internal static readonly int _PixelsPerMeterAtOneMeter = Shader.PropertyToID("_PixelsPerMeterAtOneMeter");

			// Token: 0x04005032 RID: 20530
			internal static readonly int _ScreenEdgeFading = Shader.PropertyToID("_ScreenEdgeFading");

			// Token: 0x04005033 RID: 20531
			internal static readonly int _ReflectionBlur = Shader.PropertyToID("_ReflectionBlur");

			// Token: 0x04005034 RID: 20532
			internal static readonly int _MaxRayTraceDistance = Shader.PropertyToID("_MaxRayTraceDistance");

			// Token: 0x04005035 RID: 20533
			internal static readonly int _FadeDistance = Shader.PropertyToID("_FadeDistance");

			// Token: 0x04005036 RID: 20534
			internal static readonly int _LayerThickness = Shader.PropertyToID("_LayerThickness");

			// Token: 0x04005037 RID: 20535
			internal static readonly int _SSRMultiplier = Shader.PropertyToID("_SSRMultiplier");

			// Token: 0x04005038 RID: 20536
			internal static readonly int _FresnelFade = Shader.PropertyToID("_FresnelFade");

			// Token: 0x04005039 RID: 20537
			internal static readonly int _FresnelFadePower = Shader.PropertyToID("_FresnelFadePower");

			// Token: 0x0400503A RID: 20538
			internal static readonly int _ReflectionBufferSize = Shader.PropertyToID("_ReflectionBufferSize");

			// Token: 0x0400503B RID: 20539
			internal static readonly int _ScreenSize = Shader.PropertyToID("_ScreenSize");

			// Token: 0x0400503C RID: 20540
			internal static readonly int _InvScreenSize = Shader.PropertyToID("_InvScreenSize");

			// Token: 0x0400503D RID: 20541
			internal static readonly int _ProjInfo = Shader.PropertyToID("_ProjInfo");

			// Token: 0x0400503E RID: 20542
			internal static readonly int _CameraClipInfo = Shader.PropertyToID("_CameraClipInfo");

			// Token: 0x0400503F RID: 20543
			internal static readonly int _ProjectToPixelMatrix = Shader.PropertyToID("_ProjectToPixelMatrix");

			// Token: 0x04005040 RID: 20544
			internal static readonly int _WorldToCameraMatrix = Shader.PropertyToID("_WorldToCameraMatrix");

			// Token: 0x04005041 RID: 20545
			internal static readonly int _CameraToWorldMatrix = Shader.PropertyToID("_CameraToWorldMatrix");

			// Token: 0x04005042 RID: 20546
			internal static readonly int _Axis = Shader.PropertyToID("_Axis");

			// Token: 0x04005043 RID: 20547
			internal static readonly int _CurrentMipLevel = Shader.PropertyToID("_CurrentMipLevel");

			// Token: 0x04005044 RID: 20548
			internal static readonly int _NormalAndRoughnessTexture = Shader.PropertyToID("_NormalAndRoughnessTexture");

			// Token: 0x04005045 RID: 20549
			internal static readonly int _HitPointTexture = Shader.PropertyToID("_HitPointTexture");

			// Token: 0x04005046 RID: 20550
			internal static readonly int _BlurTexture = Shader.PropertyToID("_BlurTexture");

			// Token: 0x04005047 RID: 20551
			internal static readonly int _FilteredReflections = Shader.PropertyToID("_FilteredReflections");

			// Token: 0x04005048 RID: 20552
			internal static readonly int _FinalReflectionTexture = Shader.PropertyToID("_FinalReflectionTexture");

			// Token: 0x04005049 RID: 20553
			internal static readonly int _TempTexture = Shader.PropertyToID("_TempTexture");
		}

		// Token: 0x020006A0 RID: 1696
		private enum PassIndex
		{
			// Token: 0x0400504B RID: 20555
			RayTraceStep,
			// Token: 0x0400504C RID: 20556
			CompositeFinal,
			// Token: 0x0400504D RID: 20557
			Blur,
			// Token: 0x0400504E RID: 20558
			CompositeSSR,
			// Token: 0x0400504F RID: 20559
			MinMipGeneration,
			// Token: 0x04005050 RID: 20560
			HitPointToReflections,
			// Token: 0x04005051 RID: 20561
			BilateralKeyPack,
			// Token: 0x04005052 RID: 20562
			BlitDepthAsCSZ,
			// Token: 0x04005053 RID: 20563
			PoissonBlur
		}
	}
}
