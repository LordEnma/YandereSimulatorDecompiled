using System;
using UnityEngine;

// Token: 0x02000145 RID: 325
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/VividLight")]
public class CameraFilterPack_Blend2Camera_VividLight : MonoBehaviour
{
	// Token: 0x17000249 RID: 585
	// (get) Token: 0x06000C59 RID: 3161 RVA: 0x0007181F File Offset: 0x0006FA1F
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

	// Token: 0x06000C5A RID: 3162 RVA: 0x00071854 File Offset: 0x0006FA54
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

	// Token: 0x06000C5B RID: 3163 RVA: 0x000718B8 File Offset: 0x0006FAB8
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

	// Token: 0x06000C5C RID: 3164 RVA: 0x000719A8 File Offset: 0x0006FBA8
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C5D RID: 3165 RVA: 0x000719E0 File Offset: 0x0006FBE0
	private void Update()
	{
	}

	// Token: 0x06000C5E RID: 3166 RVA: 0x000719E2 File Offset: 0x0006FBE2
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C5F RID: 3167 RVA: 0x00071A1A File Offset: 0x0006FC1A
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

	// Token: 0x040010A9 RID: 4265
	private string ShaderName = "CameraFilterPack/Blend2Camera_VividLight";

	// Token: 0x040010AA RID: 4266
	public Shader SCShader;

	// Token: 0x040010AB RID: 4267
	public Camera Camera2;

	// Token: 0x040010AC RID: 4268
	private float TimeX = 1f;

	// Token: 0x040010AD RID: 4269
	private Material SCMaterial;

	// Token: 0x040010AE RID: 4270
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x040010AF RID: 4271
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x040010B0 RID: 4272
	private RenderTexture Camera2tex;
}
