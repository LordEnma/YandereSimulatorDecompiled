using System;
using UnityEngine;

// Token: 0x02000128 RID: 296
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/ColorBurn")]
public class CameraFilterPack_Blend2Camera_ColorBurn : MonoBehaviour
{
	// Token: 0x1700022D RID: 557
	// (get) Token: 0x06000B76 RID: 2934 RVA: 0x0006CC73 File Offset: 0x0006AE73
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

	// Token: 0x06000B77 RID: 2935 RVA: 0x0006CCA8 File Offset: 0x0006AEA8
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

	// Token: 0x06000B78 RID: 2936 RVA: 0x0006CD0C File Offset: 0x0006AF0C
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

	// Token: 0x06000B79 RID: 2937 RVA: 0x0006CDFC File Offset: 0x0006AFFC
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B7A RID: 2938 RVA: 0x0006CE34 File Offset: 0x0006B034
	private void Update()
	{
	}

	// Token: 0x06000B7B RID: 2939 RVA: 0x0006CE36 File Offset: 0x0006B036
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B7C RID: 2940 RVA: 0x0006CE6E File Offset: 0x0006B06E
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

	// Token: 0x04000F9A RID: 3994
	private string ShaderName = "CameraFilterPack/Blend2Camera_ColorBurn";

	// Token: 0x04000F9B RID: 3995
	public Shader SCShader;

	// Token: 0x04000F9C RID: 3996
	public Camera Camera2;

	// Token: 0x04000F9D RID: 3997
	private float TimeX = 1f;

	// Token: 0x04000F9E RID: 3998
	private Material SCMaterial;

	// Token: 0x04000F9F RID: 3999
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FA0 RID: 4000
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FA1 RID: 4001
	private RenderTexture Camera2tex;
}
