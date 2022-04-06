using System;
using UnityEngine;

// Token: 0x02000172 RID: 370
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Convert/NormalMap")]
public class CameraFilterPack_Convert_Normal : MonoBehaviour
{
	// Token: 0x17000276 RID: 630
	// (get) Token: 0x06000D6D RID: 3437 RVA: 0x000768E4 File Offset: 0x00074AE4
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

	// Token: 0x06000D6E RID: 3438 RVA: 0x00076918 File Offset: 0x00074B18
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Convert_Normal");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D6F RID: 3439 RVA: 0x0007693C File Offset: 0x00074B3C
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.material.SetFloat("_Heigh", this._Heigh);
			this.material.SetFloat("_Intervale", this._Intervale);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D70 RID: 3440 RVA: 0x00076998 File Offset: 0x00074B98
	private void Update()
	{
	}

	// Token: 0x06000D71 RID: 3441 RVA: 0x0007699A File Offset: 0x00074B9A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011C6 RID: 4550
	public Shader SCShader;

	// Token: 0x040011C7 RID: 4551
	[Range(0f, 0.5f)]
	public float _Heigh = 0.0125f;

	// Token: 0x040011C8 RID: 4552
	[Range(0f, 0.25f)]
	public float _Intervale = 0.0025f;

	// Token: 0x040011C9 RID: 4553
	private Material SCMaterial;
}
