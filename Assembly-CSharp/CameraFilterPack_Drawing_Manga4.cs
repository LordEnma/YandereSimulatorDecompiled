using System;
using UnityEngine;

// Token: 0x02000192 RID: 402
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga4")]
public class CameraFilterPack_Drawing_Manga4 : MonoBehaviour
{
	// Token: 0x17000297 RID: 663
	// (get) Token: 0x06000E2D RID: 3629 RVA: 0x00078DA0 File Offset: 0x00076FA0
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

	// Token: 0x06000E2E RID: 3630 RVA: 0x00078DD4 File Offset: 0x00076FD4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga4");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E2F RID: 3631 RVA: 0x00078DF8 File Offset: 0x00076FF8
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

	// Token: 0x06000E30 RID: 3632 RVA: 0x00078E7E File Offset: 0x0007707E
	private void Update()
	{
	}

	// Token: 0x06000E31 RID: 3633 RVA: 0x00078E80 File Offset: 0x00077080
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001268 RID: 4712
	public Shader SCShader;

	// Token: 0x04001269 RID: 4713
	private float TimeX = 1f;

	// Token: 0x0400126A RID: 4714
	private Material SCMaterial;

	// Token: 0x0400126B RID: 4715
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
