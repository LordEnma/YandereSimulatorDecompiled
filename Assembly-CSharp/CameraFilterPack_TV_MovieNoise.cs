using System;
using UnityEngine;

// Token: 0x02000210 RID: 528
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Movie Noise")]
public class CameraFilterPack_TV_MovieNoise : MonoBehaviour
{
	// Token: 0x17000314 RID: 788
	// (get) Token: 0x06001142 RID: 4418 RVA: 0x000872C8 File Offset: 0x000854C8
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

	// Token: 0x06001143 RID: 4419 RVA: 0x000872FC File Offset: 0x000854FC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_MovieNoise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001144 RID: 4420 RVA: 0x00087320 File Offset: 0x00085520
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

	// Token: 0x06001145 RID: 4421 RVA: 0x000873D6 File Offset: 0x000855D6
	private void Update()
	{
	}

	// Token: 0x06001146 RID: 4422 RVA: 0x000873D8 File Offset: 0x000855D8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015D9 RID: 5593
	public Shader SCShader;

	// Token: 0x040015DA RID: 5594
	private float TimeX = 1f;

	// Token: 0x040015DB RID: 5595
	private Material SCMaterial;

	// Token: 0x040015DC RID: 5596
	[Range(0.0001f, 1f)]
	public float Fade = 0.01f;
}
