using System;
using UnityEngine;

// Token: 0x0200013F RID: 319
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Saturation")]
public class CameraFilterPack_Blend2Camera_Saturation : MonoBehaviour
{
	// Token: 0x17000243 RID: 579
	// (get) Token: 0x06000C29 RID: 3113 RVA: 0x0007077B File Offset: 0x0006E97B
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

	// Token: 0x06000C2A RID: 3114 RVA: 0x000707B0 File Offset: 0x0006E9B0
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

	// Token: 0x06000C2B RID: 3115 RVA: 0x00070814 File Offset: 0x0006EA14
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

	// Token: 0x06000C2C RID: 3116 RVA: 0x00070904 File Offset: 0x0006EB04
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C2D RID: 3117 RVA: 0x0007093C File Offset: 0x0006EB3C
	private void Update()
	{
	}

	// Token: 0x06000C2E RID: 3118 RVA: 0x0007093E File Offset: 0x0006EB3E
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C2F RID: 3119 RVA: 0x00070976 File Offset: 0x0006EB76
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

	// Token: 0x04001061 RID: 4193
	private string ShaderName = "CameraFilterPack/Blend2Camera_Saturation";

	// Token: 0x04001062 RID: 4194
	public Shader SCShader;

	// Token: 0x04001063 RID: 4195
	public Camera Camera2;

	// Token: 0x04001064 RID: 4196
	private float TimeX = 1f;

	// Token: 0x04001065 RID: 4197
	private Material SCMaterial;

	// Token: 0x04001066 RID: 4198
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001067 RID: 4199
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001068 RID: 4200
	private RenderTexture Camera2tex;
}
