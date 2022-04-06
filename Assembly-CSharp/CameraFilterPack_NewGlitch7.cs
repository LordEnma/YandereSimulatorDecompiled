using System;
using UnityEngine;

// Token: 0x020001EA RID: 490
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Glitch Drawing")]
public class CameraFilterPack_NewGlitch7 : MonoBehaviour
{
	// Token: 0x170002EE RID: 750
	// (get) Token: 0x0600105A RID: 4186 RVA: 0x00083346 File Offset: 0x00081546
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

	// Token: 0x0600105B RID: 4187 RVA: 0x0008337A File Offset: 0x0008157A
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch7");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600105C RID: 4188 RVA: 0x0008339C File Offset: 0x0008159C
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

	// Token: 0x0600105D RID: 4189 RVA: 0x0008347E File Offset: 0x0008167E
	private void Update()
	{
	}

	// Token: 0x0600105E RID: 4190 RVA: 0x00083480 File Offset: 0x00081680
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014DC RID: 5340
	public Shader SCShader;

	// Token: 0x040014DD RID: 5341
	private float TimeX = 1f;

	// Token: 0x040014DE RID: 5342
	private Material SCMaterial;

	// Token: 0x040014DF RID: 5343
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014E0 RID: 5344
	[Range(0f, 1f)]
	public float _LightMin;

	// Token: 0x040014E1 RID: 5345
	[Range(0f, 1f)]
	public float _LightMax = 1f;
}
