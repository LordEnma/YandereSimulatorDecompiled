using System;
using UnityEngine;

// Token: 0x020001FD RID: 509
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/Real VHS HQ")]
public class CameraFilterPack_Real_VHS : MonoBehaviour
{
	// Token: 0x17000302 RID: 770
	// (get) Token: 0x060010D2 RID: 4306 RVA: 0x0008526D File Offset: 0x0008346D
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

	// Token: 0x060010D3 RID: 4307 RVA: 0x000852A4 File Offset: 0x000834A4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Real_VHS");
		this.VHS = (Resources.Load("CameraFilterPack_VHS1") as Texture2D);
		this.VHS2 = (Resources.Load("CameraFilterPack_VHS2") as Texture2D);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010D4 RID: 4308 RVA: 0x000852FA File Offset: 0x000834FA
	public static Texture2D GetRTPixels(Texture2D t, RenderTexture rt, int sx, int sy)
	{
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = rt;
		t.ReadPixels(new Rect(0f, 0f, (float)t.width, (float)t.height), 0, 0);
		RenderTexture.active = active;
		return t;
	}

	// Token: 0x060010D5 RID: 4309 RVA: 0x00085334 File Offset: 0x00083534
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.material.SetTexture("VHS", this.VHS);
			this.material.SetTexture("VHS2", this.VHS2);
			this.material.SetFloat("TRACKING", this.TRACKING);
			this.material.SetFloat("JITTER", this.JITTER);
			this.material.SetFloat("GLITCH", this.GLITCH);
			this.material.SetFloat("NOISE", this.NOISE);
			this.material.SetFloat("Brightness", this.Brightness);
			this.material.SetFloat("CONTRAST", 1f - this.Constrast);
			int width = 382;
			int height = 576;
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0);
			temporary.filterMode = FilterMode.Trilinear;
			Graphics.Blit(sourceTexture, temporary, this.material);
			Graphics.Blit(temporary, destTexture);
			RenderTexture.ReleaseTemporary(temporary);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010D6 RID: 4310 RVA: 0x00085444 File Offset: 0x00083644
	private void Update()
	{
	}

	// Token: 0x060010D7 RID: 4311 RVA: 0x00085446 File Offset: 0x00083646
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
	private Material SCMaterial;

	// Token: 0x0400155F RID: 5471
	private Texture2D VHS;

	// Token: 0x04001560 RID: 5472
	private Texture2D VHS2;

	// Token: 0x04001561 RID: 5473
	[Range(0f, 1f)]
	public float TRACKING = 0.212f;

	// Token: 0x04001562 RID: 5474
	[Range(0f, 1f)]
	public float JITTER = 1f;

	// Token: 0x04001563 RID: 5475
	[Range(0f, 1f)]
	public float GLITCH = 1f;

	// Token: 0x04001564 RID: 5476
	[Range(0f, 1f)]
	public float NOISE = 1f;

	// Token: 0x04001565 RID: 5477
	[Range(-1f, 1f)]
	public float Brightness;

	// Token: 0x04001566 RID: 5478
	[Range(0f, 1.5f)]
	public float Constrast = 1f;
}
