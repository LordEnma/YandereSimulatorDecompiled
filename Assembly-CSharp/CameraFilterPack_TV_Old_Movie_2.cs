using System;
using UnityEngine;

// Token: 0x02000213 RID: 531
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Old Film/Old_Movie_2")]
public class CameraFilterPack_TV_Old_Movie_2 : MonoBehaviour
{
	// Token: 0x17000318 RID: 792
	// (get) Token: 0x06001157 RID: 4439 RVA: 0x00087590 File Offset: 0x00085790
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

	// Token: 0x06001158 RID: 4440 RVA: 0x000875C4 File Offset: 0x000857C4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Old_Movie_2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001159 RID: 4441 RVA: 0x000875E8 File Offset: 0x000857E8
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

	// Token: 0x0600115A RID: 4442 RVA: 0x000876F6 File Offset: 0x000858F6
	private void Update()
	{
	}

	// Token: 0x0600115B RID: 4443 RVA: 0x000876F8 File Offset: 0x000858F8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015E4 RID: 5604
	public Shader SCShader;

	// Token: 0x040015E5 RID: 5605
	private float TimeX = 1f;

	// Token: 0x040015E6 RID: 5606
	private Material SCMaterial;

	// Token: 0x040015E7 RID: 5607
	[Range(1f, 60f)]
	public float FramePerSecond = 15f;

	// Token: 0x040015E8 RID: 5608
	[Range(0f, 5f)]
	public float Contrast = 1f;

	// Token: 0x040015E9 RID: 5609
	[Range(0f, 4f)]
	public float Burn;

	// Token: 0x040015EA RID: 5610
	[Range(0f, 16f)]
	public float SceneCut = 1f;

	// Token: 0x040015EB RID: 5611
	[Range(0f, 1f)]
	public float Fade = 1f;
}
