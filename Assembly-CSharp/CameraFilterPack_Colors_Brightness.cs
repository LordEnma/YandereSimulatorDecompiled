using System;
using UnityEngine;

// Token: 0x0200016B RID: 363
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Brightness")]
public class CameraFilterPack_Colors_Brightness : MonoBehaviour
{
	// Token: 0x1700026F RID: 623
	// (get) Token: 0x06000D43 RID: 3395 RVA: 0x00075F84 File Offset: 0x00074184
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

	// Token: 0x06000D44 RID: 3396 RVA: 0x00075FB8 File Offset: 0x000741B8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_Brightness");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D45 RID: 3397 RVA: 0x00075FD9 File Offset: 0x000741D9
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.material.SetFloat("_Val", this._Brightness);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D46 RID: 3398 RVA: 0x00076014 File Offset: 0x00074214
	private void Update()
	{
	}

	// Token: 0x06000D47 RID: 3399 RVA: 0x00076016 File Offset: 0x00074216
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400119D RID: 4509
	public Shader SCShader;

	// Token: 0x0400119E RID: 4510
	[Range(0f, 2f)]
	public float _Brightness = 1.5f;

	// Token: 0x0400119F RID: 4511
	private Material SCMaterial;
}
