using System;
using UnityEngine;

// Token: 0x020001AD RID: 429
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/DigitalMatrixDistortion")]
public class CameraFilterPack_FX_DigitalMatrixDistortion : MonoBehaviour
{
	// Token: 0x170002B1 RID: 689
	// (get) Token: 0x06000ECE RID: 3790 RVA: 0x0007BC3D File Offset: 0x00079E3D
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

	// Token: 0x06000ECF RID: 3791 RVA: 0x0007BC71 File Offset: 0x00079E71
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_DigitalMatrixDistortion");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000ED0 RID: 3792 RVA: 0x0007BC94 File Offset: 0x00079E94
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
			this.material.SetFloat("_Value2", this.Distortion);
			this.material.SetFloat("_Value5", this.Speed);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000ED1 RID: 3793 RVA: 0x0007BD76 File Offset: 0x00079F76
	private void Update()
	{
	}

	// Token: 0x06000ED2 RID: 3794 RVA: 0x0007BD78 File Offset: 0x00079F78
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001327 RID: 4903
	public Shader SCShader;

	// Token: 0x04001328 RID: 4904
	private float TimeX = 1f;

	// Token: 0x04001329 RID: 4905
	private Material SCMaterial;

	// Token: 0x0400132A RID: 4906
	[Range(0.4f, 5f)]
	public float Size = 1.4f;

	// Token: 0x0400132B RID: 4907
	[Range(-2f, 2f)]
	public float Speed = 0.5f;

	// Token: 0x0400132C RID: 4908
	[Range(-5f, 5f)]
	public float Distortion = 2.3f;
}
