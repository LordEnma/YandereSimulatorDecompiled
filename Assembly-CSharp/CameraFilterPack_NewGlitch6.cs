using System;
using UnityEngine;

// Token: 0x020001E8 RID: 488
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch6")]
public class CameraFilterPack_NewGlitch6 : MonoBehaviour
{
	// Token: 0x170002ED RID: 749
	// (get) Token: 0x0600104E RID: 4174 RVA: 0x0008279F File Offset: 0x0008099F
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

	// Token: 0x0600104F RID: 4175 RVA: 0x000827D3 File Offset: 0x000809D3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch6");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001050 RID: 4176 RVA: 0x000827F4 File Offset: 0x000809F4
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
			this.material.SetFloat("_Speed", this.__Speed);
			this.material.SetFloat("FadeLight", this._FadeLight);
			this.material.SetFloat("FadeDark", this._FadeDark);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001051 RID: 4177 RVA: 0x000828D6 File Offset: 0x00080AD6
	private void Update()
	{
	}

	// Token: 0x06001052 RID: 4178 RVA: 0x000828D8 File Offset: 0x00080AD8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014BE RID: 5310
	public Shader SCShader;

	// Token: 0x040014BF RID: 5311
	private float TimeX = 1f;

	// Token: 0x040014C0 RID: 5312
	private Material SCMaterial;

	// Token: 0x040014C1 RID: 5313
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014C2 RID: 5314
	[Range(0f, 1f)]
	public float _FadeLight = 1f;

	// Token: 0x040014C3 RID: 5315
	[Range(0f, 1f)]
	public float _FadeDark = 1f;
}
