using System;
using UnityEngine;

// Token: 0x020001FC RID: 508
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixelisation/Pixelisation_Sweater")]
public class CameraFilterPack_Pixelisation_Sweater : MonoBehaviour
{
	// Token: 0x17000300 RID: 768
	// (get) Token: 0x060010CA RID: 4298 RVA: 0x00085328 File Offset: 0x00083528
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

	// Token: 0x060010CB RID: 4299 RVA: 0x0008535C File Offset: 0x0008355C
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Sweater") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Pixelisation_Sweater");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010CC RID: 4300 RVA: 0x00085394 File Offset: 0x00083594
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
			this.material.SetFloat("_SweaterSize", this.SweaterSize);
			this.material.SetFloat("_Intensity", this._Intensity);
			this.material.SetTexture("Texture2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010CD RID: 4301 RVA: 0x0008545F File Offset: 0x0008365F
	private void Update()
	{
	}

	// Token: 0x060010CE RID: 4302 RVA: 0x00085461 File Offset: 0x00083661
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400155D RID: 5469
	public Shader SCShader;

	// Token: 0x0400155E RID: 5470
	private float TimeX = 1f;

	// Token: 0x0400155F RID: 5471
	private Material SCMaterial;

	// Token: 0x04001560 RID: 5472
	[Range(16f, 128f)]
	public float SweaterSize = 64f;

	// Token: 0x04001561 RID: 5473
	[Range(0f, 2f)]
	public float _Intensity = 1.4f;

	// Token: 0x04001562 RID: 5474
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001563 RID: 5475
	private Texture2D Texture2;
}
