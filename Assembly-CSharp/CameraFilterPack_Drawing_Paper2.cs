using System;
using UnityEngine;

// Token: 0x0200019B RID: 411
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Paper2")]
public class CameraFilterPack_Drawing_Paper2 : MonoBehaviour
{
	// Token: 0x1700029F RID: 671
	// (get) Token: 0x06000E61 RID: 3681 RVA: 0x00079EAE File Offset: 0x000780AE
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

	// Token: 0x06000E62 RID: 3682 RVA: 0x00079EE2 File Offset: 0x000780E2
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Paper3") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Paper2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E63 RID: 3683 RVA: 0x00079F18 File Offset: 0x00078118
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

	// Token: 0x06000E64 RID: 3684 RVA: 0x0007A067 File Offset: 0x00078267
	private void Update()
	{
	}

	// Token: 0x06000E65 RID: 3685 RVA: 0x0007A069 File Offset: 0x00078269
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012A7 RID: 4775
	public Shader SCShader;

	// Token: 0x040012A8 RID: 4776
	private float TimeX = 1f;

	// Token: 0x040012A9 RID: 4777
	public Color Pencil_Color = new Color(0f, 0.371f, 0.78f, 1f);

	// Token: 0x040012AA RID: 4778
	[Range(0.0001f, 0.0022f)]
	public float Pencil_Size = 0.0008f;

	// Token: 0x040012AB RID: 4779
	[Range(0f, 2f)]
	public float Pencil_Correction = 0.76f;

	// Token: 0x040012AC RID: 4780
	[Range(0f, 1f)]
	public float Intensity = 1f;

	// Token: 0x040012AD RID: 4781
	[Range(0f, 2f)]
	public float Speed_Animation = 1f;

	// Token: 0x040012AE RID: 4782
	[Range(0f, 1f)]
	public float Corner_Lose = 0.85f;

	// Token: 0x040012AF RID: 4783
	[Range(0f, 1f)]
	public float Fade_Paper_to_BackColor;

	// Token: 0x040012B0 RID: 4784
	[Range(0f, 1f)]
	public float Fade_With_Original = 1f;

	// Token: 0x040012B1 RID: 4785
	public Color Back_Color = new Color(1f, 1f, 1f, 1f);

	// Token: 0x040012B2 RID: 4786
	private Material SCMaterial;

	// Token: 0x040012B3 RID: 4787
	private Texture2D Texture2;
}
