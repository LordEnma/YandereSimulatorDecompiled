using System;
using UnityEngine;

// Token: 0x02000207 RID: 519
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Artefact")]
public class CameraFilterPack_TV_Artefact : MonoBehaviour
{
	// Token: 0x1700030B RID: 779
	// (get) Token: 0x0600110D RID: 4365 RVA: 0x000864A9 File Offset: 0x000846A9
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

	// Token: 0x0600110E RID: 4366 RVA: 0x000864DD File Offset: 0x000846DD
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Artefact");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600110F RID: 4367 RVA: 0x00086500 File Offset: 0x00084700
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
			this.material.SetFloat("_Colorisation", this.Colorisation);
			this.material.SetFloat("_Parasite", this.Parasite);
			this.material.SetFloat("_Noise", this.Noise);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001110 RID: 4368 RVA: 0x000865F8 File Offset: 0x000847F8
	private void Update()
	{
	}

	// Token: 0x06001111 RID: 4369 RVA: 0x000865FA File Offset: 0x000847FA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400159A RID: 5530
	public Shader SCShader;

	// Token: 0x0400159B RID: 5531
	private float TimeX = 1f;

	// Token: 0x0400159C RID: 5532
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x0400159D RID: 5533
	[Range(-10f, 10f)]
	public float Colorisation = 1f;

	// Token: 0x0400159E RID: 5534
	[Range(-10f, 10f)]
	public float Parasite = 1f;

	// Token: 0x0400159F RID: 5535
	[Range(-10f, 10f)]
	public float Noise = 1f;

	// Token: 0x040015A0 RID: 5536
	private Material SCMaterial;
}
