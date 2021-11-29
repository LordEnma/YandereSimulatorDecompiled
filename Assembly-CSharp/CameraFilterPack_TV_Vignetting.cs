using System;
using UnityEngine;

// Token: 0x0200021D RID: 541
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Vignetting")]
public class CameraFilterPack_TV_Vignetting : MonoBehaviour
{
	// Token: 0x17000322 RID: 802
	// (get) Token: 0x06001193 RID: 4499 RVA: 0x000883B8 File Offset: 0x000865B8
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

	// Token: 0x06001194 RID: 4500 RVA: 0x000883EC File Offset: 0x000865EC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Vignetting");
		this.Vignette = (Resources.Load("CameraFilterPack_TV_Vignetting1") as Texture2D);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001195 RID: 4501 RVA: 0x00088424 File Offset: 0x00086624
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.material.SetTexture("Vignette", this.Vignette);
			this.material.SetFloat("_Vignetting", this.Vignetting);
			this.material.SetFloat("_Vignetting2", this.VignettingFull);
			this.material.SetColor("_VignettingColor", this.VignettingColor);
			this.material.SetFloat("_VignettingDirt", this.VignettingDirt);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001196 RID: 4502 RVA: 0x000884C2 File Offset: 0x000866C2
	private void Update()
	{
	}

	// Token: 0x06001197 RID: 4503 RVA: 0x000884C4 File Offset: 0x000866C4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400161A RID: 5658
	public Shader SCShader;

	// Token: 0x0400161B RID: 5659
	private Material SCMaterial;

	// Token: 0x0400161C RID: 5660
	private Texture2D Vignette;

	// Token: 0x0400161D RID: 5661
	[Range(0f, 1f)]
	public float Vignetting = 1f;

	// Token: 0x0400161E RID: 5662
	[Range(0f, 1f)]
	public float VignettingFull;

	// Token: 0x0400161F RID: 5663
	[Range(0f, 1f)]
	public float VignettingDirt;

	// Token: 0x04001620 RID: 5664
	public Color VignettingColor = new Color(0f, 0f, 0f, 1f);
}
