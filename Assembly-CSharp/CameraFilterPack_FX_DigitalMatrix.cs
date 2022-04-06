using System;
using UnityEngine;

// Token: 0x020001AC RID: 428
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/DigitalMatrix")]
public class CameraFilterPack_FX_DigitalMatrix : MonoBehaviour
{
	// Token: 0x170002B0 RID: 688
	// (get) Token: 0x06000ECA RID: 3786 RVA: 0x0007BEE0 File Offset: 0x0007A0E0
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

	// Token: 0x06000ECB RID: 3787 RVA: 0x0007BF14 File Offset: 0x0007A114
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_DigitalMatrix");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000ECC RID: 3788 RVA: 0x0007BF38 File Offset: 0x0007A138
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
			this.material.SetFloat("_Value2", this.ColorR);
			this.material.SetFloat("_Value3", this.ColorG);
			this.material.SetFloat("_Value4", this.ColorB);
			this.material.SetFloat("_Value5", this.Speed);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000ECD RID: 3789 RVA: 0x0007C046 File Offset: 0x0007A246
	private void Update()
	{
	}

	// Token: 0x06000ECE RID: 3790 RVA: 0x0007C048 File Offset: 0x0007A248
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001326 RID: 4902
	public Shader SCShader;

	// Token: 0x04001327 RID: 4903
	private float TimeX = 1f;

	// Token: 0x04001328 RID: 4904
	private Material SCMaterial;

	// Token: 0x04001329 RID: 4905
	[Range(0.4f, 5f)]
	public float Size = 1f;

	// Token: 0x0400132A RID: 4906
	[Range(-10f, 10f)]
	public float Speed = 1f;

	// Token: 0x0400132B RID: 4907
	[Range(-1f, 1f)]
	public float ColorR = -1f;

	// Token: 0x0400132C RID: 4908
	[Range(-1f, 1f)]
	public float ColorG = 1f;

	// Token: 0x0400132D RID: 4909
	[Range(-1f, 1f)]
	public float ColorB = -1f;
}
