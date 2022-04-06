using System;
using UnityEngine;

// Token: 0x020001E8 RID: 488
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch5")]
public class CameraFilterPack_NewGlitch5 : MonoBehaviour
{
	// Token: 0x170002EC RID: 748
	// (get) Token: 0x0600104E RID: 4174 RVA: 0x00082FA5 File Offset: 0x000811A5
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

	// Token: 0x0600104F RID: 4175 RVA: 0x00082FD9 File Offset: 0x000811D9
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch5");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001050 RID: 4176 RVA: 0x00082FFC File Offset: 0x000811FC
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
			this.material.SetFloat("Fade", this._Fade);
			this.material.SetFloat("Parasite", this._Parasite);
			this.material.SetFloat("ZoomX", this._ZoomX);
			this.material.SetFloat("ZoomY", this._ZoomY);
			this.material.SetFloat("PosX", this._PosX);
			this.material.SetFloat("PosY", this._PosY);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001051 RID: 4177 RVA: 0x00083136 File Offset: 0x00081336
	private void Update()
	{
	}

	// Token: 0x06001052 RID: 4178 RVA: 0x00083138 File Offset: 0x00081338
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
	public float _Fade = 1f;

	// Token: 0x040014D1 RID: 5329
	[Range(0f, 1f)]
	public float _Parasite = 1f;

	// Token: 0x040014D2 RID: 5330
	[Range(0f, 0f)]
	public float _ZoomX = 1f;

	// Token: 0x040014D3 RID: 5331
	[Range(0f, 0f)]
	public float _ZoomY = 1f;

	// Token: 0x040014D4 RID: 5332
	[Range(0f, 0f)]
	public float _PosX = 1f;

	// Token: 0x040014D5 RID: 5333
	[Range(0f, 0f)]
	public float _PosY = 1f;
}
