using System;
using UnityEngine;

// Token: 0x0200015F RID: 351
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Contrast")]
public class CameraFilterPack_Color_Contrast : MonoBehaviour
{
	// Token: 0x17000263 RID: 611
	// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x00074086 File Offset: 0x00072286
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

	// Token: 0x06000CF7 RID: 3319 RVA: 0x000740BA File Offset: 0x000722BA
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Contrast");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CF8 RID: 3320 RVA: 0x000740DC File Offset: 0x000722DC
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

	// Token: 0x06000CF9 RID: 3321 RVA: 0x00074192 File Offset: 0x00072392
	private void Update()
	{
	}

	// Token: 0x06000CFA RID: 3322 RVA: 0x00074194 File Offset: 0x00072394
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001147 RID: 4423
	public Shader SCShader;

	// Token: 0x04001148 RID: 4424
	private float TimeX = 1f;

	// Token: 0x04001149 RID: 4425
	private Material SCMaterial;

	// Token: 0x0400114A RID: 4426
	[Range(0f, 10f)]
	public float Contrast = 4.5f;
}
