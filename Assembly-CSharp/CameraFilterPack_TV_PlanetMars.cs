using System;
using UnityEngine;

// Token: 0x02000214 RID: 532
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Planet Mars")]
public class CameraFilterPack_TV_PlanetMars : MonoBehaviour
{
	// Token: 0x17000319 RID: 793
	// (get) Token: 0x0600115D RID: 4445 RVA: 0x00087751 File Offset: 0x00085951
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

	// Token: 0x0600115E RID: 4446 RVA: 0x00087785 File Offset: 0x00085985
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_PlanetMars");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600115F RID: 4447 RVA: 0x000877A8 File Offset: 0x000859A8
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
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001160 RID: 4448 RVA: 0x00087874 File Offset: 0x00085A74
	private void Update()
	{
	}

	// Token: 0x06001161 RID: 4449 RVA: 0x00087876 File Offset: 0x00085A76
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015EC RID: 5612
	public Shader SCShader;

	// Token: 0x040015ED RID: 5613
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015EE RID: 5614
	private float TimeX = 1f;

	// Token: 0x040015EF RID: 5615
	[Range(-10f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040015F0 RID: 5616
	private Material SCMaterial;
}
