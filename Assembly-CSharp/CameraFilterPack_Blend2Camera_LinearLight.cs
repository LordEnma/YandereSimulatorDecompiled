using System;
using UnityEngine;

// Token: 0x02000138 RID: 312
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/LinearLight")]
public class CameraFilterPack_Blend2Camera_LinearLight : MonoBehaviour
{
	// Token: 0x1700023D RID: 573
	// (get) Token: 0x06000BF4 RID: 3060 RVA: 0x0006F277 File Offset: 0x0006D477
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

	// Token: 0x06000BF5 RID: 3061 RVA: 0x0006F2AC File Offset: 0x0006D4AC
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

	// Token: 0x06000BF6 RID: 3062 RVA: 0x0006F310 File Offset: 0x0006D510
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

	// Token: 0x06000BF7 RID: 3063 RVA: 0x0006F400 File Offset: 0x0006D600
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BF8 RID: 3064 RVA: 0x0006F438 File Offset: 0x0006D638
	private void Update()
	{
	}

	// Token: 0x06000BF9 RID: 3065 RVA: 0x0006F43A File Offset: 0x0006D63A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BFA RID: 3066 RVA: 0x0006F472 File Offset: 0x0006D672
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

	// Token: 0x04001027 RID: 4135
	private string ShaderName = "CameraFilterPack/Blend2Camera_LinearLight";

	// Token: 0x04001028 RID: 4136
	public Shader SCShader;

	// Token: 0x04001029 RID: 4137
	public Camera Camera2;

	// Token: 0x0400102A RID: 4138
	private float TimeX = 1f;

	// Token: 0x0400102B RID: 4139
	private Material SCMaterial;

	// Token: 0x0400102C RID: 4140
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400102D RID: 4141
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400102E RID: 4142
	private RenderTexture Camera2tex;
}
