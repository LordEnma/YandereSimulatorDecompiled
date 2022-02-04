using System;
using UnityEngine;

// Token: 0x020001E4 RID: 484
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch1")]
public class CameraFilterPack_NewGlitch1 : MonoBehaviour
{
	// Token: 0x170002E8 RID: 744
	// (get) Token: 0x06001033 RID: 4147 RVA: 0x000821DC File Offset: 0x000803DC
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

	// Token: 0x06001034 RID: 4148 RVA: 0x00082210 File Offset: 0x00080410
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch1");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001035 RID: 4149 RVA: 0x00082234 File Offset: 0x00080434
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
			this.material.SetFloat("Seed", this._Seed);
			this.material.SetFloat("Size", this._Size);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001036 RID: 4150 RVA: 0x00082300 File Offset: 0x00080500
	private void Update()
	{
	}

	// Token: 0x06001037 RID: 4151 RVA: 0x00082302 File Offset: 0x00080502
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
	public float _Seed = 1f;

	// Token: 0x040014A9 RID: 5289
	[Range(0f, 1f)]
	public float _Size = 1f;
}
