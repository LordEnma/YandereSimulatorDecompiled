using System;
using UnityEngine;

// Token: 0x020001F9 RID: 505
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixelisation/OilPaint")]
public class CameraFilterPack_Pixelisation_OilPaint : MonoBehaviour
{
	// Token: 0x170002FE RID: 766
	// (get) Token: 0x060010BA RID: 4282 RVA: 0x00084AF7 File Offset: 0x00082CF7
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

	// Token: 0x060010BB RID: 4283 RVA: 0x00084B2B File Offset: 0x00082D2B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Pixelisation_OilPaint");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010BC RID: 4284 RVA: 0x00084B4C File Offset: 0x00082D4C
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetFloat("_Value", this.Value);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010BD RID: 4285 RVA: 0x00084C02 File Offset: 0x00082E02
	private void Update()
	{
	}

	// Token: 0x060010BE RID: 4286 RVA: 0x00084C04 File Offset: 0x00082E04
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001544 RID: 5444
	public Shader SCShader;

	// Token: 0x04001545 RID: 5445
	private float TimeX = 1f;

	// Token: 0x04001546 RID: 5446
	private Material SCMaterial;

	// Token: 0x04001547 RID: 5447
	[Range(0f, 5f)]
	public float Value = 1f;
}
