using System;
using UnityEngine;

// Token: 0x0200021E RID: 542
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Vignetting")]
public class CameraFilterPack_TV_Vignetting : MonoBehaviour
{
	// Token: 0x17000322 RID: 802
	// (get) Token: 0x06001199 RID: 4505 RVA: 0x00088DD8 File Offset: 0x00086FD8
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

	// Token: 0x0600119A RID: 4506 RVA: 0x00088E0C File Offset: 0x0008700C
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

	// Token: 0x0600119B RID: 4507 RVA: 0x00088E44 File Offset: 0x00087044
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

	// Token: 0x0600119C RID: 4508 RVA: 0x00088EE2 File Offset: 0x000870E2
	private void Update()
	{
	}

	// Token: 0x0600119D RID: 4509 RVA: 0x00088EE4 File Offset: 0x000870E4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001632 RID: 5682
	public Shader SCShader;

	// Token: 0x04001633 RID: 5683
	private Material SCMaterial;

	// Token: 0x04001634 RID: 5684
	private Texture2D Vignette;

	// Token: 0x04001635 RID: 5685
	[Range(0f, 1f)]
	public float Vignetting = 1f;

	// Token: 0x04001636 RID: 5686
	[Range(0f, 1f)]
	public float VignettingFull;

	// Token: 0x04001637 RID: 5687
	[Range(0f, 1f)]
	public float VignettingDirt;

	// Token: 0x04001638 RID: 5688
	public Color VignettingColor = new Color(0f, 0f, 0f, 1f);
}
