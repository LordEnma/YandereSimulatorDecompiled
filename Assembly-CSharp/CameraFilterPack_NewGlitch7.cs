using System;
using UnityEngine;

// Token: 0x020001E9 RID: 489
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Glitch Drawing")]
public class CameraFilterPack_NewGlitch7 : MonoBehaviour
{
	// Token: 0x170002EE RID: 750
	// (get) Token: 0x06001054 RID: 4180 RVA: 0x00082926 File Offset: 0x00080B26
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

	// Token: 0x06001055 RID: 4181 RVA: 0x0008295A File Offset: 0x00080B5A
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch7");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001056 RID: 4182 RVA: 0x0008297C File Offset: 0x00080B7C
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

	// Token: 0x06001057 RID: 4183 RVA: 0x00082A5E File Offset: 0x00080C5E
	private void Update()
	{
	}

	// Token: 0x06001058 RID: 4184 RVA: 0x00082A60 File Offset: 0x00080C60
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014C4 RID: 5316
	public Shader SCShader;

	// Token: 0x040014C5 RID: 5317
	private float TimeX = 1f;

	// Token: 0x040014C6 RID: 5318
	private Material SCMaterial;

	// Token: 0x040014C7 RID: 5319
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014C8 RID: 5320
	[Range(0f, 1f)]
	public float _LightMin;

	// Token: 0x040014C9 RID: 5321
	[Range(0f, 1f)]
	public float _LightMax = 1f;
}
