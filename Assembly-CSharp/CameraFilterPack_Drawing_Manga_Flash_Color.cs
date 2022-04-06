using System;
using UnityEngine;

// Token: 0x02000198 RID: 408
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga_Flash_Color")]
public class CameraFilterPack_Drawing_Manga_Flash_Color : MonoBehaviour
{
	// Token: 0x1700029C RID: 668
	// (get) Token: 0x06000E51 RID: 3665 RVA: 0x00079EB1 File Offset: 0x000780B1
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

	// Token: 0x06000E52 RID: 3666 RVA: 0x00079EE5 File Offset: 0x000780E5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga_Flash_Color");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E53 RID: 3667 RVA: 0x00079F08 File Offset: 0x00078108
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

	// Token: 0x06000E54 RID: 3668 RVA: 0x0007A02D File Offset: 0x0007822D
	private void Update()
	{
	}

	// Token: 0x06000E55 RID: 3669 RVA: 0x0007A02F File Offset: 0x0007822F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400129D RID: 4765
	public Shader SCShader;

	// Token: 0x0400129E RID: 4766
	private float TimeX = 1f;

	// Token: 0x0400129F RID: 4767
	private Material SCMaterial;

	// Token: 0x040012A0 RID: 4768
	[Range(1f, 10f)]
	public float Size = 1f;

	// Token: 0x040012A1 RID: 4769
	public Color Color = new Color(0f, 0.7f, 1f, 1f);

	// Token: 0x040012A2 RID: 4770
	[Range(0f, 30f)]
	public int Speed = 5;

	// Token: 0x040012A3 RID: 4771
	[Range(0f, 1f)]
	public float PosX = 0.5f;

	// Token: 0x040012A4 RID: 4772
	[Range(0f, 1f)]
	public float PosY = 0.5f;

	// Token: 0x040012A5 RID: 4773
	[Range(0f, 1f)]
	public float Intensity = 1f;
}
