using System;
using UnityEngine;

// Token: 0x02000214 RID: 532
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Old Film/Old_Movie_2")]
public class CameraFilterPack_TV_Old_Movie_2 : MonoBehaviour
{
	// Token: 0x17000318 RID: 792
	// (get) Token: 0x0600115D RID: 4445 RVA: 0x00087FB0 File Offset: 0x000861B0
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

	// Token: 0x0600115E RID: 4446 RVA: 0x00087FE4 File Offset: 0x000861E4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Old_Movie_2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600115F RID: 4447 RVA: 0x00088008 File Offset: 0x00086208
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

	// Token: 0x06001160 RID: 4448 RVA: 0x00088116 File Offset: 0x00086316
	private void Update()
	{
	}

	// Token: 0x06001161 RID: 4449 RVA: 0x00088118 File Offset: 0x00086318
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015FC RID: 5628
	public Shader SCShader;

	// Token: 0x040015FD RID: 5629
	private float TimeX = 1f;

	// Token: 0x040015FE RID: 5630
	private Material SCMaterial;

	// Token: 0x040015FF RID: 5631
	[Range(1f, 60f)]
	public float FramePerSecond = 15f;

	// Token: 0x04001600 RID: 5632
	[Range(0f, 5f)]
	public float Contrast = 1f;

	// Token: 0x04001601 RID: 5633
	[Range(0f, 4f)]
	public float Burn;

	// Token: 0x04001602 RID: 5634
	[Range(0f, 16f)]
	public float SceneCut = 1f;

	// Token: 0x04001603 RID: 5635
	[Range(0f, 1f)]
	public float Fade = 1f;
}
