using System;
using UnityEngine;

// Token: 0x0200016C RID: 364
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/HSV")]
public class CameraFilterPack_Colors_HSV : MonoBehaviour
{
	// Token: 0x17000271 RID: 625
	// (get) Token: 0x06000D49 RID: 3401 RVA: 0x000757CB File Offset: 0x000739CB
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

	// Token: 0x06000D4A RID: 3402 RVA: 0x000757FF File Offset: 0x000739FF
	private void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D4B RID: 3403 RVA: 0x00075810 File Offset: 0x00073A10
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

	// Token: 0x06000D4C RID: 3404 RVA: 0x00075882 File Offset: 0x00073A82
	private void Update()
	{
	}

	// Token: 0x06000D4D RID: 3405 RVA: 0x00075884 File Offset: 0x00073A84
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400118F RID: 4495
	public Shader SCShader;

	// Token: 0x04001190 RID: 4496
	[Range(0f, 360f)]
	public float _HueShift = 180f;

	// Token: 0x04001191 RID: 4497
	[Range(-32f, 32f)]
	public float _Saturation = 1f;

	// Token: 0x04001192 RID: 4498
	[Range(-32f, 32f)]
	public float _ValueBrightness = 1f;

	// Token: 0x04001193 RID: 4499
	private Material SCMaterial;
}
