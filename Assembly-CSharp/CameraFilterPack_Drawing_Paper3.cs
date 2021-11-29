using System;
using UnityEngine;

// Token: 0x0200019B RID: 411
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Paper3")]
public class CameraFilterPack_Drawing_Paper3 : MonoBehaviour
{
	// Token: 0x170002A0 RID: 672
	// (get) Token: 0x06000E63 RID: 3683 RVA: 0x00079CC6 File Offset: 0x00077EC6
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

	// Token: 0x06000E64 RID: 3684 RVA: 0x00079CFA File Offset: 0x00077EFA
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

	// Token: 0x06000E65 RID: 3685 RVA: 0x00079D30 File Offset: 0x00077F30
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

	// Token: 0x06000E66 RID: 3686 RVA: 0x00079E7F File Offset: 0x0007807F
	private void Update()
	{
	}

	// Token: 0x06000E67 RID: 3687 RVA: 0x00079E81 File Offset: 0x00078081
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012AC RID: 4780
	public Shader SCShader;

	// Token: 0x040012AD RID: 4781
	private float TimeX = 1f;

	// Token: 0x040012AE RID: 4782
	public Color Pencil_Color = new Color(0f, 0f, 0f, 0f);

	// Token: 0x040012AF RID: 4783
	[Range(0.0001f, 0.0022f)]
	public float Pencil_Size = 0.00125f;

	// Token: 0x040012B0 RID: 4784
	[Range(0f, 2f)]
	public float Pencil_Correction = 0.35f;

	// Token: 0x040012B1 RID: 4785
	[Range(0f, 1f)]
	public float Intensity = 1f;

	// Token: 0x040012B2 RID: 4786
	[Range(0f, 2f)]
	public float Speed_Animation = 1f;

	// Token: 0x040012B3 RID: 4787
	[Range(0f, 1f)]
	public float Corner_Lose = 1f;

	// Token: 0x040012B4 RID: 4788
	[Range(0f, 1f)]
	public float Fade_Paper_to_BackColor;

	// Token: 0x040012B5 RID: 4789
	[Range(0f, 1f)]
	public float Fade_With_Original = 1f;

	// Token: 0x040012B6 RID: 4790
	public Color Back_Color = new Color(1f, 1f, 1f, 1f);

	// Token: 0x040012B7 RID: 4791
	private Material SCMaterial;

	// Token: 0x040012B8 RID: 4792
	private Texture2D Texture2;
}
