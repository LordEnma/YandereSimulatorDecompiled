using System;
using UnityEngine;

// Token: 0x0200016D RID: 365
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/HSV")]
public class CameraFilterPack_Colors_HSV : MonoBehaviour
{
	// Token: 0x17000271 RID: 625
	// (get) Token: 0x06000D4C RID: 3404 RVA: 0x000759C3 File Offset: 0x00073BC3
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

	// Token: 0x06000D4D RID: 3405 RVA: 0x000759F7 File Offset: 0x00073BF7
	private void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D4E RID: 3406 RVA: 0x00075A08 File Offset: 0x00073C08
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.material.SetFloat("_HueShift", this._HueShift);
			this.material.SetFloat("_Sat", this._Saturation);
			this.material.SetFloat("_Val", this._ValueBrightness);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D4F RID: 3407 RVA: 0x00075A7A File Offset: 0x00073C7A
	private void Update()
	{
	}

	// Token: 0x06000D50 RID: 3408 RVA: 0x00075A7C File Offset: 0x00073C7C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001194 RID: 4500
	public Shader SCShader;

	// Token: 0x04001195 RID: 4501
	[Range(0f, 360f)]
	public float _HueShift = 180f;

	// Token: 0x04001196 RID: 4502
	[Range(-32f, 32f)]
	public float _Saturation = 1f;

	// Token: 0x04001197 RID: 4503
	[Range(-32f, 32f)]
	public float _ValueBrightness = 1f;

	// Token: 0x04001198 RID: 4504
	private Material SCMaterial;
}
