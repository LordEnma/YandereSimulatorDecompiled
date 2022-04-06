using System;
using UnityEngine;

// Token: 0x020001FC RID: 508
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixelisation/Pixelisation_Sweater")]
public class CameraFilterPack_Pixelisation_Sweater : MonoBehaviour
{
	// Token: 0x17000300 RID: 768
	// (get) Token: 0x060010CC RID: 4300 RVA: 0x000857A4 File Offset: 0x000839A4
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

	// Token: 0x060010CD RID: 4301 RVA: 0x000857D8 File Offset: 0x000839D8
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

	// Token: 0x060010CE RID: 4302 RVA: 0x00085810 File Offset: 0x00083A10
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

	// Token: 0x060010CF RID: 4303 RVA: 0x000858DB File Offset: 0x00083ADB
	private void Update()
	{
	}

	// Token: 0x060010D0 RID: 4304 RVA: 0x000858DD File Offset: 0x00083ADD
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001564 RID: 5476
	public Shader SCShader;

	// Token: 0x04001565 RID: 5477
	private float TimeX = 1f;

	// Token: 0x04001566 RID: 5478
	private Material SCMaterial;

	// Token: 0x04001567 RID: 5479
	[Range(16f, 128f)]
	public float SweaterSize = 64f;

	// Token: 0x04001568 RID: 5480
	[Range(0f, 2f)]
	public float _Intensity = 1.4f;

	// Token: 0x04001569 RID: 5481
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x0400156A RID: 5482
	private Texture2D Texture2;
}
