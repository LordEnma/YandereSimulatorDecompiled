using System;
using UnityEngine;

// Token: 0x0200020F RID: 527
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Movie Noise")]
public class CameraFilterPack_TV_MovieNoise : MonoBehaviour
{
	// Token: 0x17000314 RID: 788
	// (get) Token: 0x0600113F RID: 4415 RVA: 0x000870D0 File Offset: 0x000852D0
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

	// Token: 0x06001140 RID: 4416 RVA: 0x00087104 File Offset: 0x00085304
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_MovieNoise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001141 RID: 4417 RVA: 0x00087128 File Offset: 0x00085328
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

	// Token: 0x06001142 RID: 4418 RVA: 0x000871DE File Offset: 0x000853DE
	private void Update()
	{
	}

	// Token: 0x06001143 RID: 4419 RVA: 0x000871E0 File Offset: 0x000853E0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015D4 RID: 5588
	public Shader SCShader;

	// Token: 0x040015D5 RID: 5589
	private float TimeX = 1f;

	// Token: 0x040015D6 RID: 5590
	private Material SCMaterial;

	// Token: 0x040015D7 RID: 5591
	[Range(0.0001f, 1f)]
	public float Fade = 0.01f;
}
