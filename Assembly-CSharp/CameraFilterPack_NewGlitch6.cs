using System;
using UnityEngine;

// Token: 0x020001E9 RID: 489
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch6")]
public class CameraFilterPack_NewGlitch6 : MonoBehaviour
{
	// Token: 0x170002ED RID: 749
	// (get) Token: 0x06001054 RID: 4180 RVA: 0x000831BF File Offset: 0x000813BF
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

	// Token: 0x06001055 RID: 4181 RVA: 0x000831F3 File Offset: 0x000813F3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch6");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001056 RID: 4182 RVA: 0x00083214 File Offset: 0x00081414
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

	// Token: 0x06001057 RID: 4183 RVA: 0x000832F6 File Offset: 0x000814F6
	private void Update()
	{
	}

	// Token: 0x06001058 RID: 4184 RVA: 0x000832F8 File Offset: 0x000814F8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014D6 RID: 5334
	public Shader SCShader;

	// Token: 0x040014D7 RID: 5335
	private float TimeX = 1f;

	// Token: 0x040014D8 RID: 5336
	private Material SCMaterial;

	// Token: 0x040014D9 RID: 5337
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014DA RID: 5338
	[Range(0f, 1f)]
	public float _FadeLight = 1f;

	// Token: 0x040014DB RID: 5339
	[Range(0f, 1f)]
	public float _FadeDark = 1f;
}
