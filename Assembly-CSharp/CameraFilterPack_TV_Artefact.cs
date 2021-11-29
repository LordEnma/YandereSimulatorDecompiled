using System;
using UnityEngine;

// Token: 0x02000206 RID: 518
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Artefact")]
public class CameraFilterPack_TV_Artefact : MonoBehaviour
{
	// Token: 0x1700030B RID: 779
	// (get) Token: 0x06001109 RID: 4361 RVA: 0x0008604D File Offset: 0x0008424D
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

	// Token: 0x0600110A RID: 4362 RVA: 0x00086081 File Offset: 0x00084281
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Artefact");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600110B RID: 4363 RVA: 0x000860A4 File Offset: 0x000842A4
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

	// Token: 0x0600110C RID: 4364 RVA: 0x0008619C File Offset: 0x0008439C
	private void Update()
	{
	}

	// Token: 0x0600110D RID: 4365 RVA: 0x0008619E File Offset: 0x0008439E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001592 RID: 5522
	public Shader SCShader;

	// Token: 0x04001593 RID: 5523
	private float TimeX = 1f;

	// Token: 0x04001594 RID: 5524
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001595 RID: 5525
	[Range(-10f, 10f)]
	public float Colorisation = 1f;

	// Token: 0x04001596 RID: 5526
	[Range(-10f, 10f)]
	public float Parasite = 1f;

	// Token: 0x04001597 RID: 5527
	[Range(-10f, 10f)]
	public float Noise = 1f;

	// Token: 0x04001598 RID: 5528
	private Material SCMaterial;
}
