using System;
using UnityEngine;

// Token: 0x0200015F RID: 351
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Contrast")]
public class CameraFilterPack_Color_Contrast : MonoBehaviour
{
	// Token: 0x17000263 RID: 611
	// (get) Token: 0x06000CF7 RID: 3319 RVA: 0x00074432 File Offset: 0x00072632
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

	// Token: 0x06000CF8 RID: 3320 RVA: 0x00074466 File Offset: 0x00072666
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Contrast");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CF9 RID: 3321 RVA: 0x00074488 File Offset: 0x00072688
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_Contrast", this.Contrast);
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CFA RID: 3322 RVA: 0x0007453E File Offset: 0x0007273E
	private void Update()
	{
	}

	// Token: 0x06000CFB RID: 3323 RVA: 0x00074540 File Offset: 0x00072740
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001153 RID: 4435
	public Shader SCShader;

	// Token: 0x04001154 RID: 4436
	private float TimeX = 1f;

	// Token: 0x04001155 RID: 4437
	private Material SCMaterial;

	// Token: 0x04001156 RID: 4438
	[Range(0f, 10f)]
	public float Contrast = 4.5f;
}
