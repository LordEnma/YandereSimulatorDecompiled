using System;
using UnityEngine;

// Token: 0x02000136 RID: 310
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/LinearBurn")]
public class CameraFilterPack_Blend2Camera_LinearBurn : MonoBehaviour
{
	// Token: 0x1700023B RID: 571
	// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x0006EDC7 File Offset: 0x0006CFC7
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

	// Token: 0x06000BE5 RID: 3045 RVA: 0x0006EDFC File Offset: 0x0006CFFC
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

	// Token: 0x06000BE6 RID: 3046 RVA: 0x0006EE60 File Offset: 0x0006D060
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

	// Token: 0x06000BE7 RID: 3047 RVA: 0x0006EF50 File Offset: 0x0006D150
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BE8 RID: 3048 RVA: 0x0006EF88 File Offset: 0x0006D188
	private void Update()
	{
	}

	// Token: 0x06000BE9 RID: 3049 RVA: 0x0006EF8A File Offset: 0x0006D18A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BEA RID: 3050 RVA: 0x0006EFC2 File Offset: 0x0006D1C2
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

	// Token: 0x04001017 RID: 4119
	private string ShaderName = "CameraFilterPack/Blend2Camera_LinearBurn";

	// Token: 0x04001018 RID: 4120
	public Shader SCShader;

	// Token: 0x04001019 RID: 4121
	public Camera Camera2;

	// Token: 0x0400101A RID: 4122
	private float TimeX = 1f;

	// Token: 0x0400101B RID: 4123
	private Material SCMaterial;

	// Token: 0x0400101C RID: 4124
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400101D RID: 4125
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400101E RID: 4126
	private RenderTexture Camera2tex;
}
