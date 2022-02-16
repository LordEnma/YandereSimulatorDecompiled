using System;
using UnityEngine;

// Token: 0x02000141 RID: 321
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/SoftLight")]
public class CameraFilterPack_Blend2Camera_SoftLight : MonoBehaviour
{
	// Token: 0x17000245 RID: 581
	// (get) Token: 0x06000C39 RID: 3129 RVA: 0x00070B17 File Offset: 0x0006ED17
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

	// Token: 0x06000C3A RID: 3130 RVA: 0x00070B4C File Offset: 0x0006ED4C
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

	// Token: 0x06000C3B RID: 3131 RVA: 0x00070BB0 File Offset: 0x0006EDB0
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

	// Token: 0x06000C3C RID: 3132 RVA: 0x00070CA0 File Offset: 0x0006EEA0
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C3D RID: 3133 RVA: 0x00070CD8 File Offset: 0x0006EED8
	private void Update()
	{
	}

	// Token: 0x06000C3E RID: 3134 RVA: 0x00070CDA File Offset: 0x0006EEDA
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C3F RID: 3135 RVA: 0x00070D12 File Offset: 0x0006EF12
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
	private string ShaderName = "CameraFilterPack/Blend2Camera_SoftLight";

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
