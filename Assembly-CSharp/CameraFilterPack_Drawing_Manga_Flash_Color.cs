using System;
using UnityEngine;

// Token: 0x02000198 RID: 408
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga_Flash_Color")]
public class CameraFilterPack_Drawing_Manga_Flash_Color : MonoBehaviour
{
	// Token: 0x1700029C RID: 668
	// (get) Token: 0x06000E4F RID: 3663 RVA: 0x000797D9 File Offset: 0x000779D9
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

	// Token: 0x06000E50 RID: 3664 RVA: 0x0007980D File Offset: 0x00077A0D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga_Flash_Color");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E51 RID: 3665 RVA: 0x00079830 File Offset: 0x00077A30
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

	// Token: 0x06000E52 RID: 3666 RVA: 0x00079955 File Offset: 0x00077B55
	private void Update()
	{
	}

	// Token: 0x06000E53 RID: 3667 RVA: 0x00079957 File Offset: 0x00077B57
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400128D RID: 4749
	public Shader SCShader;

	// Token: 0x0400128E RID: 4750
	private float TimeX = 1f;

	// Token: 0x0400128F RID: 4751
	private Material SCMaterial;

	// Token: 0x04001290 RID: 4752
	[Range(1f, 10f)]
	public float Size = 1f;

	// Token: 0x04001291 RID: 4753
	public Color Color = new Color(0f, 0.7f, 1f, 1f);

	// Token: 0x04001292 RID: 4754
	[Range(0f, 30f)]
	public int Speed = 5;

	// Token: 0x04001293 RID: 4755
	[Range(0f, 1f)]
	public float PosX = 0.5f;

	// Token: 0x04001294 RID: 4756
	[Range(0f, 1f)]
	public float PosY = 0.5f;

	// Token: 0x04001295 RID: 4757
	[Range(0f, 1f)]
	public float Intensity = 1f;
}
