using System;
using UnityEngine;

// Token: 0x0200021E RID: 542
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Vignetting")]
public class CameraFilterPack_TV_Vignetting : MonoBehaviour
{
	// Token: 0x17000322 RID: 802
	// (get) Token: 0x06001196 RID: 4502 RVA: 0x000885B0 File Offset: 0x000867B0
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

	// Token: 0x06001197 RID: 4503 RVA: 0x000885E4 File Offset: 0x000867E4
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

	// Token: 0x06001198 RID: 4504 RVA: 0x0008861C File Offset: 0x0008681C
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

	// Token: 0x06001199 RID: 4505 RVA: 0x000886BA File Offset: 0x000868BA
	private void Update()
	{
	}

	// Token: 0x0600119A RID: 4506 RVA: 0x000886BC File Offset: 0x000868BC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400161F RID: 5663
	public Shader SCShader;

	// Token: 0x04001620 RID: 5664
	private Material SCMaterial;

	// Token: 0x04001621 RID: 5665
	private Texture2D Vignette;

	// Token: 0x04001622 RID: 5666
	[Range(0f, 1f)]
	public float Vignetting = 1f;

	// Token: 0x04001623 RID: 5667
	[Range(0f, 1f)]
	public float VignettingFull;

	// Token: 0x04001624 RID: 5668
	[Range(0f, 1f)]
	public float VignettingDirt;

	// Token: 0x04001625 RID: 5669
	public Color VignettingColor = new Color(0f, 0f, 0f, 1f);
}
