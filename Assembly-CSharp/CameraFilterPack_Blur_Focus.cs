using System;
using UnityEngine;

// Token: 0x0200014C RID: 332
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Focus")]
public class CameraFilterPack_Blur_Focus : MonoBehaviour
{
	// Token: 0x17000250 RID: 592
	// (get) Token: 0x06000C85 RID: 3205 RVA: 0x00072189 File Offset: 0x00070389
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

	// Token: 0x06000C86 RID: 3206 RVA: 0x000721BD File Offset: 0x000703BD
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Focus");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C87 RID: 3207 RVA: 0x000721E0 File Offset: 0x000703E0
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

	// Token: 0x06000C88 RID: 3208 RVA: 0x000722E4 File Offset: 0x000704E4
	private void Update()
	{
	}

	// Token: 0x06000C89 RID: 3209 RVA: 0x000722E6 File Offset: 0x000704E6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010CD RID: 4301
	public Shader SCShader;

	// Token: 0x040010CE RID: 4302
	private float TimeX = 1f;

	// Token: 0x040010CF RID: 4303
	private Material SCMaterial;

	// Token: 0x040010D0 RID: 4304
	[Range(-1f, 1f)]
	public float CenterX;

	// Token: 0x040010D1 RID: 4305
	[Range(-1f, 1f)]
	public float CenterY;

	// Token: 0x040010D2 RID: 4306
	[Range(0f, 10f)]
	public float _Size = 5f;

	// Token: 0x040010D3 RID: 4307
	[Range(0.12f, 64f)]
	public float _Eyes = 2f;
}
