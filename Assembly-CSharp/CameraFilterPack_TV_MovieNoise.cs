using System;
using UnityEngine;

// Token: 0x02000210 RID: 528
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Movie Noise")]
public class CameraFilterPack_TV_MovieNoise : MonoBehaviour
{
	// Token: 0x17000314 RID: 788
	// (get) Token: 0x06001145 RID: 4421 RVA: 0x00087AF0 File Offset: 0x00085CF0
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

	// Token: 0x06001146 RID: 4422 RVA: 0x00087B24 File Offset: 0x00085D24
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_MovieNoise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001147 RID: 4423 RVA: 0x00087B48 File Offset: 0x00085D48
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
			this.material.SetFloat("_Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001148 RID: 4424 RVA: 0x00087BFE File Offset: 0x00085DFE
	private void Update()
	{
	}

	// Token: 0x06001149 RID: 4425 RVA: 0x00087C00 File Offset: 0x00085E00
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
	private float TimeX = 1f;

	// Token: 0x040015EE RID: 5614
	private Material SCMaterial;

	// Token: 0x040015EF RID: 5615
	[Range(0.0001f, 1f)]
	public float Fade = 0.01f;
}
