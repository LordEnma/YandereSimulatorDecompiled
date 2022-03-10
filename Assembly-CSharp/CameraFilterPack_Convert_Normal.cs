using System;
using UnityEngine;

// Token: 0x02000172 RID: 370
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Convert/NormalMap")]
public class CameraFilterPack_Convert_Normal : MonoBehaviour
{
	// Token: 0x17000276 RID: 630
	// (get) Token: 0x06000D6B RID: 3435 RVA: 0x00076468 File Offset: 0x00074668
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

	// Token: 0x06000D6C RID: 3436 RVA: 0x0007649C File Offset: 0x0007469C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Convert_Normal");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D6D RID: 3437 RVA: 0x000764C0 File Offset: 0x000746C0
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

	// Token: 0x06000D6E RID: 3438 RVA: 0x0007651C File Offset: 0x0007471C
	private void Update()
	{
	}

	// Token: 0x06000D6F RID: 3439 RVA: 0x0007651E File Offset: 0x0007471E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011BF RID: 4543
	public Shader SCShader;

	// Token: 0x040011C0 RID: 4544
	[Range(0f, 0.5f)]
	public float _Heigh = 0.0125f;

	// Token: 0x040011C1 RID: 4545
	[Range(0f, 0.25f)]
	public float _Intervale = 0.0025f;

	// Token: 0x040011C2 RID: 4546
	private Material SCMaterial;
}
