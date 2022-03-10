using System;
using UnityEngine;

// Token: 0x0200021E RID: 542
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Vignetting")]
public class CameraFilterPack_TV_Vignetting : MonoBehaviour
{
	// Token: 0x17000322 RID: 802
	// (get) Token: 0x06001197 RID: 4503 RVA: 0x0008895C File Offset: 0x00086B5C
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

	// Token: 0x06001198 RID: 4504 RVA: 0x00088990 File Offset: 0x00086B90
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

	// Token: 0x06001199 RID: 4505 RVA: 0x000889C8 File Offset: 0x00086BC8
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

	// Token: 0x0600119A RID: 4506 RVA: 0x00088A66 File Offset: 0x00086C66
	private void Update()
	{
	}

	// Token: 0x0600119B RID: 4507 RVA: 0x00088A68 File Offset: 0x00086C68
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400162B RID: 5675
	public Shader SCShader;

	// Token: 0x0400162C RID: 5676
	private Material SCMaterial;

	// Token: 0x0400162D RID: 5677
	private Texture2D Vignette;

	// Token: 0x0400162E RID: 5678
	[Range(0f, 1f)]
	public float Vignetting = 1f;

	// Token: 0x0400162F RID: 5679
	[Range(0f, 1f)]
	public float VignettingFull;

	// Token: 0x04001630 RID: 5680
	[Range(0f, 1f)]
	public float VignettingDirt;

	// Token: 0x04001631 RID: 5681
	public Color VignettingColor = new Color(0f, 0f, 0f, 1f);
}
