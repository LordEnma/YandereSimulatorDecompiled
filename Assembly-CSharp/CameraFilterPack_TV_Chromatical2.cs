using System;
using UnityEngine;

// Token: 0x0200020B RID: 523
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Chromatical2")]
public class CameraFilterPack_TV_Chromatical2 : MonoBehaviour
{
	// Token: 0x1700030F RID: 783
	// (get) Token: 0x06001127 RID: 4391 RVA: 0x000873BD File Offset: 0x000855BD
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

	// Token: 0x06001128 RID: 4392 RVA: 0x000873F1 File Offset: 0x000855F1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Chromatical2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001129 RID: 4393 RVA: 0x00087414 File Offset: 0x00085614
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
			this.material.SetFloat("_Value", this.Aberration);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetFloat("ZoomFade", this.ZoomFade);
			this.material.SetFloat("ZoomSpeed", this.ZoomSpeed);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600112A RID: 4394 RVA: 0x0008750C File Offset: 0x0008570C
	private void Update()
	{
	}

	// Token: 0x0600112B RID: 4395 RVA: 0x0008750E File Offset: 0x0008570E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015D0 RID: 5584
	public Shader SCShader;

	// Token: 0x040015D1 RID: 5585
	private float TimeX = 1f;

	// Token: 0x040015D2 RID: 5586
	private Material SCMaterial;

	// Token: 0x040015D3 RID: 5587
	[Range(0f, 10f)]
	public float Aberration = 2f;

	// Token: 0x040015D4 RID: 5588
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015D5 RID: 5589
	[Range(0f, 1f)]
	public float ZoomFade = 1f;

	// Token: 0x040015D6 RID: 5590
	[Range(0f, 8f)]
	public float ZoomSpeed = 1f;
}
