using System;
using UnityEngine;

// Token: 0x0200014B RID: 331
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Focus")]
public class CameraFilterPack_Blur_Focus : MonoBehaviour
{
	// Token: 0x17000250 RID: 592
	// (get) Token: 0x06000C81 RID: 3201 RVA: 0x00071E41 File Offset: 0x00070041
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

	// Token: 0x06000C82 RID: 3202 RVA: 0x00071E75 File Offset: 0x00070075
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Focus");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C83 RID: 3203 RVA: 0x00071E98 File Offset: 0x00070098
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
			this.material.SetFloat("_CenterX", this.CenterX);
			this.material.SetFloat("_CenterY", this.CenterY);
			float value = Mathf.Round(this._Size / 0.2f) * 0.2f;
			this.material.SetFloat("_Size", value);
			this.material.SetFloat("_Circle", this._Eyes);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C84 RID: 3204 RVA: 0x00071F9C File Offset: 0x0007019C
	private void Update()
	{
	}

	// Token: 0x06000C85 RID: 3205 RVA: 0x00071F9E File Offset: 0x0007019E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010C5 RID: 4293
	public Shader SCShader;

	// Token: 0x040010C6 RID: 4294
	private float TimeX = 1f;

	// Token: 0x040010C7 RID: 4295
	private Material SCMaterial;

	// Token: 0x040010C8 RID: 4296
	[Range(-1f, 1f)]
	public float CenterX;

	// Token: 0x040010C9 RID: 4297
	[Range(-1f, 1f)]
	public float CenterY;

	// Token: 0x040010CA RID: 4298
	[Range(0f, 10f)]
	public float _Size = 5f;

	// Token: 0x040010CB RID: 4299
	[Range(0.12f, 64f)]
	public float _Eyes = 2f;
}
