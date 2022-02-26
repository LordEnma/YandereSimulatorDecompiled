using System;
using UnityEngine;

// Token: 0x020001EA RID: 490
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Glitch Drawing")]
public class CameraFilterPack_NewGlitch7 : MonoBehaviour
{
	// Token: 0x170002EE RID: 750
	// (get) Token: 0x06001058 RID: 4184 RVA: 0x00082D82 File Offset: 0x00080F82
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

	// Token: 0x06001059 RID: 4185 RVA: 0x00082DB6 File Offset: 0x00080FB6
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch7");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600105A RID: 4186 RVA: 0x00082DD8 File Offset: 0x00080FD8
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
			this.material.SetFloat("LightMin", this._LightMin);
			this.material.SetFloat("LightMax", this._LightMax);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600105B RID: 4187 RVA: 0x00082EBA File Offset: 0x000810BA
	private void Update()
	{
	}

	// Token: 0x0600105C RID: 4188 RVA: 0x00082EBC File Offset: 0x000810BC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014CC RID: 5324
	public Shader SCShader;

	// Token: 0x040014CD RID: 5325
	private float TimeX = 1f;

	// Token: 0x040014CE RID: 5326
	private Material SCMaterial;

	// Token: 0x040014CF RID: 5327
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014D0 RID: 5328
	[Range(0f, 1f)]
	public float _LightMin;

	// Token: 0x040014D1 RID: 5329
	[Range(0f, 1f)]
	public float _LightMax = 1f;
}
