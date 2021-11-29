using System;
using UnityEngine;

// Token: 0x02000134 RID: 308
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Lighten")]
public class CameraFilterPack_Blend2Camera_Lighten : MonoBehaviour
{
	// Token: 0x17000239 RID: 569
	// (get) Token: 0x06000BD4 RID: 3028 RVA: 0x0006E917 File Offset: 0x0006CB17
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

	// Token: 0x06000BD5 RID: 3029 RVA: 0x0006E94C File Offset: 0x0006CB4C
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

	// Token: 0x06000BD6 RID: 3030 RVA: 0x0006E9B0 File Offset: 0x0006CBB0
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

	// Token: 0x06000BD7 RID: 3031 RVA: 0x0006EAA0 File Offset: 0x0006CCA0
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BD8 RID: 3032 RVA: 0x0006EAD8 File Offset: 0x0006CCD8
	private void Update()
	{
	}

	// Token: 0x06000BD9 RID: 3033 RVA: 0x0006EADA File Offset: 0x0006CCDA
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BDA RID: 3034 RVA: 0x0006EB12 File Offset: 0x0006CD12
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

	// Token: 0x04001007 RID: 4103
	private string ShaderName = "CameraFilterPack/Blend2Camera_Lighten";

	// Token: 0x04001008 RID: 4104
	public Shader SCShader;

	// Token: 0x04001009 RID: 4105
	public Camera Camera2;

	// Token: 0x0400100A RID: 4106
	private float TimeX = 1f;

	// Token: 0x0400100B RID: 4107
	private Material SCMaterial;

	// Token: 0x0400100C RID: 4108
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400100D RID: 4109
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400100E RID: 4110
	private RenderTexture Camera2tex;
}
