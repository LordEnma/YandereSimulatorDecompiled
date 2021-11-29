using System;
using UnityEngine;

// Token: 0x0200016E RID: 366
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/NewPosterize")]
public class CameraFilterPack_Colors_NewPosterize : MonoBehaviour
{
	// Token: 0x17000273 RID: 627
	// (get) Token: 0x06000D55 RID: 3413 RVA: 0x00075A05 File Offset: 0x00073C05
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

	// Token: 0x06000D56 RID: 3414 RVA: 0x00075A39 File Offset: 0x00073C39
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_NewPosterize");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D57 RID: 3415 RVA: 0x00075A5C File Offset: 0x00073C5C
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.Gamma);
			this.material.SetFloat("_Value2", this.Colors);
			this.material.SetFloat("_Value3", this.Green_Mod);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D58 RID: 3416 RVA: 0x00075B54 File Offset: 0x00073D54
	private void Update()
	{
	}

	// Token: 0x06000D59 RID: 3417 RVA: 0x00075B56 File Offset: 0x00073D56
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001198 RID: 4504
	public Shader SCShader;

	// Token: 0x04001199 RID: 4505
	private float TimeX = 1f;

	// Token: 0x0400119A RID: 4506
	private Material SCMaterial;

	// Token: 0x0400119B RID: 4507
	[Range(0f, 2f)]
	public float Gamma = 1f;

	// Token: 0x0400119C RID: 4508
	[Range(0f, 16f)]
	public float Colors = 11f;

	// Token: 0x0400119D RID: 4509
	[Range(-1f, 1f)]
	public float Green_Mod = 1f;

	// Token: 0x0400119E RID: 4510
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
