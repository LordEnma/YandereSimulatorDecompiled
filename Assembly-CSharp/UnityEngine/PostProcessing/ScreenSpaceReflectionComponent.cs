// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.ScreenSpaceReflectionComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
  public sealed class ScreenSpaceReflectionComponent : 
    PostProcessingComponentCommandBuffer<ScreenSpaceReflectionModel>
  {
    private bool k_HighlightSuppression;
    private bool k_TraceBehindObjects = true;
    private bool k_TreatBackfaceHitAsMiss;
    private bool k_BilateralUpsample = true;
    private readonly int[] m_ReflectionTextures = new int[5];

    public override DepthTextureMode GetCameraFlags() => DepthTextureMode.Depth;

    public override bool active => this.model.enabled && this.context.isGBufferAvailable && !this.context.interrupted;

    public override void OnEnable()
    {
      this.m_ReflectionTextures[0] = Shader.PropertyToID("_ReflectionTexture0");
      this.m_ReflectionTextures[1] = Shader.PropertyToID("_ReflectionTexture1");
      this.m_ReflectionTextures[2] = Shader.PropertyToID("_ReflectionTexture2");
      this.m_ReflectionTextures[3] = Shader.PropertyToID("_ReflectionTexture3");
      this.m_ReflectionTextures[4] = Shader.PropertyToID("_ReflectionTexture4");
    }

    public override string GetName() => "Screen Space Reflection";

    public override CameraEvent GetCameraEvent() => CameraEvent.AfterFinalPass;

    public override void PopulateCommandBuffer(CommandBuffer cb)
    {
      ScreenSpaceReflectionModel.Settings settings = this.model.settings;
      Camera camera = this.context.camera;
      int num1 = settings.reflection.reflectionQuality == ScreenSpaceReflectionModel.SSRResolution.High ? 1 : 2;
      int num2 = this.context.width / num1;
      int num3 = this.context.height / num1;
      float width = (float) this.context.width;
      float height = (float) this.context.height;
      float num4 = width / 2f;
      float num5 = height / 2f;
      Material mat = this.context.materialFactory.Get("Hidden/Post FX/Screen Space Reflection");
      mat.SetInt(ScreenSpaceReflectionComponent.Uniforms._RayStepSize, settings.reflection.stepSize);
      mat.SetInt(ScreenSpaceReflectionComponent.Uniforms._AdditiveReflection, settings.reflection.blendType == ScreenSpaceReflectionModel.SSRReflectionBlendType.Additive ? 1 : 0);
      mat.SetInt(ScreenSpaceReflectionComponent.Uniforms._BilateralUpsampling, this.k_BilateralUpsample ? 1 : 0);
      mat.SetInt(ScreenSpaceReflectionComponent.Uniforms._TreatBackfaceHitAsMiss, this.k_TreatBackfaceHitAsMiss ? 1 : 0);
      mat.SetInt(ScreenSpaceReflectionComponent.Uniforms._AllowBackwardsRays, settings.reflection.reflectBackfaces ? 1 : 0);
      mat.SetInt(ScreenSpaceReflectionComponent.Uniforms._TraceBehindObjects, this.k_TraceBehindObjects ? 1 : 0);
      mat.SetInt(ScreenSpaceReflectionComponent.Uniforms._MaxSteps, settings.reflection.iterationCount);
      mat.SetInt(ScreenSpaceReflectionComponent.Uniforms._FullResolutionFiltering, 0);
      mat.SetInt(ScreenSpaceReflectionComponent.Uniforms._HalfResolution, settings.reflection.reflectionQuality != ScreenSpaceReflectionModel.SSRResolution.High ? 1 : 0);
      mat.SetInt(ScreenSpaceReflectionComponent.Uniforms._HighlightSuppression, this.k_HighlightSuppression ? 1 : 0);
      float num6 = width / (-2f * Mathf.Tan((float) ((double) camera.fieldOfView / 180.0 * 3.14159274101257 * 0.5)));
      mat.SetFloat(ScreenSpaceReflectionComponent.Uniforms._PixelsPerMeterAtOneMeter, num6);
      mat.SetFloat(ScreenSpaceReflectionComponent.Uniforms._ScreenEdgeFading, settings.screenEdgeMask.intensity);
      mat.SetFloat(ScreenSpaceReflectionComponent.Uniforms._ReflectionBlur, settings.reflection.reflectionBlur);
      mat.SetFloat(ScreenSpaceReflectionComponent.Uniforms._MaxRayTraceDistance, settings.reflection.maxDistance);
      mat.SetFloat(ScreenSpaceReflectionComponent.Uniforms._FadeDistance, settings.intensity.fadeDistance);
      mat.SetFloat(ScreenSpaceReflectionComponent.Uniforms._LayerThickness, settings.reflection.widthModifier);
      mat.SetFloat(ScreenSpaceReflectionComponent.Uniforms._SSRMultiplier, settings.intensity.reflectionMultiplier);
      mat.SetFloat(ScreenSpaceReflectionComponent.Uniforms._FresnelFade, settings.intensity.fresnelFade);
      mat.SetFloat(ScreenSpaceReflectionComponent.Uniforms._FresnelFadePower, settings.intensity.fresnelFadePower);
      Matrix4x4 projectionMatrix = camera.projectionMatrix;
      Vector4 vector4 = new Vector4((float) (-2.0 / ((double) width * (double) projectionMatrix[0])), (float) (-2.0 / ((double) height * (double) projectionMatrix[5])), (1f - projectionMatrix[2]) / projectionMatrix[0], (1f + projectionMatrix[6]) / projectionMatrix[5]);
      Vector3 vector3 = float.IsPositiveInfinity(camera.farClipPlane) ? new Vector3(camera.nearClipPlane, -1f, 1f) : new Vector3(camera.nearClipPlane * camera.farClipPlane, camera.nearClipPlane - camera.farClipPlane, camera.farClipPlane);
      mat.SetVector(ScreenSpaceReflectionComponent.Uniforms._ReflectionBufferSize, (Vector4) new Vector2((float) num2, (float) num3));
      mat.SetVector(ScreenSpaceReflectionComponent.Uniforms._ScreenSize, (Vector4) new Vector2(width, height));
      mat.SetVector(ScreenSpaceReflectionComponent.Uniforms._InvScreenSize, (Vector4) new Vector2(1f / width, 1f / height));
      mat.SetVector(ScreenSpaceReflectionComponent.Uniforms._ProjInfo, vector4);
      mat.SetVector(ScreenSpaceReflectionComponent.Uniforms._CameraClipInfo, (Vector4) vector3);
      Matrix4x4 matrix4x4_1 = new Matrix4x4();
      matrix4x4_1.SetRow(0, new Vector4(num4, 0.0f, 0.0f, num4));
      matrix4x4_1.SetRow(1, new Vector4(0.0f, num5, 0.0f, num5));
      matrix4x4_1.SetRow(2, new Vector4(0.0f, 0.0f, 1f, 0.0f));
      matrix4x4_1.SetRow(3, new Vector4(0.0f, 0.0f, 0.0f, 1f));
      Matrix4x4 matrix4x4_2 = matrix4x4_1 * projectionMatrix;
      mat.SetMatrix(ScreenSpaceReflectionComponent.Uniforms._ProjectToPixelMatrix, matrix4x4_2);
      mat.SetMatrix(ScreenSpaceReflectionComponent.Uniforms._WorldToCameraMatrix, camera.worldToCameraMatrix);
      mat.SetMatrix(ScreenSpaceReflectionComponent.Uniforms._CameraToWorldMatrix, camera.worldToCameraMatrix.inverse);
      RenderTextureFormat format = this.context.isHdr ? RenderTextureFormat.ARGBHalf : RenderTextureFormat.ARGB32;
      int roughnessTexture = ScreenSpaceReflectionComponent.Uniforms._NormalAndRoughnessTexture;
      int hitPointTexture = ScreenSpaceReflectionComponent.Uniforms._HitPointTexture;
      int blurTexture = ScreenSpaceReflectionComponent.Uniforms._BlurTexture;
      int filteredReflections = ScreenSpaceReflectionComponent.Uniforms._FilteredReflections;
      int reflectionTexture1 = ScreenSpaceReflectionComponent.Uniforms._FinalReflectionTexture;
      int tempTexture = ScreenSpaceReflectionComponent.Uniforms._TempTexture;
      cb.GetTemporaryRT(roughnessTexture, -1, -1, 0, FilterMode.Point, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
      cb.GetTemporaryRT(hitPointTexture, num2, num3, 0, FilterMode.Bilinear, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear);
      for (int index = 0; index < 5; ++index)
        cb.GetTemporaryRT(this.m_ReflectionTextures[index], num2 >> index, num3 >> index, 0, FilterMode.Bilinear, format);
      cb.GetTemporaryRT(filteredReflections, num2, num3, 0, this.k_BilateralUpsample ? FilterMode.Point : FilterMode.Bilinear, format);
      cb.GetTemporaryRT(reflectionTexture1, num2, num3, 0, FilterMode.Point, format);
      cb.Blit((RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget, (RenderTargetIdentifier) roughnessTexture, mat, 6);
      cb.Blit((RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget, (RenderTargetIdentifier) hitPointTexture, mat, 0);
      cb.Blit((RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget, (RenderTargetIdentifier) filteredReflections, mat, 5);
      cb.Blit((RenderTargetIdentifier) filteredReflections, (RenderTargetIdentifier) this.m_ReflectionTextures[0], mat, 8);
      for (int index = 1; index < 5; ++index)
      {
        int reflectionTexture2 = this.m_ReflectionTextures[index - 1];
        int num7 = index;
        cb.GetTemporaryRT(blurTexture, num2 >> num7, num3 >> num7, 0, FilterMode.Bilinear, format);
        cb.SetGlobalVector(ScreenSpaceReflectionComponent.Uniforms._Axis, new Vector4(1f, 0.0f, 0.0f, 0.0f));
        cb.SetGlobalFloat(ScreenSpaceReflectionComponent.Uniforms._CurrentMipLevel, (float) index - 1f);
        cb.Blit((RenderTargetIdentifier) reflectionTexture2, (RenderTargetIdentifier) blurTexture, mat, 2);
        cb.SetGlobalVector(ScreenSpaceReflectionComponent.Uniforms._Axis, new Vector4(0.0f, 1f, 0.0f, 0.0f));
        int reflectionTexture3 = this.m_ReflectionTextures[index];
        cb.Blit((RenderTargetIdentifier) blurTexture, (RenderTargetIdentifier) reflectionTexture3, mat, 2);
        cb.ReleaseTemporaryRT(blurTexture);
      }
      cb.Blit((RenderTargetIdentifier) this.m_ReflectionTextures[0], (RenderTargetIdentifier) reflectionTexture1, mat, 3);
      cb.GetTemporaryRT(tempTexture, camera.pixelWidth, camera.pixelHeight, 0, FilterMode.Bilinear, format);
      cb.Blit((RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget, (RenderTargetIdentifier) tempTexture, mat, 1);
      cb.Blit((RenderTargetIdentifier) tempTexture, (RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget);
      cb.ReleaseTemporaryRT(tempTexture);
    }

    private static class Uniforms
    {
      internal static readonly int _RayStepSize = Shader.PropertyToID(nameof (_RayStepSize));
      internal static readonly int _AdditiveReflection = Shader.PropertyToID(nameof (_AdditiveReflection));
      internal static readonly int _BilateralUpsampling = Shader.PropertyToID(nameof (_BilateralUpsampling));
      internal static readonly int _TreatBackfaceHitAsMiss = Shader.PropertyToID(nameof (_TreatBackfaceHitAsMiss));
      internal static readonly int _AllowBackwardsRays = Shader.PropertyToID(nameof (_AllowBackwardsRays));
      internal static readonly int _TraceBehindObjects = Shader.PropertyToID(nameof (_TraceBehindObjects));
      internal static readonly int _MaxSteps = Shader.PropertyToID(nameof (_MaxSteps));
      internal static readonly int _FullResolutionFiltering = Shader.PropertyToID(nameof (_FullResolutionFiltering));
      internal static readonly int _HalfResolution = Shader.PropertyToID(nameof (_HalfResolution));
      internal static readonly int _HighlightSuppression = Shader.PropertyToID(nameof (_HighlightSuppression));
      internal static readonly int _PixelsPerMeterAtOneMeter = Shader.PropertyToID(nameof (_PixelsPerMeterAtOneMeter));
      internal static readonly int _ScreenEdgeFading = Shader.PropertyToID(nameof (_ScreenEdgeFading));
      internal static readonly int _ReflectionBlur = Shader.PropertyToID(nameof (_ReflectionBlur));
      internal static readonly int _MaxRayTraceDistance = Shader.PropertyToID(nameof (_MaxRayTraceDistance));
      internal static readonly int _FadeDistance = Shader.PropertyToID(nameof (_FadeDistance));
      internal static readonly int _LayerThickness = Shader.PropertyToID(nameof (_LayerThickness));
      internal static readonly int _SSRMultiplier = Shader.PropertyToID(nameof (_SSRMultiplier));
      internal static readonly int _FresnelFade = Shader.PropertyToID(nameof (_FresnelFade));
      internal static readonly int _FresnelFadePower = Shader.PropertyToID(nameof (_FresnelFadePower));
      internal static readonly int _ReflectionBufferSize = Shader.PropertyToID(nameof (_ReflectionBufferSize));
      internal static readonly int _ScreenSize = Shader.PropertyToID(nameof (_ScreenSize));
      internal static readonly int _InvScreenSize = Shader.PropertyToID(nameof (_InvScreenSize));
      internal static readonly int _ProjInfo = Shader.PropertyToID(nameof (_ProjInfo));
      internal static readonly int _CameraClipInfo = Shader.PropertyToID(nameof (_CameraClipInfo));
      internal static readonly int _ProjectToPixelMatrix = Shader.PropertyToID(nameof (_ProjectToPixelMatrix));
      internal static readonly int _WorldToCameraMatrix = Shader.PropertyToID(nameof (_WorldToCameraMatrix));
      internal static readonly int _CameraToWorldMatrix = Shader.PropertyToID(nameof (_CameraToWorldMatrix));
      internal static readonly int _Axis = Shader.PropertyToID(nameof (_Axis));
      internal static readonly int _CurrentMipLevel = Shader.PropertyToID(nameof (_CurrentMipLevel));
      internal static readonly int _NormalAndRoughnessTexture = Shader.PropertyToID(nameof (_NormalAndRoughnessTexture));
      internal static readonly int _HitPointTexture = Shader.PropertyToID(nameof (_HitPointTexture));
      internal static readonly int _BlurTexture = Shader.PropertyToID(nameof (_BlurTexture));
      internal static readonly int _FilteredReflections = Shader.PropertyToID(nameof (_FilteredReflections));
      internal static readonly int _FinalReflectionTexture = Shader.PropertyToID(nameof (_FinalReflectionTexture));
      internal static readonly int _TempTexture = Shader.PropertyToID(nameof (_TempTexture));
    }

    private enum PassIndex
    {
      RayTraceStep,
      CompositeFinal,
      Blur,
      CompositeSSR,
      MinMipGeneration,
      HitPointToReflections,
      BilateralKeyPack,
      BlitDepthAsCSZ,
      PoissonBlur,
    }
  }
}
