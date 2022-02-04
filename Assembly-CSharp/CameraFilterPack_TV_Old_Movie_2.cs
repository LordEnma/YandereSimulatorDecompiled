using System;
using UnityEngine;

// Token: 0x02000214 RID: 532
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Old Film/Old_Movie_2")]
public class CameraFilterPack_TV_Old_Movie_2 : MonoBehaviour
{
	// Token: 0x17000318 RID: 792
	// (get) Token: 0x0600115A RID: 4442 RVA: 0x00087788 File Offset: 0x00085988
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

	// Token: 0x0600115B RID: 4443 RVA: 0x000877BC File Offset: 0x000859BC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Old_Movie_2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600115C RID: 4444 RVA: 0x000877E0 File Offset: 0x000859E0
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
			this.material.SetFloat("_Value", this.FramePerSecond);
			this.material.SetFloat("_Value2", this.Contrast);
			this.material.SetFloat("_Value3", this.Burn);
			this.material.SetFloat("_Value4", this.SceneCut);
			this.material.SetFloat("_Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600115D RID: 4445 RVA: 0x000878EE File Offset: 0x00085AEE
	private void Update()
	{
	}

	// Token: 0x0600115E RID: 4446 RVA: 0x000878F0 File Offset: 0x00085AF0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015E9 RID: 5609
	public Shader SCShader;

	// Token: 0x040015EA RID: 5610
	private float TimeX = 1f;

	// Token: 0x040015EB RID: 5611
	private Material SCMaterial;

	// Token: 0x040015EC RID: 5612
	[Range(1f, 60f)]
	public float FramePerSecond = 15f;

	// Token: 0x040015ED RID: 5613
	[Range(0f, 5f)]
	public float Contrast = 1f;

	// Token: 0x040015EE RID: 5614
	[Range(0f, 4f)]
	public float Burn;

	// Token: 0x040015EF RID: 5615
	[Range(0f, 16f)]
	public float SceneCut = 1f;

	// Token: 0x040015F0 RID: 5616
	[Range(0f, 1f)]
	public float Fade = 1f;
}
