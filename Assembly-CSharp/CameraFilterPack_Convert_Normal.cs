using System;
using UnityEngine;

// Token: 0x02000171 RID: 369
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Convert/NormalMap")]
public class CameraFilterPack_Convert_Normal : MonoBehaviour
{
	// Token: 0x17000276 RID: 630
	// (get) Token: 0x06000D67 RID: 3431 RVA: 0x00075EC4 File Offset: 0x000740C4
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

	// Token: 0x06000D68 RID: 3432 RVA: 0x00075EF8 File Offset: 0x000740F8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Convert_Normal");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D69 RID: 3433 RVA: 0x00075F1C File Offset: 0x0007411C
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

	// Token: 0x06000D6A RID: 3434 RVA: 0x00075F78 File Offset: 0x00074178
	private void Update()
	{
	}

	// Token: 0x06000D6B RID: 3435 RVA: 0x00075F7A File Offset: 0x0007417A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011AE RID: 4526
	public Shader SCShader;

	// Token: 0x040011AF RID: 4527
	[Range(0f, 0.5f)]
	public float _Heigh = 0.0125f;

	// Token: 0x040011B0 RID: 4528
	[Range(0f, 0.25f)]
	public float _Intervale = 0.0025f;

	// Token: 0x040011B1 RID: 4529
	private Material SCMaterial;
}
