using System;
using UnityEngine;

// Token: 0x02000144 RID: 324
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Subtract")]
public class CameraFilterPack_Blend2Camera_Subtract : MonoBehaviour
{
	// Token: 0x17000248 RID: 584
	// (get) Token: 0x06000C50 RID: 3152 RVA: 0x00071219 File Offset: 0x0006F419
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

	// Token: 0x06000C51 RID: 3153 RVA: 0x00071250 File Offset: 0x0006F450
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

	// Token: 0x06000C52 RID: 3154 RVA: 0x000712B4 File Offset: 0x0006F4B4
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

	// Token: 0x06000C53 RID: 3155 RVA: 0x000713A4 File Offset: 0x0006F5A4
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C54 RID: 3156 RVA: 0x000713DC File Offset: 0x0006F5DC
	private void Update()
	{
	}

	// Token: 0x06000C55 RID: 3157 RVA: 0x000713DE File Offset: 0x0006F5DE
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C56 RID: 3158 RVA: 0x00071416 File Offset: 0x0006F616
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

	// Token: 0x04001095 RID: 4245
	private string ShaderName = "CameraFilterPack/Blend2Camera_Subtract";

	// Token: 0x04001096 RID: 4246
	public Shader SCShader;

	// Token: 0x04001097 RID: 4247
	public Camera Camera2;

	// Token: 0x04001098 RID: 4248
	private float TimeX = 1f;

	// Token: 0x04001099 RID: 4249
	private Material SCMaterial;

	// Token: 0x0400109A RID: 4250
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400109B RID: 4251
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400109C RID: 4252
	private RenderTexture Camera2tex;
}
