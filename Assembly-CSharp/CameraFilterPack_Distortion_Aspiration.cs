using System;
using UnityEngine;

// Token: 0x02000172 RID: 370
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Aspiration")]
public class CameraFilterPack_Distortion_Aspiration : MonoBehaviour
{
	// Token: 0x17000277 RID: 631
	// (get) Token: 0x06000D6D RID: 3437 RVA: 0x00075FB2 File Offset: 0x000741B2
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

	// Token: 0x06000D6E RID: 3438 RVA: 0x00075FE6 File Offset: 0x000741E6
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Aspiration");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D6F RID: 3439 RVA: 0x00076008 File Offset: 0x00074208
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

	// Token: 0x06000D70 RID: 3440 RVA: 0x00076106 File Offset: 0x00074306
	private void Update()
	{
	}

	// Token: 0x06000D71 RID: 3441 RVA: 0x00076108 File Offset: 0x00074308
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011B2 RID: 4530
	public Shader SCShader;

	// Token: 0x040011B3 RID: 4531
	private float TimeX = 1f;

	// Token: 0x040011B4 RID: 4532
	private Material SCMaterial;

	// Token: 0x040011B5 RID: 4533
	[Range(0f, 1f)]
	public float Value = 0.8f;

	// Token: 0x040011B6 RID: 4534
	[Range(-1f, 1f)]
	public float PosX = 0.5f;

	// Token: 0x040011B7 RID: 4535
	[Range(-1f, 1f)]
	public float PosY = 0.5f;

	// Token: 0x040011B8 RID: 4536
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
