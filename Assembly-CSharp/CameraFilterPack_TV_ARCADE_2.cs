using System;
using UnityEngine;

// Token: 0x02000205 RID: 517
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/ARCADE_2")]
public class CameraFilterPack_TV_ARCADE_2 : MonoBehaviour
{
	// Token: 0x17000309 RID: 777
	// (get) Token: 0x06001103 RID: 4355 RVA: 0x000866EC File Offset: 0x000848EC
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

	// Token: 0x06001104 RID: 4356 RVA: 0x00086720 File Offset: 0x00084920
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_ARCADE_2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001105 RID: 4357 RVA: 0x00086744 File Offset: 0x00084944
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
			this.material.SetFloat("_Value", this.Interferance_Size);
			this.material.SetFloat("_Value2", this.Interferance_Speed);
			this.material.SetFloat("_Value3", this.Contrast);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001106 RID: 4358 RVA: 0x0008683C File Offset: 0x00084A3C
	private void Update()
	{
	}

	// Token: 0x06001107 RID: 4359 RVA: 0x0008683E File Offset: 0x00084A3E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400159B RID: 5531
	public Shader SCShader;

	// Token: 0x0400159C RID: 5532
	private float TimeX = 1f;

	// Token: 0x0400159D RID: 5533
	private Material SCMaterial;

	// Token: 0x0400159E RID: 5534
	[Range(0f, 10f)]
	public float Interferance_Size = 1f;

	// Token: 0x0400159F RID: 5535
	[Range(0f, 10f)]
	public float Interferance_Speed = 0.5f;

	// Token: 0x040015A0 RID: 5536
	[Range(0f, 10f)]
	public float Contrast = 1f;

	// Token: 0x040015A1 RID: 5537
	[Range(0f, 1f)]
	public float Fade = 1f;
}
