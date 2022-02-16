using System;
using UnityEngine;

// Token: 0x020001FA RID: 506
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixelisation/OilPaint")]
public class CameraFilterPack_Pixelisation_OilPaint : MonoBehaviour
{
	// Token: 0x170002FE RID: 766
	// (get) Token: 0x060010BE RID: 4286 RVA: 0x00084E3F File Offset: 0x0008303F
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

	// Token: 0x060010BF RID: 4287 RVA: 0x00084E73 File Offset: 0x00083073
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Pixelisation_OilPaint");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010C0 RID: 4288 RVA: 0x00084E94 File Offset: 0x00083094
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

	// Token: 0x060010C1 RID: 4289 RVA: 0x00084F4A File Offset: 0x0008314A
	private void Update()
	{
	}

	// Token: 0x060010C2 RID: 4290 RVA: 0x00084F4C File Offset: 0x0008314C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400154C RID: 5452
	public Shader SCShader;

	// Token: 0x0400154D RID: 5453
	private float TimeX = 1f;

	// Token: 0x0400154E RID: 5454
	private Material SCMaterial;

	// Token: 0x0400154F RID: 5455
	[Range(0f, 5f)]
	public float Value = 1f;
}
