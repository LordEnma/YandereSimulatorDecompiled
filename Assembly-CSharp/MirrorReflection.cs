using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000365 RID: 869
[ExecuteInEditMode]
public class MirrorReflection : MonoBehaviour
{
	// Token: 0x06001994 RID: 6548 RVA: 0x001050E0 File Offset: 0x001032E0
	public void OnWillRenderObject()
	{
		Renderer component = base.GetComponent<Renderer>();
		if (!base.enabled || !component || !component.sharedMaterial || !component.enabled)
		{
			return;
		}
		Camera current = Camera.current;
		if (!current)
		{
			return;
		}
		if (MirrorReflection.s_InsideRendering)
		{
			return;
		}
		MirrorReflection.s_InsideRendering = true;
		Camera camera;
		this.CreateMirrorObjects(current, out camera);
		Vector3 position = base.transform.position;
		Vector3 up = base.transform.up;
		int pixelLightCount = QualitySettings.pixelLightCount;
		if (this.m_DisablePixelLights)
		{
			QualitySettings.pixelLightCount = 0;
		}
		this.UpdateCameraModes(current, camera);
		float w = -Vector3.Dot(up, position) - this.m_ClipPlaneOffset;
		Vector4 plane = new Vector4(up.x, up.y, up.z, w);
		Matrix4x4 zero = Matrix4x4.zero;
		MirrorReflection.CalculateReflectionMatrix(ref zero, plane);
		Vector3 position2 = current.transform.position;
		Vector3 position3 = zero.MultiplyPoint(position2);
		camera.worldToCameraMatrix = current.worldToCameraMatrix * zero;
		Vector4 clipPlane = this.CameraSpacePlane(camera, position, up, 1f);
		Matrix4x4 projectionMatrix = current.CalculateObliqueMatrix(clipPlane);
		camera.projectionMatrix = projectionMatrix;
		camera.cullingMask = (-17 & this.m_ReflectLayers.value);
		camera.targetTexture = this.m_ReflectionTexture;
		GL.invertCulling = true;
		camera.transform.position = position3;
		Vector3 eulerAngles = current.transform.eulerAngles;
		camera.transform.eulerAngles = new Vector3(0f, eulerAngles.y, eulerAngles.z);
		camera.Render();
		camera.transform.position = position2;
		GL.invertCulling = false;
		foreach (Material material in component.sharedMaterials)
		{
			if (material.HasProperty("_ReflectionTex"))
			{
				material.SetTexture("_ReflectionTex", this.m_ReflectionTexture);
			}
		}
		if (this.m_DisablePixelLights)
		{
			QualitySettings.pixelLightCount = pixelLightCount;
		}
		MirrorReflection.s_InsideRendering = false;
	}

	// Token: 0x06001995 RID: 6549 RVA: 0x001052D8 File Offset: 0x001034D8
	private void OnDisable()
	{
		if (this.m_ReflectionTexture)
		{
			UnityEngine.Object.DestroyImmediate(this.m_ReflectionTexture);
			this.m_ReflectionTexture = null;
		}
		foreach (object obj in this.m_ReflectionCameras)
		{
			UnityEngine.Object.DestroyImmediate(((Camera)((DictionaryEntry)obj).Value).gameObject);
		}
		this.m_ReflectionCameras.Clear();
	}

	// Token: 0x06001996 RID: 6550 RVA: 0x0010536C File Offset: 0x0010356C
	private void UpdateCameraModes(Camera src, Camera dest)
	{
		if (dest == null)
		{
			return;
		}
		dest.clearFlags = src.clearFlags;
		dest.backgroundColor = src.backgroundColor;
		if (src.clearFlags == CameraClearFlags.Skybox)
		{
			Skybox skybox = src.GetComponent(typeof(Skybox)) as Skybox;
			Skybox skybox2 = dest.GetComponent(typeof(Skybox)) as Skybox;
			if (!skybox || !skybox.material)
			{
				skybox2.enabled = false;
			}
			else
			{
				skybox2.enabled = true;
				skybox2.material = skybox.material;
			}
		}
		dest.farClipPlane = src.farClipPlane;
		dest.nearClipPlane = src.nearClipPlane;
		dest.orthographic = src.orthographic;
		dest.fieldOfView = src.fieldOfView;
		dest.aspect = src.aspect;
		dest.orthographicSize = src.orthographicSize;
	}

