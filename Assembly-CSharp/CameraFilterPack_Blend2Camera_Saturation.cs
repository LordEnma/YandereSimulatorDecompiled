using System;
using UnityEngine;

// Token: 0x0200013F RID: 319
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Saturation")]
public class CameraFilterPack_Blend2Camera_Saturation : MonoBehaviour
{
	// Token: 0x17000243 RID: 579
	// (get) Token: 0x06000C2B RID: 3115 RVA: 0x00070D3F File Offset: 0x0006EF3F
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

	// Token: 0x06000C2C RID: 3116 RVA: 0x00070D74 File Offset: 0x0006EF74
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

	// Token: 0x06000C2D RID: 3117 RVA: 0x00070DD8 File Offset: 0x0006EFD8
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

	// Token: 0x06000C2E RID: 3118 RVA: 0x00070EC8 File Offset: 0x0006F0C8
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C2F RID: 3119 RVA: 0x00070F00 File Offset: 0x0006F100
	private void Update()
	{
	}

	// Token: 0x06000C30 RID: 3120 RVA: 0x00070F02 File Offset: 0x0006F102
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C31 RID: 3121 RVA: 0x00070F3A File Offset: 0x0006F13A
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

	// Token: 0x04001071 RID: 4209
	private string ShaderName = "CameraFilterPack/Blend2Camera_Saturation";

	// Token: 0x04001072 RID: 4210
	public Shader SCShader;

	// Token: 0x04001073 RID: 4211
	public Camera Camera2;

	// Token: 0x04001074 RID: 4212
	private float TimeX = 1f;

	// Token: 0x04001075 RID: 4213
	private Material SCMaterial;

	// Token: 0x04001076 RID: 4214
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001077 RID: 4215
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001078 RID: 4216
	private RenderTexture Camera2tex;
}
