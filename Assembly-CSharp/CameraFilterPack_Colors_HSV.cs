using System;
using UnityEngine;

// Token: 0x0200016D RID: 365
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/HSV")]
public class CameraFilterPack_Colors_HSV : MonoBehaviour
{
	// Token: 0x17000271 RID: 625
	// (get) Token: 0x06000D4F RID: 3407 RVA: 0x000761EB File Offset: 0x000743EB
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

	// Token: 0x06000D50 RID: 3408 RVA: 0x0007621F File Offset: 0x0007441F
	private void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D51 RID: 3409 RVA: 0x00076230 File Offset: 0x00074430
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

	// Token: 0x06000D52 RID: 3410 RVA: 0x000762A2 File Offset: 0x000744A2
	private void Update()
	{
	}

	// Token: 0x06000D53 RID: 3411 RVA: 0x000762A4 File Offset: 0x000744A4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011A7 RID: 4519
	public Shader SCShader;

	// Token: 0x040011A8 RID: 4520
	[Range(0f, 360f)]
	public float _HueShift = 180f;

	// Token: 0x040011A9 RID: 4521
	[Range(-32f, 32f)]
	public float _Saturation = 1f;

	// Token: 0x040011AA RID: 4522
	[Range(-32f, 32f)]
	public float _ValueBrightness = 1f;

	// Token: 0x040011AB RID: 4523
	private Material SCMaterial;
}
