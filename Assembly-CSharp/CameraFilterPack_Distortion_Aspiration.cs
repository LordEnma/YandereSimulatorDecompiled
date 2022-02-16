using System;
using UnityEngine;

// Token: 0x02000173 RID: 371
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Aspiration")]
public class CameraFilterPack_Distortion_Aspiration : MonoBehaviour
{
	// Token: 0x17000277 RID: 631
	// (get) Token: 0x06000D71 RID: 3441 RVA: 0x000762FA File Offset: 0x000744FA
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

	// Token: 0x06000D72 RID: 3442 RVA: 0x0007632E File Offset: 0x0007452E
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Aspiration");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D73 RID: 3443 RVA: 0x00076350 File Offset: 0x00074550
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
			this.material.SetFloat("_Value", 1f - this.Value);
			this.material.SetFloat("_Value2", this.PosX);
			this.material.SetFloat("_Value3", this.PosY);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D74 RID: 3444 RVA: 0x0007644E File Offset: 0x0007464E
	private void Update()
	{
	}

	// Token: 0x06000D75 RID: 3445 RVA: 0x00076450 File Offset: 0x00074650
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011BA RID: 4538
	public Shader SCShader;

	// Token: 0x040011BB RID: 4539
	private float TimeX = 1f;

	// Token: 0x040011BC RID: 4540
	private Material SCMaterial;

	// Token: 0x040011BD RID: 4541
	[Range(0f, 1f)]
	public float Value = 0.8f;

	// Token: 0x040011BE RID: 4542
	[Range(-1f, 1f)]
	public float PosX = 0.5f;

	// Token: 0x040011BF RID: 4543
	[Range(-1f, 1f)]
	public float PosY = 0.5f;

	// Token: 0x040011C0 RID: 4544
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
