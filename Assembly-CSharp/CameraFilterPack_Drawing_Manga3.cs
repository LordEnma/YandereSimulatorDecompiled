using System;
using UnityEngine;

// Token: 0x02000192 RID: 402
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga3")]
public class CameraFilterPack_Drawing_Manga3 : MonoBehaviour
{
	// Token: 0x17000296 RID: 662
	// (get) Token: 0x06000E2A RID: 3626 RVA: 0x00078E80 File Offset: 0x00077080
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

	// Token: 0x06000E2B RID: 3627 RVA: 0x00078EB4 File Offset: 0x000770B4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E2C RID: 3628 RVA: 0x00078ED8 File Offset: 0x000770D8
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
			this.material.SetFloat("_DotSize", this.DotSize);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E2D RID: 3629 RVA: 0x00078F5E File Offset: 0x0007715E
	private void Update()
	{
	}

	// Token: 0x06000E2E RID: 3630 RVA: 0x00078F60 File Offset: 0x00077160
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001269 RID: 4713
	public Shader SCShader;

	// Token: 0x0400126A RID: 4714
	private float TimeX = 1f;

	// Token: 0x0400126B RID: 4715
	private Material SCMaterial;

	// Token: 0x0400126C RID: 4716
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
