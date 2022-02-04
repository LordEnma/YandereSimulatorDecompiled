using System;
using UnityEngine;

// Token: 0x0200020F RID: 527
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/LED")]
public class CameraFilterPack_TV_LED : MonoBehaviour
{
	// Token: 0x17000313 RID: 787
	// (get) Token: 0x0600113C RID: 4412 RVA: 0x0008714F File Offset: 0x0008534F
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

	// Token: 0x0600113D RID: 4413 RVA: 0x00087183 File Offset: 0x00085383
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_LED");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600113E RID: 4414 RVA: 0x000871A4 File Offset: 0x000853A4
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
			this.material.SetFloat("_Size", (float)this.Size);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600113F RID: 4415 RVA: 0x00087287 File Offset: 0x00085487
	private void Update()
	{
	}

	// Token: 0x06001140 RID: 4416 RVA: 0x00087289 File Offset: 0x00085489
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015D3 RID: 5587
	public Shader SCShader;

	// Token: 0x040015D4 RID: 5588
	private float TimeX = 1f;

	// Token: 0x040015D5 RID: 5589
	[Range(0f, 1f)]
	public float Fade;

	// Token: 0x040015D6 RID: 5590
	[Range(1f, 10f)]
	private float Distortion = 1f;

	// Token: 0x040015D7 RID: 5591
	[Range(1f, 15f)]
	public int Size = 5;

	// Token: 0x040015D8 RID: 5592
	private Material SCMaterial;
}
