using System;
using UnityEngine;

// Token: 0x0200014C RID: 332
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Focus")]
public class CameraFilterPack_Blur_Focus : MonoBehaviour
{
	// Token: 0x17000250 RID: 592
	// (get) Token: 0x06000C85 RID: 3205 RVA: 0x000723E5 File Offset: 0x000705E5
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

	// Token: 0x06000C86 RID: 3206 RVA: 0x00072419 File Offset: 0x00070619
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Focus");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C87 RID: 3207 RVA: 0x0007243C File Offset: 0x0007063C
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

	// Token: 0x06000C88 RID: 3208 RVA: 0x00072540 File Offset: 0x00070740
	private void Update()
	{
	}

	// Token: 0x06000C89 RID: 3209 RVA: 0x00072542 File Offset: 0x00070742
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010D6 RID: 4310
	public Shader SCShader;

	// Token: 0x040010D7 RID: 4311
	private float TimeX = 1f;

	// Token: 0x040010D8 RID: 4312
	private Material SCMaterial;

	// Token: 0x040010D9 RID: 4313
	[Range(-1f, 1f)]
	public float CenterX;

	// Token: 0x040010DA RID: 4314
	[Range(-1f, 1f)]
	public float CenterY;

	// Token: 0x040010DB RID: 4315
	[Range(0f, 10f)]
	public float _Size = 5f;

	// Token: 0x040010DC RID: 4316
	[Range(0.12f, 64f)]
	public float _Eyes = 2f;
}
