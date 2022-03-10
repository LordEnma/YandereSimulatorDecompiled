using System;
using UnityEngine;

// Token: 0x0200013C RID: 316
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Overlay")]
public class CameraFilterPack_Blend2Camera_Overlay : MonoBehaviour
{
	// Token: 0x17000240 RID: 576
	// (get) Token: 0x06000C10 RID: 3088 RVA: 0x0006FF23 File Offset: 0x0006E123
	private Material material
	{
		get
		{
			if (this.SCMaterial == null)
			{
				this.SCMaterial = new Material(this.SCShader);
				this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.SCMaterial;
		}
	}

	// Token: 0x06000C11 RID: 3089 RVA: 0x0006FF58 File Offset: 0x0006E158
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C12 RID: 3090 RVA: 0x0006FFBC File Offset: 0x0006E1BC
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			if (this.Camera2 != null)
			{
				this.material.SetTexture("_MainTex2", this.Camera2tex);
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.BlendFX);
			this.material.SetFloat("_Value2", this.SwitchCameraToCamera2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C13 RID: 3091 RVA: 0x000700AC File Offset: 0x0006E2AC
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C14 RID: 3092 RVA: 0x000700E4 File Offset: 0x0006E2E4
	private void Update()
	{
	}

	// Token: 0x06000C15 RID: 3093 RVA: 0x000700E6 File Offset: 0x0006E2E6
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C16 RID: 3094 RVA: 0x0007011E File Offset: 0x0006E31E
	private void OnDisable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2.targetTexture = null;
		}
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001050 RID: 4176
	private string ShaderName = "CameraFilterPack/Blend2Camera_Overlay";

	// Token: 0x04001051 RID: 4177
	public Shader SCShader;

	// Token: 0x04001052 RID: 4178
	public Camera Camera2;

	// Token: 0x04001053 RID: 4179
	private float TimeX = 1f;

	// Token: 0x04001054 RID: 4180
	private Material SCMaterial;

	// Token: 0x04001055 RID: 4181
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001056 RID: 4182
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001057 RID: 4183
	private RenderTexture Camera2tex;
}