	// Token: 0x06001997 RID: 6551 RVA: 0x0010544C File Offset: 0x0010364C
	private void CreateMirrorObjects(Camera currentCamera, out Camera reflectionCamera)
	{
		reflectionCamera = null;
		if (!this.m_ReflectionTexture || this.m_OldReflectionTextureSize != this.m_TextureSize)
		{
			if (this.m_ReflectionTexture)
			{
				UnityEngine.Object.DestroyImmediate(this.m_ReflectionTexture);
			}
			this.m_ReflectionTexture = new RenderTexture(this.m_TextureSize, this.m_TextureSize, 16);
			this.m_ReflectionTexture.name = "__MirrorReflection" + base.GetInstanceID().ToString();
			this.m_ReflectionTexture.isPowerOfTwo = true;
			this.m_ReflectionTexture.hideFlags = HideFlags.DontSave;
			this.m_OldReflectionTextureSize = this.m_TextureSize;
		}
		reflectionCamera = (this.m_ReflectionCameras[currentCamera] as Camera);
		if (!reflectionCamera)
		{
			GameObject gameObject = new GameObject("Mirror Refl Camera id" + base.GetInstanceID().ToString() + " for " + currentCamera.GetInstanceID().ToString(), new Type[]
			{
				typeof(Camera),
				typeof(Skybox)
			});
			reflectionCamera = gameObject.GetComponent<Camera>();
			reflectionCamera.enabled = false;
			reflectionCamera.transform.position = base.transform.position;
			reflectionCamera.transform.rotation = base.transform.rotation;
			reflectionCamera.gameObject.AddComponent<FlareLayer>();
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			this.m_ReflectionCameras[currentCamera] = reflectionCamera;
		}
	}

	// Token: 0x06001998 RID: 6552 RVA: 0x001055C1 File Offset: 0x001037C1
	private static float sgn(float a)
	{
		if (a > 0f)
		{
			return 1f;
		}
		if (a < 0f)
		{
			return -1f;
		}
		return 0f;
	}

	// Token: 0x06001999 RID: 6553 RVA: 0x001055E4 File Offset: 0x001037E4
	private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
	{
		Vector3 point = pos + normal * this.m_ClipPlaneOffset;
		Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
		Vector3 lhs = worldToCameraMatrix.MultiplyPoint(point);
		Vector3 vector = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
		return new Vector4(vector.x, vector.y, vector.z, -Vector3.Dot(lhs, vector));
	}

	// Token: 0x0600199A RID: 6554 RVA: 0x0010564C File Offset: 0x0010384C
	private static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
	{
		reflectionMat.m00 = 1f - 2f * plane[0] * plane[0];
		reflectionMat.m01 = -2f * plane[0] * plane[1];
		reflectionMat.m02 = -2f * plane[0] * plane[2];
		reflectionMat.m03 = -2f * plane[3] * plane[0];
		reflectionMat.m10 = -2f * plane[1] * plane[0];
		reflectionMat.m11 = 1f - 2f * plane[1] * plane[1];
		reflectionMat.m12 = -2f * plane[1] * plane[2];
		reflectionMat.m13 = -2f * plane[3] * plane[1];
		reflectionMat.m20 = -2f * plane[2] * plane[0];
		reflectionMat.m21 = -2f * plane[2] * plane[1];
		reflectionMat.m22 = 1f - 2f * plane[2] * plane[2];
		reflectionMat.m23 = -2f * plane[3] * plane[2];
		reflectionMat.m30 = 0f;
		reflectionMat.m31 = 0f;
		reflectionMat.m32 = 0f;
		reflectionMat.m33 = 1f;
	}

	// Token: 0x040028F4 RID: 10484
	public bool m_DisablePixelLights = true;

	// Token: 0x040028F5 RID: 10485
	public int m_TextureSize = 256;

	// Token: 0x040028F6 RID: 10486
	public float m_ClipPlaneOffset = 0.07f;

	// Token: 0x040028F7 RID: 10487
	public LayerMask m_ReflectLayers = -1;

	// Token: 0x040028F8 RID: 10488
	private Hashtable m_ReflectionCameras = new Hashtable();

	// Token: 0x040028F9 RID: 10489
	private RenderTexture m_ReflectionTexture;

	// Token: 0x040028FA RID: 10490
	private int m_OldReflectionTextureSize;

	// Token: 0x040028FB RID: 10491
	private static bool s_InsideRendering;
}
