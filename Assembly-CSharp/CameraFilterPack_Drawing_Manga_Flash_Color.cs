using System;
using UnityEngine;

// Token: 0x02000198 RID: 408
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga_Flash_Color")]
public class CameraFilterPack_Drawing_Manga_Flash_Color : MonoBehaviour
{
	// Token: 0x1700029C RID: 668
	// (get) Token: 0x06000E4F RID: 3663 RVA: 0x00079A35 File Offset: 0x00077C35
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

	// Token: 0x06000E50 RID: 3664 RVA: 0x00079A69 File Offset: 0x00077C69
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga_Flash_Color");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E51 RID: 3665 RVA: 0x00079A8C File Offset: 0x00077C8C
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
			this.material.SetFloat("_Value2", (float)this.Speed);
			this.material.SetFloat("_Value3", this.PosX);
			this.material.SetFloat("_Value4", this.PosY);
			this.material.SetFloat("_Intensity", this.Intensity);
			this.material.SetColor("Color", this.Color);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E52 RID: 3666 RVA: 0x00079BB1 File Offset: 0x00077DB1
	private void Update()
	{
	}

	// Token: 0x06000E53 RID: 3667 RVA: 0x00079BB3 File Offset: 0x00077DB3
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001296 RID: 4758
	public Shader SCShader;

	// Token: 0x04001297 RID: 4759
	private float TimeX = 1f;

	// Token: 0x04001298 RID: 4760
	private Material SCMaterial;

	// Token: 0x04001299 RID: 4761
	[Range(1f, 10f)]
	public float Size = 1f;

	// Token: 0x0400129A RID: 4762
	public Color Color = new Color(0f, 0.7f, 1f, 1f);

	// Token: 0x0400129B RID: 4763
	[Range(0f, 30f)]
	public int Speed = 5;

	// Token: 0x0400129C RID: 4764
	[Range(0f, 1f)]
	public float PosX = 0.5f;

	// Token: 0x0400129D RID: 4765
	[Range(0f, 1f)]
	public float PosY = 0.5f;

	// Token: 0x0400129E RID: 4766
	[Range(0f, 1f)]
	public float Intensity = 1f;
}
