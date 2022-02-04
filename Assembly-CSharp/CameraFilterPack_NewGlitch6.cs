using System;
using UnityEngine;

// Token: 0x020001E9 RID: 489
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch6")]
public class CameraFilterPack_NewGlitch6 : MonoBehaviour
{
	// Token: 0x170002ED RID: 749
	// (get) Token: 0x06001051 RID: 4177 RVA: 0x00082997 File Offset: 0x00080B97
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

	// Token: 0x06001052 RID: 4178 RVA: 0x000829CB File Offset: 0x00080BCB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch6");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001053 RID: 4179 RVA: 0x000829EC File Offset: 0x00080BEC
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

	// Token: 0x06001054 RID: 4180 RVA: 0x00082ACE File Offset: 0x00080CCE
	private void Update()
	{
	}

	// Token: 0x06001055 RID: 4181 RVA: 0x00082AD0 File Offset: 0x00080CD0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014C3 RID: 5315
	public Shader SCShader;

	// Token: 0x040014C4 RID: 5316
	private float TimeX = 1f;

	// Token: 0x040014C5 RID: 5317
	private Material SCMaterial;

	// Token: 0x040014C6 RID: 5318
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014C7 RID: 5319
	[Range(0f, 1f)]
	public float _FadeLight = 1f;

	// Token: 0x040014C8 RID: 5320
	[Range(0f, 1f)]
	public float _FadeDark = 1f;
}
