using System;
using UnityEngine;

// Token: 0x0200021E RID: 542
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Vignetting")]
public class CameraFilterPack_TV_Vignetting : MonoBehaviour
{
	// Token: 0x17000322 RID: 802
	// (get) Token: 0x06001197 RID: 4503 RVA: 0x00088814 File Offset: 0x00086A14
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

	// Token: 0x06001198 RID: 4504 RVA: 0x00088848 File Offset: 0x00086A48
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

	// Token: 0x06001199 RID: 4505 RVA: 0x00088880 File Offset: 0x00086A80
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

	// Token: 0x0600119A RID: 4506 RVA: 0x0008891E File Offset: 0x00086B1E
	private void Update()
	{
	}

	// Token: 0x0600119B RID: 4507 RVA: 0x00088920 File Offset: 0x00086B20
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001622 RID: 5666
	public Shader SCShader;

	// Token: 0x04001623 RID: 5667
	private Material SCMaterial;

	// Token: 0x04001624 RID: 5668
	private Texture2D Vignette;

	// Token: 0x04001625 RID: 5669
	[Range(0f, 1f)]
	public float Vignetting = 1f;

	// Token: 0x04001626 RID: 5670
	[Range(0f, 1f)]
	public float VignettingFull;

	// Token: 0x04001627 RID: 5671
	[Range(0f, 1f)]
	public float VignettingDirt;

	// Token: 0x04001628 RID: 5672
	public Color VignettingColor = new Color(0f, 0f, 0f, 1f);
}
