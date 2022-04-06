using System;
using UnityEngine;

// Token: 0x02000166 RID: 358
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Color_YUV")]
public class CameraFilterPack_Color_YUV : MonoBehaviour
{
	// Token: 0x1700026A RID: 618
	// (get) Token: 0x06000D23 RID: 3363 RVA: 0x000751AD File Offset: 0x000733AD
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

	// Token: 0x06000D24 RID: 3364 RVA: 0x000751E1 File Offset: 0x000733E1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_YUV");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D25 RID: 3365 RVA: 0x00075204 File Offset: 0x00073404
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
			this.material.SetFloat("_Y", this._Y);
			this.material.SetFloat("_U", this._U);
			this.material.SetFloat("_V", this._V);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D26 RID: 3366 RVA: 0x000752E6 File Offset: 0x000734E6
	private void Update()
	{
	}

	// Token: 0x06000D27 RID: 3367 RVA: 0x000752E8 File Offset: 0x000734E8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001176 RID: 4470
	public Shader SCShader;

	// Token: 0x04001177 RID: 4471
	private float TimeX = 1f;

	// Token: 0x04001178 RID: 4472
	private Material SCMaterial;

	// Token: 0x04001179 RID: 4473
	[Range(-1f, 1f)]
	public float _Y;

	// Token: 0x0400117A RID: 4474
	[Range(-1f, 1f)]
	public float _U;

	// Token: 0x0400117B RID: 4475
	[Range(-1f, 1f)]
	public float _V;
}
