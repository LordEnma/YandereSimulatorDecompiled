﻿using System;
using UnityEngine;

// Token: 0x0200018A RID: 394
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Curve")]
public class CameraFilterPack_Drawing_Curve : MonoBehaviour
{
	// Token: 0x1700028F RID: 655
	// (get) Token: 0x06000DFD RID: 3581 RVA: 0x000782EC File Offset: 0x000764EC
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

	// Token: 0x06000DFE RID: 3582 RVA: 0x00078320 File Offset: 0x00076520
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Curve");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DFF RID: 3583 RVA: 0x00078344 File Offset: 0x00076544
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
			this.material.SetFloat("_Value", this.Size);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E00 RID: 3584 RVA: 0x000783FA File Offset: 0x000765FA
	private void Update()
	{
	}

	// Token: 0x06000E01 RID: 3585 RVA: 0x000783FC File Offset: 0x000765FC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400123E RID: 4670
	public Shader SCShader;

	// Token: 0x0400123F RID: 4671
	private float TimeX = 1f;

	// Token: 0x04001240 RID: 4672
	private Material SCMaterial;

	// Token: 0x04001241 RID: 4673
	[Range(3f, 5f)]
	public float Size = 1f;
}