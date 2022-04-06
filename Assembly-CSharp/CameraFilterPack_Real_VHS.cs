using System;
using UnityEngine;

// Token: 0x020001FE RID: 510
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/Real VHS HQ")]
public class CameraFilterPack_Real_VHS : MonoBehaviour
{
	// Token: 0x17000302 RID: 770
	// (get) Token: 0x060010D8 RID: 4312 RVA: 0x00085C8D File Offset: 0x00083E8D
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

	// Token: 0x060010D9 RID: 4313 RVA: 0x00085CC4 File Offset: 0x00083EC4
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

	// Token: 0x060010DA RID: 4314 RVA: 0x00085D1A File Offset: 0x00083F1A
	public static Texture2D GetRTPixels(Texture2D t, RenderTexture rt, int sx, int sy)
	{
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = rt;
		t.ReadPixels(new Rect(0f, 0f, (float)t.width, (float)t.height), 0, 0);
		RenderTexture.active = active;
		return t;
	}

	// Token: 0x060010DB RID: 4315 RVA: 0x00085D54 File Offset: 0x00083F54
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

	// Token: 0x060010DC RID: 4316 RVA: 0x00085E64 File Offset: 0x00084064
	private void Update()
	{
	}

	// Token: 0x060010DD RID: 4317 RVA: 0x00085E66 File Offset: 0x00084066
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001575 RID: 5493
	public Shader SCShader;

	// Token: 0x04001576 RID: 5494
	private Material SCMaterial;

	// Token: 0x04001577 RID: 5495
	private Texture2D VHS;

	// Token: 0x04001578 RID: 5496
	private Texture2D VHS2;

	// Token: 0x04001579 RID: 5497
	[Range(0f, 1f)]
	public float TRACKING = 0.212f;

	// Token: 0x0400157A RID: 5498
	[Range(0f, 1f)]
	public float JITTER = 1f;

	// Token: 0x0400157B RID: 5499
	[Range(0f, 1f)]
	public float GLITCH = 1f;

	// Token: 0x0400157C RID: 5500
	[Range(0f, 1f)]
	public float NOISE = 1f;

	// Token: 0x0400157D RID: 5501
	[Range(-1f, 1f)]
	public float Brightness;

	// Token: 0x0400157E RID: 5502
	[Range(0f, 1.5f)]
	public float Constrast = 1f;
}
