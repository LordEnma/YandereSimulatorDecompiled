using System;
using UnityEngine;

// Token: 0x0200016D RID: 365
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/HSV")]
public class CameraFilterPack_Colors_HSV : MonoBehaviour
{
	// Token: 0x17000271 RID: 625
	// (get) Token: 0x06000D4D RID: 3405 RVA: 0x00075B13 File Offset: 0x00073D13
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

	// Token: 0x06000D4E RID: 3406 RVA: 0x00075B47 File Offset: 0x00073D47
	private void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D4F RID: 3407 RVA: 0x00075B58 File Offset: 0x00073D58
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

	// Token: 0x06000D50 RID: 3408 RVA: 0x00075BCA File Offset: 0x00073DCA
	private void Update()
	{
	}

	// Token: 0x06000D51 RID: 3409 RVA: 0x00075BCC File Offset: 0x00073DCC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001197 RID: 4503
	public Shader SCShader;

	// Token: 0x04001198 RID: 4504
	[Range(0f, 360f)]
	public float _HueShift = 180f;

	// Token: 0x04001199 RID: 4505
	[Range(-32f, 32f)]
	public float _Saturation = 1f;

	// Token: 0x0400119A RID: 4506
	[Range(-32f, 32f)]
	public float _ValueBrightness = 1f;

	// Token: 0x0400119B RID: 4507
	private Material SCMaterial;
}
