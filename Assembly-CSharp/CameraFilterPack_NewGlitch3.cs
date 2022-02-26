using System;
using UnityEngine;

// Token: 0x020001E6 RID: 486
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch3")]
public class CameraFilterPack_NewGlitch3 : MonoBehaviour
{
	// Token: 0x170002EA RID: 746
	// (get) Token: 0x06001040 RID: 4160 RVA: 0x00082711 File Offset: 0x00080911
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

	// Token: 0x06001041 RID: 4161 RVA: 0x00082745 File Offset: 0x00080945
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001042 RID: 4162 RVA: 0x00082768 File Offset: 0x00080968
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

	// Token: 0x06001043 RID: 4163 RVA: 0x00082834 File Offset: 0x00080A34
	private void Update()
	{
	}

	// Token: 0x06001044 RID: 4164 RVA: 0x00082836 File Offset: 0x00080A36
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014B2 RID: 5298
	public Shader SCShader;

	// Token: 0x040014B3 RID: 5299
	private float TimeX = 1f;

	// Token: 0x040014B4 RID: 5300
	private Material SCMaterial;

	// Token: 0x040014B5 RID: 5301
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014B6 RID: 5302
	[Range(0f, 1f)]
	public float _RedFade = 1f;
}
