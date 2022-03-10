using System;
using UnityEngine;

// Token: 0x020001E8 RID: 488
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch5")]
public class CameraFilterPack_NewGlitch5 : MonoBehaviour
{
	// Token: 0x170002EC RID: 748
	// (get) Token: 0x0600104C RID: 4172 RVA: 0x00082B29 File Offset: 0x00080D29
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

	// Token: 0x0600104D RID: 4173 RVA: 0x00082B5D File Offset: 0x00080D5D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch5");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600104E RID: 4174 RVA: 0x00082B80 File Offset: 0x00080D80
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

	// Token: 0x0600104F RID: 4175 RVA: 0x00082CBA File Offset: 0x00080EBA
	private void Update()
	{
	}

	// Token: 0x06001050 RID: 4176 RVA: 0x00082CBC File Offset: 0x00080EBC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014C5 RID: 5317
	public Shader SCShader;

	// Token: 0x040014C6 RID: 5318
	private float TimeX = 1f;

	// Token: 0x040014C7 RID: 5319
	private Material SCMaterial;

	// Token: 0x040014C8 RID: 5320
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014C9 RID: 5321
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x040014CA RID: 5322
	[Range(0f, 1f)]
	public float _Parasite = 1f;

	// Token: 0x040014CB RID: 5323
	[Range(0f, 0f)]
	public float _ZoomX = 1f;

	// Token: 0x040014CC RID: 5324
	[Range(0f, 0f)]
	public float _ZoomY = 1f;

	// Token: 0x040014CD RID: 5325
	[Range(0f, 0f)]
	public float _PosX = 1f;

	// Token: 0x040014CE RID: 5326
	[Range(0f, 0f)]
	public float _PosY = 1f;
}
