using System;
using UnityEngine;

// Token: 0x020001F9 RID: 505
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixelisation/Dot")]
public class CameraFilterPack_Pixelisation_Dot : MonoBehaviour
{
	// Token: 0x170002FD RID: 765
	// (get) Token: 0x060010BA RID: 4282 RVA: 0x0008536D File Offset: 0x0008356D
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

	// Token: 0x060010BB RID: 4283 RVA: 0x000853A1 File Offset: 0x000835A1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Pixelisation_Dot");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010BC RID: 4284 RVA: 0x000853C4 File Offset: 0x000835C4
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
			this.material.SetFloat("_Value2", this.LightBackGround);
			this.material.SetFloat("_Value3", this.Speed);
			this.material.SetFloat("_Value4", this.Size2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010BD RID: 4285 RVA: 0x000854BC File Offset: 0x000836BC
	private void Update()
	{
	}

	// Token: 0x060010BE RID: 4286 RVA: 0x000854BE File Offset: 0x000836BE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001555 RID: 5461
	public Shader SCShader;

	// Token: 0x04001556 RID: 5462
	private float TimeX = 1f;

	// Token: 0x04001557 RID: 5463
	private Material SCMaterial;

	// Token: 0x04001558 RID: 5464
	[Range(0.0001f, 0.5f)]
	public float Size = 0.005f;

	// Token: 0x04001559 RID: 5465
	[Range(0f, 1f)]
	public float LightBackGround = 0.3f;

	// Token: 0x0400155A RID: 5466
	[Range(0f, 10f)]
	private float Speed = 1f;

	// Token: 0x0400155B RID: 5467
	[Range(0f, 10f)]
	private float Size2 = 1f;
}
