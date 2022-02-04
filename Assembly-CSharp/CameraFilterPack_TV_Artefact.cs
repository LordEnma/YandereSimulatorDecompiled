using System;
using UnityEngine;

// Token: 0x02000207 RID: 519
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Artefact")]
public class CameraFilterPack_TV_Artefact : MonoBehaviour
{
	// Token: 0x1700030B RID: 779
	// (get) Token: 0x0600110C RID: 4364 RVA: 0x00086245 File Offset: 0x00084445
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

	// Token: 0x0600110D RID: 4365 RVA: 0x00086279 File Offset: 0x00084479
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Artefact");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600110E RID: 4366 RVA: 0x0008629C File Offset: 0x0008449C
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

	// Token: 0x0600110F RID: 4367 RVA: 0x00086394 File Offset: 0x00084594
	private void Update()
	{
	}

	// Token: 0x06001110 RID: 4368 RVA: 0x00086396 File Offset: 0x00084596
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001597 RID: 5527
	public Shader SCShader;

	// Token: 0x04001598 RID: 5528
	private float TimeX = 1f;

	// Token: 0x04001599 RID: 5529
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x0400159A RID: 5530
	[Range(-10f, 10f)]
	public float Colorisation = 1f;

	// Token: 0x0400159B RID: 5531
	[Range(-10f, 10f)]
	public float Parasite = 1f;

	// Token: 0x0400159C RID: 5532
	[Range(-10f, 10f)]
	public float Noise = 1f;

	// Token: 0x0400159D RID: 5533
	private Material SCMaterial;
}
