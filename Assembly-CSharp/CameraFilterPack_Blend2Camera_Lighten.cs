using System;
using UnityEngine;

// Token: 0x02000135 RID: 309
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Lighten")]
public class CameraFilterPack_Blend2Camera_Lighten : MonoBehaviour
{
	// Token: 0x17000239 RID: 569
	// (get) Token: 0x06000BD8 RID: 3032 RVA: 0x0006EC5F File Offset: 0x0006CE5F
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

	// Token: 0x06000BD9 RID: 3033 RVA: 0x0006EC94 File Offset: 0x0006CE94
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

	// Token: 0x06000BDA RID: 3034 RVA: 0x0006ECF8 File Offset: 0x0006CEF8
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

	// Token: 0x06000BDB RID: 3035 RVA: 0x0006EDE8 File Offset: 0x0006CFE8
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BDC RID: 3036 RVA: 0x0006EE20 File Offset: 0x0006D020
	private void Update()
	{
	}

	// Token: 0x06000BDD RID: 3037 RVA: 0x0006EE22 File Offset: 0x0006D022
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BDE RID: 3038 RVA: 0x0006EE5A File Offset: 0x0006D05A
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

	// Token: 0x0400100F RID: 4111
	private string ShaderName = "CameraFilterPack/Blend2Camera_Lighten";

	// Token: 0x04001010 RID: 4112
	public Shader SCShader;

	// Token: 0x04001011 RID: 4113
	public Camera Camera2;

	// Token: 0x04001012 RID: 4114
	private float TimeX = 1f;

	// Token: 0x04001013 RID: 4115
	private Material SCMaterial;

	// Token: 0x04001014 RID: 4116
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001015 RID: 4117
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001016 RID: 4118
	private RenderTexture Camera2tex;
}
