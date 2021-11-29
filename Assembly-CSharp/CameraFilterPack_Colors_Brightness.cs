using System;
using UnityEngine;

// Token: 0x0200016A RID: 362
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Brightness")]
public class CameraFilterPack_Colors_Brightness : MonoBehaviour
{
	// Token: 0x1700026F RID: 623
	// (get) Token: 0x06000D3D RID: 3389 RVA: 0x00075564 File Offset: 0x00073764
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

	// Token: 0x06000D3E RID: 3390 RVA: 0x00075598 File Offset: 0x00073798
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_Brightness");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D3F RID: 3391 RVA: 0x000755B9 File Offset: 0x000737B9
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

	// Token: 0x06000D40 RID: 3392 RVA: 0x000755F4 File Offset: 0x000737F4
	private void Update()
	{
	}

	// Token: 0x06000D41 RID: 3393 RVA: 0x000755F6 File Offset: 0x000737F6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001185 RID: 4485
	public Shader SCShader;

	// Token: 0x04001186 RID: 4486
	[Range(0f, 2f)]
	public float _Brightness = 1.5f;

	// Token: 0x04001187 RID: 4487
	private Material SCMaterial;
}
