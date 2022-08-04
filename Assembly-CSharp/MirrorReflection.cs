// Decompiled with JetBrains decompiler
// Type: MirrorReflection
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class MirrorReflection : MonoBehaviour
{
  public bool m_DisablePixelLights = true;
  public int m_TextureSize = 256;
  public float m_ClipPlaneOffset = 0.07f;
  public LayerMask m_ReflectLayers = (LayerMask) -1;
  private Hashtable m_ReflectionCameras = new Hashtable();
  private RenderTexture m_ReflectionTexture;
  private int m_OldReflectionTextureSize;
  private static bool s_InsideRendering;

  public void OnWillRenderObject()
  {
    Renderer component = this.GetComponent<Renderer>();
    if (!this.enabled || !(bool) (UnityEngine.Object) component || !(bool) (UnityEngine.Object) component.sharedMaterial || !component.enabled)
      return;
    Camera current = Camera.current;
    if (!(bool) (UnityEngine.Object) current || MirrorReflection.s_InsideRendering)
      return;
    MirrorReflection.s_InsideRendering = true;
    Camera reflectionCamera;
    this.CreateMirrorObjects(current, out reflectionCamera);
    Vector3 position1 = this.transform.position;
    Vector3 up = this.transform.up;
    int pixelLightCount = QualitySettings.pixelLightCount;
    if (this.m_DisablePixelLights)
      QualitySettings.pixelLightCount = 0;
    this.UpdateCameraModes(current, reflectionCamera);
    float w = -Vector3.Dot(up, position1) - this.m_ClipPlaneOffset;
    Vector4 plane = new Vector4(up.x, up.y, up.z, w);
    Matrix4x4 zero = Matrix4x4.zero;
    MirrorReflection.CalculateReflectionMatrix(ref zero, plane);
    Vector3 position2 = current.transform.position;
    Vector3 vector3 = zero.MultiplyPoint(position2);
    reflectionCamera.worldToCameraMatrix = current.worldToCameraMatrix * zero;
    Vector4 clipPlane = this.CameraSpacePlane(reflectionCamera, position1, up, 1f);
    Matrix4x4 obliqueMatrix = current.CalculateObliqueMatrix(clipPlane);
    reflectionCamera.projectionMatrix = obliqueMatrix;
    reflectionCamera.cullingMask = -17 & this.m_ReflectLayers.value;
    reflectionCamera.targetTexture = this.m_ReflectionTexture;
    GL.invertCulling = true;
    reflectionCamera.transform.position = vector3;
    Vector3 eulerAngles = current.transform.eulerAngles;
    reflectionCamera.transform.eulerAngles = new Vector3(0.0f, eulerAngles.y, eulerAngles.z);
    reflectionCamera.Render();
    reflectionCamera.transform.position = position2;
    GL.invertCulling = false;
    foreach (Material sharedMaterial in component.sharedMaterials)
    {
      if (sharedMaterial.HasProperty("_ReflectionTex"))
        sharedMaterial.SetTexture("_ReflectionTex", (Texture) this.m_ReflectionTexture);
    }
    if (this.m_DisablePixelLights)
      QualitySettings.pixelLightCount = pixelLightCount;
    MirrorReflection.s_InsideRendering = false;
  }

  private void OnDisable()
  {
    if ((bool) (UnityEngine.Object) this.m_ReflectionTexture)
    {
      UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.m_ReflectionTexture);
      this.m_ReflectionTexture = (RenderTexture) null;
    }
    foreach (DictionaryEntry reflectionCamera in this.m_ReflectionCameras)
      UnityEngine.Object.DestroyImmediate((UnityEngine.Object) ((Component) reflectionCamera.Value).gameObject);
    this.m_ReflectionCameras.Clear();
  }

  private void UpdateCameraModes(Camera src, Camera dest)
  {
    if ((UnityEngine.Object) dest == (UnityEngine.Object) null)
      return;
    dest.clearFlags = src.clearFlags;
    dest.backgroundColor = src.backgroundColor;
    if (src.clearFlags == CameraClearFlags.Skybox)
    {
      Skybox component1 = src.GetComponent(typeof (Skybox)) as Skybox;
      Skybox component2 = dest.GetComponent(typeof (Skybox)) as Skybox;
      if (!(bool) (UnityEngine.Object) component1 || !(bool) (UnityEngine.Object) component1.material)
      {
        component2.enabled = false;
      }
      else
      {
        component2.enabled = true;
        component2.material = component1.material;
      }
    }
    dest.farClipPlane = src.farClipPlane;
    dest.nearClipPlane = src.nearClipPlane;
    dest.orthographic = src.orthographic;
    dest.fieldOfView = src.fieldOfView;
    dest.aspect = src.aspect;
    dest.orthographicSize = src.orthographicSize;
  }

  private void CreateMirrorObjects(Camera currentCamera, out Camera reflectionCamera)
  {
    reflectionCamera = (Camera) null;
    if (!(bool) (UnityEngine.Object) this.m_ReflectionTexture || this.m_OldReflectionTextureSize != this.m_TextureSize)
    {
      if ((bool) (UnityEngine.Object) this.m_ReflectionTexture)
        UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.m_ReflectionTexture);
      this.m_ReflectionTexture = new RenderTexture(this.m_TextureSize, this.m_TextureSize, 16);
      this.m_ReflectionTexture.name = "__MirrorReflection" + this.GetInstanceID().ToString();
      this.m_ReflectionTexture.isPowerOfTwo = true;
      this.m_ReflectionTexture.hideFlags = HideFlags.DontSave;
      this.m_OldReflectionTextureSize = this.m_TextureSize;
    }
    reflectionCamera = this.m_ReflectionCameras[(object) currentCamera] as Camera;
    if ((bool) (UnityEngine.Object) reflectionCamera)
      return;
    GameObject gameObject = new GameObject("Mirror Refl Camera id" + this.GetInstanceID().ToString() + " for " + currentCamera.GetInstanceID().ToString(), new System.Type[2]
    {
      typeof (Camera),
      typeof (Skybox)
    });
    reflectionCamera = gameObject.GetComponent<Camera>();
    reflectionCamera.enabled = false;
    reflectionCamera.transform.position = this.transform.position;
    reflectionCamera.transform.rotation = this.transform.rotation;
    reflectionCamera.gameObject.AddComponent<FlareLayer>();
    gameObject.hideFlags = HideFlags.HideAndDontSave;
    this.m_ReflectionCameras[(object) currentCamera] = (object) reflectionCamera;
  }

  private static float sgn(float a)
  {
    if ((double) a > 0.0)
      return 1f;
    return (double) a < 0.0 ? -1f : 0.0f;
  }

  private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
  {
    Vector3 point = pos + normal * this.m_ClipPlaneOffset;
    Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
    Vector3 lhs = worldToCameraMatrix.MultiplyPoint(point);
    Vector3 rhs = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
    return new Vector4(rhs.x, rhs.y, rhs.z, -Vector3.Dot(lhs, rhs));
  }

  private static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
  {
    reflectionMat.m00 = (float) (1.0 - 2.0 * (double) plane[0] * (double) plane[0]);
    reflectionMat.m01 = -2f * plane[0] * plane[1];
    reflectionMat.m02 = -2f * plane[0] * plane[2];
    reflectionMat.m03 = -2f * plane[3] * plane[0];
    reflectionMat.m10 = -2f * plane[1] * plane[0];
    reflectionMat.m11 = (float) (1.0 - 2.0 * (double) plane[1] * (double) plane[1]);
    reflectionMat.m12 = -2f * plane[1] * plane[2];
    reflectionMat.m13 = -2f * plane[3] * plane[1];
    reflectionMat.m20 = -2f * plane[2] * plane[0];
    reflectionMat.m21 = -2f * plane[2] * plane[1];
    reflectionMat.m22 = (float) (1.0 - 2.0 * (double) plane[2] * (double) plane[2]);
    reflectionMat.m23 = -2f * plane[3] * plane[2];
    reflectionMat.m30 = 0.0f;
    reflectionMat.m31 = 0.0f;
    reflectionMat.m32 = 0.0f;
    reflectionMat.m33 = 1f;
  }
}
