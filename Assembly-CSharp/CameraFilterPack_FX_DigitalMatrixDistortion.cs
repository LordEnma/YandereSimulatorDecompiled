using System;
using UnityEngine;

// Token: 0x020001AD RID: 429
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/DigitalMatrixDistortion")]
public class CameraFilterPack_FX_DigitalMatrixDistortion : MonoBehaviour
{
	// Token: 0x170002B1 RID: 689
	// (get) Token: 0x06000ED0 RID: 3792 RVA: 0x0007C0B9 File Offset: 0x0007A2B9
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

	// Token: 0x06000ED1 RID: 3793 RVA: 0x0007C0ED File Offset: 0x0007A2ED
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_DigitalMatrixDistortion");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000ED2 RID: 3794 RVA: 0x0007C110 File Offset: 0x0007A310
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

	// Token: 0x06000ED3 RID: 3795 RVA: 0x0007C1F2 File Offset: 0x0007A3F2
	private void Update()
	{
	}

	// Token: 0x06000ED4 RID: 3796 RVA: 0x0007C1F4 File Offset: 0x0007A3F4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400132E RID: 4910
	public Shader SCShader;

	// Token: 0x0400132F RID: 4911
	private float TimeX = 1f;

	// Token: 0x04001330 RID: 4912
	private Material SCMaterial;

	// Token: 0x04001331 RID: 4913
	[Range(0.4f, 5f)]
	public float Size = 1.4f;

	// Token: 0x04001332 RID: 4914
	[Range(-2f, 2f)]
	public float Speed = 0.5f;

	// Token: 0x04001333 RID: 4915
	[Range(-5f, 5f)]
	public float Distortion = 2.3f;
}
