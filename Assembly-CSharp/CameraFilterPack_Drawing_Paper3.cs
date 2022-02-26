using System;
using UnityEngine;

// Token: 0x0200019C RID: 412
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Paper3")]
public class CameraFilterPack_Drawing_Paper3 : MonoBehaviour
{
	// Token: 0x170002A0 RID: 672
	// (get) Token: 0x06000E67 RID: 3687 RVA: 0x0007A122 File Offset: 0x00078322
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

	// Token: 0x06000E68 RID: 3688 RVA: 0x0007A156 File Offset: 0x00078356
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Paper4") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Paper3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E69 RID: 3689 RVA: 0x0007A18C File Offset: 0x0007838C
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
			this.material.SetColor("_PColor", this.Pencil_Color);
			this.material.SetFloat("_Value1", this.Pencil_Size);
			this.material.SetFloat("_Value2", this.Pencil_Correction);
			this.material.SetFloat("_Value3", this.Intensity);
			this.material.SetFloat("_Value4", this.Speed_Animation);
			this.material.SetFloat("_Value5", this.Corner_Lose);
			this.material.SetFloat("_Value6", this.Fade_Paper_to_BackColor);
			this.material.SetFloat("_Value7", this.Fade_With_Original);
			this.material.SetColor("_PColor2", this.Back_Color);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E6A RID: 3690 RVA: 0x0007A2DB File Offset: 0x000784DB
	private void Update()
	{
	}

	// Token: 0x06000E6B RID: 3691 RVA: 0x0007A2DD File Offset: 0x000784DD
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012B4 RID: 4788
	public Shader SCShader;

	// Token: 0x040012B5 RID: 4789
	private float TimeX = 1f;

	// Token: 0x040012B6 RID: 4790
	public Color Pencil_Color = new Color(0f, 0f, 0f, 0f);

	// Token: 0x040012B7 RID: 4791
	[Range(0.0001f, 0.0022f)]
	public float Pencil_Size = 0.00125f;

	// Token: 0x040012B8 RID: 4792
	[Range(0f, 2f)]
	public float Pencil_Correction = 0.35f;

	// Token: 0x040012B9 RID: 4793
	[Range(0f, 1f)]
	public float Intensity = 1f;

	// Token: 0x040012BA RID: 4794
	[Range(0f, 2f)]
	public float Speed_Animation = 1f;

	// Token: 0x040012BB RID: 4795
	[Range(0f, 1f)]
	public float Corner_Lose = 1f;

	// Token: 0x040012BC RID: 4796
	[Range(0f, 1f)]
	public float Fade_Paper_to_BackColor;

	// Token: 0x040012BD RID: 4797
	[Range(0f, 1f)]
	public float Fade_With_Original = 1f;

	// Token: 0x040012BE RID: 4798
	public Color Back_Color = new Color(1f, 1f, 1f, 1f);

	// Token: 0x040012BF RID: 4799
	private Material SCMaterial;

	// Token: 0x040012C0 RID: 4800
	private Texture2D Texture2;
}
