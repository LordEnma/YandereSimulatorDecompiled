using System;
using UnityEngine;

// Token: 0x0200016B RID: 363
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Brightness")]
public class CameraFilterPack_Colors_Brightness : MonoBehaviour
{
	// Token: 0x1700026F RID: 623
	// (get) Token: 0x06000D41 RID: 3393 RVA: 0x00075B08 File Offset: 0x00073D08
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

	// Token: 0x06000D42 RID: 3394 RVA: 0x00075B3C File Offset: 0x00073D3C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_Brightness");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D43 RID: 3395 RVA: 0x00075B5D File Offset: 0x00073D5D
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

	// Token: 0x06000D44 RID: 3396 RVA: 0x00075B98 File Offset: 0x00073D98
	private void Update()
	{
	}

	// Token: 0x06000D45 RID: 3397 RVA: 0x00075B9A File Offset: 0x00073D9A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001196 RID: 4502
	public Shader SCShader;

	// Token: 0x04001197 RID: 4503
	[Range(0f, 2f)]
	public float _Brightness = 1.5f;

	// Token: 0x04001198 RID: 4504
	private Material SCMaterial;
}
