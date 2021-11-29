using System;
using UnityEngine;

// Token: 0x02000217 RID: 535
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Tiles")]
public class CameraFilterPack_TV_Tiles : MonoBehaviour
{
	// Token: 0x1700031C RID: 796
	// (get) Token: 0x0600116F RID: 4463 RVA: 0x00087B38 File Offset: 0x00085D38
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

	// Token: 0x06001170 RID: 4464 RVA: 0x00087B6C File Offset: 0x00085D6C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Tiles");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001171 RID: 4465 RVA: 0x00087B90 File Offset: 0x00085D90
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
			this.material.SetFloat("_Value", this.Size);
			this.material.SetFloat("_Value2", this.Intensity);
			this.material.SetFloat("_Value3", this.StretchX);
			this.material.SetFloat("_Value4", this.StretchY);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001172 RID: 4466 RVA: 0x00087C9E File Offset: 0x00085E9E
	private void Update()
	{
	}

	// Token: 0x06001173 RID: 4467 RVA: 0x00087CA0 File Offset: 0x00085EA0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015FA RID: 5626
	public Shader SCShader;

	// Token: 0x040015FB RID: 5627
	private float TimeX = 1f;

	// Token: 0x040015FC RID: 5628
	private Material SCMaterial;

	// Token: 0x040015FD RID: 5629
	[Range(0.5f, 2f)]
	public float Size = 1f;

	// Token: 0x040015FE RID: 5630
	[Range(0f, 10f)]
	public float Intensity = 4f;

	// Token: 0x040015FF RID: 5631
	[Range(0f, 1f)]
	public float StretchX = 0.6f;

	// Token: 0x04001600 RID: 5632
	[Range(0f, 1f)]
	public float StretchY = 0.4f;

	// Token: 0x04001601 RID: 5633
	[Range(0f, 1f)]
	public float Fade = 0.6f;
}
