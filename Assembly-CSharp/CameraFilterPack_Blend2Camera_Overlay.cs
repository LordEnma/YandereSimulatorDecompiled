using System;
using UnityEngine;

// Token: 0x0200013C RID: 316
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Overlay")]
public class CameraFilterPack_Blend2Camera_Overlay : MonoBehaviour
{
	// Token: 0x17000240 RID: 576
	// (get) Token: 0x06000C12 RID: 3090 RVA: 0x0007039F File Offset: 0x0006E59F
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

	// Token: 0x06000C13 RID: 3091 RVA: 0x000703D4 File Offset: 0x0006E5D4
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

	// Token: 0x06000C14 RID: 3092 RVA: 0x00070438 File Offset: 0x0006E638
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

	// Token: 0x06000C15 RID: 3093 RVA: 0x00070528 File Offset: 0x0006E728
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C16 RID: 3094 RVA: 0x00070560 File Offset: 0x0006E760
	private void Update()
	{
	}

	// Token: 0x06000C17 RID: 3095 RVA: 0x00070562 File Offset: 0x0006E762
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C18 RID: 3096 RVA: 0x0007059A File Offset: 0x0006E79A
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

	// Token: 0x04001057 RID: 4183
	private string ShaderName = "CameraFilterPack/Blend2Camera_Overlay";

	// Token: 0x04001058 RID: 4184
	public Shader SCShader;

	// Token: 0x04001059 RID: 4185
	public Camera Camera2;

	// Token: 0x0400105A RID: 4186
	private float TimeX = 1f;

	// Token: 0x0400105B RID: 4187
	private Material SCMaterial;

	// Token: 0x0400105C RID: 4188
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400105D RID: 4189
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400105E RID: 4190
	private RenderTexture Camera2tex;
}
