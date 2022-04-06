using System;
using UnityEngine;

// Token: 0x02000160 RID: 352
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/GrayScale")]
public class CameraFilterPack_Color_GrayScale : MonoBehaviour
{
	// Token: 0x17000264 RID: 612
	// (get) Token: 0x06000CFF RID: 3327 RVA: 0x000749F4 File Offset: 0x00072BF4
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

	// Token: 0x06000D00 RID: 3328 RVA: 0x00074A28 File Offset: 0x00072C28
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_GrayScale");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D01 RID: 3329 RVA: 0x00074A4C File Offset: 0x00072C4C
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
			this.material.SetFloat("_Fade", this._Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D02 RID: 3330 RVA: 0x00074B02 File Offset: 0x00072D02
	private void Update()
	{
	}

	// Token: 0x06000D03 RID: 3331 RVA: 0x00074B04 File Offset: 0x00072D04
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400115E RID: 4446
	public Shader SCShader;

	// Token: 0x0400115F RID: 4447
	private float TimeX = 1f;

	// Token: 0x04001160 RID: 4448
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x04001161 RID: 4449
	private Material SCMaterial;
}
