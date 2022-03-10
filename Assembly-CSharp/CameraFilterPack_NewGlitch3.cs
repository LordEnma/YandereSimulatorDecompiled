using System;
using UnityEngine;

// Token: 0x020001E6 RID: 486
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch3")]
public class CameraFilterPack_NewGlitch3 : MonoBehaviour
{
	// Token: 0x170002EA RID: 746
	// (get) Token: 0x06001040 RID: 4160 RVA: 0x00082859 File Offset: 0x00080A59
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

	// Token: 0x06001041 RID: 4161 RVA: 0x0008288D File Offset: 0x00080A8D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001042 RID: 4162 RVA: 0x000828B0 File Offset: 0x00080AB0
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
			this.material.SetFloat("RedFade", this._RedFade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001043 RID: 4163 RVA: 0x0008297C File Offset: 0x00080B7C
	private void Update()
	{
	}

	// Token: 0x06001044 RID: 4164 RVA: 0x0008297E File Offset: 0x00080B7E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014BB RID: 5307
	public Shader SCShader;

	// Token: 0x040014BC RID: 5308
	private float TimeX = 1f;

	// Token: 0x040014BD RID: 5309
	private Material SCMaterial;

	// Token: 0x040014BE RID: 5310
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014BF RID: 5311
	[Range(0f, 1f)]
	public float _RedFade = 1f;
}
