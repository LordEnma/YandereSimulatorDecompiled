using System;
using UnityEngine;

// Token: 0x02000207 RID: 519
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Artefact")]
public class CameraFilterPack_TV_Artefact : MonoBehaviour
{
	// Token: 0x1700030B RID: 779
	// (get) Token: 0x0600110F RID: 4367 RVA: 0x00086A6D File Offset: 0x00084C6D
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

	// Token: 0x06001110 RID: 4368 RVA: 0x00086AA1 File Offset: 0x00084CA1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Artefact");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001111 RID: 4369 RVA: 0x00086AC4 File Offset: 0x00084CC4
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

	// Token: 0x06001112 RID: 4370 RVA: 0x00086BBC File Offset: 0x00084DBC
	private void Update()
	{
	}

	// Token: 0x06001113 RID: 4371 RVA: 0x00086BBE File Offset: 0x00084DBE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015AA RID: 5546
	public Shader SCShader;

	// Token: 0x040015AB RID: 5547
	private float TimeX = 1f;

	// Token: 0x040015AC RID: 5548
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015AD RID: 5549
	[Range(-10f, 10f)]
	public float Colorisation = 1f;

	// Token: 0x040015AE RID: 5550
	[Range(-10f, 10f)]
	public float Parasite = 1f;

	// Token: 0x040015AF RID: 5551
	[Range(-10f, 10f)]
	public float Noise = 1f;

	// Token: 0x040015B0 RID: 5552
	private Material SCMaterial;
}
