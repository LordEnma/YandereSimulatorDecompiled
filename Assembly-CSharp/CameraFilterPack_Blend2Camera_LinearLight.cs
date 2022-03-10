using System;
using UnityEngine;

// Token: 0x02000139 RID: 313
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/LinearLight")]
public class CameraFilterPack_Blend2Camera_LinearLight : MonoBehaviour
{
	// Token: 0x1700023D RID: 573
	// (get) Token: 0x06000BF8 RID: 3064 RVA: 0x0006F81B File Offset: 0x0006DA1B
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

	// Token: 0x06000BF9 RID: 3065 RVA: 0x0006F850 File Offset: 0x0006DA50
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

	// Token: 0x06000BFA RID: 3066 RVA: 0x0006F8B4 File Offset: 0x0006DAB4
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

	// Token: 0x06000BFB RID: 3067 RVA: 0x0006F9A4 File Offset: 0x0006DBA4
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BFC RID: 3068 RVA: 0x0006F9DC File Offset: 0x0006DBDC
	private void Update()
	{
	}

	// Token: 0x06000BFD RID: 3069 RVA: 0x0006F9DE File Offset: 0x0006DBDE
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BFE RID: 3070 RVA: 0x0006FA16 File Offset: 0x0006DC16
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

	// Token: 0x04001038 RID: 4152
	private string ShaderName = "CameraFilterPack/Blend2Camera_LinearLight";

	// Token: 0x04001039 RID: 4153
	public Shader SCShader;

	// Token: 0x0400103A RID: 4154
	public Camera Camera2;

	// Token: 0x0400103B RID: 4155
	private float TimeX = 1f;

	// Token: 0x0400103C RID: 4156
	private Material SCMaterial;

	// Token: 0x0400103D RID: 4157
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400103E RID: 4158
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400103F RID: 4159
	private RenderTexture Camera2tex;
}
