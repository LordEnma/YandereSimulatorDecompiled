using System;
using UnityEngine;

// Token: 0x0200013F RID: 319
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Saturation")]
public class CameraFilterPack_Blend2Camera_Saturation : MonoBehaviour
{
	// Token: 0x17000243 RID: 579
	// (get) Token: 0x06000C29 RID: 3113 RVA: 0x000708C3 File Offset: 0x0006EAC3
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

	// Token: 0x06000C2A RID: 3114 RVA: 0x000708F8 File Offset: 0x0006EAF8
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

	// Token: 0x06000C2B RID: 3115 RVA: 0x0007095C File Offset: 0x0006EB5C
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

	// Token: 0x06000C2C RID: 3116 RVA: 0x00070A4C File Offset: 0x0006EC4C
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C2D RID: 3117 RVA: 0x00070A84 File Offset: 0x0006EC84
	private void Update()
	{
	}

	// Token: 0x06000C2E RID: 3118 RVA: 0x00070A86 File Offset: 0x0006EC86
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C2F RID: 3119 RVA: 0x00070ABE File Offset: 0x0006ECBE
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

	// Token: 0x0400106A RID: 4202
	private string ShaderName = "CameraFilterPack/Blend2Camera_Saturation";

	// Token: 0x0400106B RID: 4203
	public Shader SCShader;

	// Token: 0x0400106C RID: 4204
	public Camera Camera2;

	// Token: 0x0400106D RID: 4205
	private float TimeX = 1f;

	// Token: 0x0400106E RID: 4206
	private Material SCMaterial;

	// Token: 0x0400106F RID: 4207
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001070 RID: 4208
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001071 RID: 4209
	private RenderTexture Camera2tex;
}
