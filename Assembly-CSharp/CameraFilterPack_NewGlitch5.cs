using System;
using UnityEngine;

// Token: 0x020001E8 RID: 488
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch5")]
public class CameraFilterPack_NewGlitch5 : MonoBehaviour
{
	// Token: 0x170002EC RID: 748
	// (get) Token: 0x0600104B RID: 4171 RVA: 0x0008277D File Offset: 0x0008097D
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

	// Token: 0x0600104C RID: 4172 RVA: 0x000827B1 File Offset: 0x000809B1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch5");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600104D RID: 4173 RVA: 0x000827D4 File Offset: 0x000809D4
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

	// Token: 0x0600104E RID: 4174 RVA: 0x0008290E File Offset: 0x00080B0E
	private void Update()
	{
	}

	// Token: 0x0600104F RID: 4175 RVA: 0x00082910 File Offset: 0x00080B10
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014B9 RID: 5305
	public Shader SCShader;

	// Token: 0x040014BA RID: 5306
	private float TimeX = 1f;

	// Token: 0x040014BB RID: 5307
	private Material SCMaterial;

	// Token: 0x040014BC RID: 5308
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014BD RID: 5309
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x040014BE RID: 5310
	[Range(0f, 1f)]
	public float _Parasite = 1f;

	// Token: 0x040014BF RID: 5311
	[Range(0f, 0f)]
	public float _ZoomX = 1f;

	// Token: 0x040014C0 RID: 5312
	[Range(0f, 0f)]
	public float _ZoomY = 1f;

	// Token: 0x040014C1 RID: 5313
	[Range(0f, 0f)]
	public float _PosX = 1f;

	// Token: 0x040014C2 RID: 5314
	[Range(0f, 0f)]
	public float _PosY = 1f;
}
