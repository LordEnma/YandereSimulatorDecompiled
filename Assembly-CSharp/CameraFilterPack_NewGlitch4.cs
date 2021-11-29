using System;
using UnityEngine;

// Token: 0x020001E6 RID: 486
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch4")]
public class CameraFilterPack_NewGlitch4 : MonoBehaviour
{
	// Token: 0x170002EB RID: 747
	// (get) Token: 0x06001042 RID: 4162 RVA: 0x0008241D File Offset: 0x0008061D
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

	// Token: 0x06001043 RID: 4163 RVA: 0x00082451 File Offset: 0x00080651
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch4");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001044 RID: 4164 RVA: 0x00082474 File Offset: 0x00080674
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001045 RID: 4165 RVA: 0x00082540 File Offset: 0x00080740
	private void Update()
	{
	}

	// Token: 0x06001046 RID: 4166 RVA: 0x00082542 File Offset: 0x00080742
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014AF RID: 5295
	public Shader SCShader;

	// Token: 0x040014B0 RID: 5296
	private float TimeX = 1f;

	// Token: 0x040014B1 RID: 5297
	private Material SCMaterial;

	// Token: 0x040014B2 RID: 5298
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014B3 RID: 5299
	[Range(0f, 1f)]
	public float _Fade = 1f;
}
