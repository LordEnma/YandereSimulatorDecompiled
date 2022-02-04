using System;
using UnityEngine;

// Token: 0x0200018C RID: 396
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/EnhancedComics")]
public class CameraFilterPack_Drawing_EnhancedComics : MonoBehaviour
{
	// Token: 0x17000290 RID: 656
	// (get) Token: 0x06000E06 RID: 3590 RVA: 0x0007862C File Offset: 0x0007682C
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

	// Token: 0x06000E07 RID: 3591 RVA: 0x00078660 File Offset: 0x00076860
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_EnhancedComics");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E08 RID: 3592 RVA: 0x00078684 File Offset: 0x00076884
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
			this.material.SetFloat("_ColorR", this._ColorR);
			this.material.SetFloat("_ColorG", this._ColorG);
			this.material.SetFloat("_ColorB", this._ColorB);
			this.material.SetFloat("_Blood", this._Blood);
			this.material.SetColor("_ColorRGB", this.ColorRGB);
			this.material.SetFloat("_SmoothStart", this._SmoothStart);
			this.material.SetFloat("_SmoothEnd", this._SmoothEnd);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E09 RID: 3593 RVA: 0x000787A7 File Offset: 0x000769A7
	private void Update()
	{
	}

	// Token: 0x06000E0A RID: 3594 RVA: 0x000787A9 File Offset: 0x000769A9
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001247 RID: 4679
	public Shader SCShader;

	// Token: 0x04001248 RID: 4680
	private float TimeX = 1f;

	// Token: 0x04001249 RID: 4681
	private Material SCMaterial;

	// Token: 0x0400124A RID: 4682
	[Range(0f, 1f)]
	public float DotSize = 0.15f;

	// Token: 0x0400124B RID: 4683
	[Range(0f, 1f)]
	public float _ColorR = 0.9f;

	// Token: 0x0400124C RID: 4684
	[Range(0f, 1f)]
	public float _ColorG = 0.4f;

	// Token: 0x0400124D RID: 4685
	[Range(0f, 1f)]
	public float _ColorB = 0.4f;

	// Token: 0x0400124E RID: 4686
	[Range(0f, 1f)]
	public float _Blood = 0.5f;

	// Token: 0x0400124F RID: 4687
	[Range(0f, 1f)]
	public float _SmoothStart = 0.02f;

	// Token: 0x04001250 RID: 4688
	[Range(0f, 1f)]
	public float _SmoothEnd = 0.1f;

	// Token: 0x04001251 RID: 4689
	public Color ColorRGB = new Color(1f, 0f, 0f);
}
