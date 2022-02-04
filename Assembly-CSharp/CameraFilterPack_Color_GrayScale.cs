using System;
using UnityEngine;

// Token: 0x02000160 RID: 352
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/GrayScale")]
public class CameraFilterPack_Color_GrayScale : MonoBehaviour
{
	// Token: 0x17000264 RID: 612
	// (get) Token: 0x06000CFC RID: 3324 RVA: 0x000741CC File Offset: 0x000723CC
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

	// Token: 0x06000CFD RID: 3325 RVA: 0x00074200 File Offset: 0x00072400
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_GrayScale");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CFE RID: 3326 RVA: 0x00074224 File Offset: 0x00072424
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

	// Token: 0x06000CFF RID: 3327 RVA: 0x000742DA File Offset: 0x000724DA
	private void Update()
	{
	}

	// Token: 0x06000D00 RID: 3328 RVA: 0x000742DC File Offset: 0x000724DC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400114B RID: 4427
	public Shader SCShader;

	// Token: 0x0400114C RID: 4428
	private float TimeX = 1f;

	// Token: 0x0400114D RID: 4429
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x0400114E RID: 4430
	private Material SCMaterial;
}
