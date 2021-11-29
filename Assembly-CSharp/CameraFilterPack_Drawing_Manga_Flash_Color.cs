using System;
using UnityEngine;

// Token: 0x02000197 RID: 407
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga_Flash_Color")]
public class CameraFilterPack_Drawing_Manga_Flash_Color : MonoBehaviour
{
	// Token: 0x1700029C RID: 668
	// (get) Token: 0x06000E4B RID: 3659 RVA: 0x00079491 File Offset: 0x00077691
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

	// Token: 0x06000E4C RID: 3660 RVA: 0x000794C5 File Offset: 0x000776C5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga_Flash_Color");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E4D RID: 3661 RVA: 0x000794E8 File Offset: 0x000776E8
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

	// Token: 0x06000E4E RID: 3662 RVA: 0x0007960D File Offset: 0x0007780D
	private void Update()
	{
	}

	// Token: 0x06000E4F RID: 3663 RVA: 0x0007960F File Offset: 0x0007780F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001285 RID: 4741
	public Shader SCShader;

	// Token: 0x04001286 RID: 4742
	private float TimeX = 1f;

	// Token: 0x04001287 RID: 4743
	private Material SCMaterial;

	// Token: 0x04001288 RID: 4744
	[Range(1f, 10f)]
	public float Size = 1f;

	// Token: 0x04001289 RID: 4745
	public Color Color = new Color(0f, 0.7f, 1f, 1f);

	// Token: 0x0400128A RID: 4746
	[Range(0f, 30f)]
	public int Speed = 5;

	// Token: 0x0400128B RID: 4747
	[Range(0f, 1f)]
	public float PosX = 0.5f;

	// Token: 0x0400128C RID: 4748
	[Range(0f, 1f)]
	public float PosY = 0.5f;

	// Token: 0x0400128D RID: 4749
	[Range(0f, 1f)]
	public float Intensity = 1f;
}
