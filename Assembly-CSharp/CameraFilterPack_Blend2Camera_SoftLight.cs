using System;
using UnityEngine;

// Token: 0x02000141 RID: 321
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/SoftLight")]
public class CameraFilterPack_Blend2Camera_SoftLight : MonoBehaviour
{
	// Token: 0x17000245 RID: 581
	// (get) Token: 0x06000C3B RID: 3131 RVA: 0x000711EF File Offset: 0x0006F3EF
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

	// Token: 0x06000C3C RID: 3132 RVA: 0x00071224 File Offset: 0x0006F424
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

	// Token: 0x06000C3D RID: 3133 RVA: 0x00071288 File Offset: 0x0006F488
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

	// Token: 0x06000C3E RID: 3134 RVA: 0x00071378 File Offset: 0x0006F578
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C3F RID: 3135 RVA: 0x000713B0 File Offset: 0x0006F5B0
	private void Update()
	{
	}

	// Token: 0x06000C40 RID: 3136 RVA: 0x000713B2 File Offset: 0x0006F5B2
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C41 RID: 3137 RVA: 0x000713EA File Offset: 0x0006F5EA
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

	// Token: 0x04001081 RID: 4225
	private string ShaderName = "CameraFilterPack/Blend2Camera_SoftLight";

	// Token: 0x04001082 RID: 4226
	public Shader SCShader;

	// Token: 0x04001083 RID: 4227
	public Camera Camera2;

	// Token: 0x04001084 RID: 4228
	private float TimeX = 1f;

	// Token: 0x04001085 RID: 4229
	private Material SCMaterial;

	// Token: 0x04001086 RID: 4230
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001087 RID: 4231
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001088 RID: 4232
	private RenderTexture Camera2tex;
}
