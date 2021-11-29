using System;
using UnityEngine;

// Token: 0x020001E4 RID: 484
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch2")]
public class CameraFilterPack_NewGlitch2 : MonoBehaviour
{
	// Token: 0x170002E9 RID: 745
	// (get) Token: 0x06001036 RID: 4150 RVA: 0x0008214D File Offset: 0x0008034D
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

	// Token: 0x06001037 RID: 4151 RVA: 0x00082181 File Offset: 0x00080381
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001038 RID: 4152 RVA: 0x000821A4 File Offset: 0x000803A4
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

	// Token: 0x06001039 RID: 4153 RVA: 0x00082270 File Offset: 0x00080470
	private void Update()
	{
	}

	// Token: 0x0600103A RID: 4154 RVA: 0x00082272 File Offset: 0x00080472
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014A5 RID: 5285
	public Shader SCShader;

	// Token: 0x040014A6 RID: 5286
	private float TimeX = 1f;

	// Token: 0x040014A7 RID: 5287
	private Material SCMaterial;

	// Token: 0x040014A8 RID: 5288
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014A9 RID: 5289
	[Range(0f, 1f)]
	public float _RedFade = 1f;
}
