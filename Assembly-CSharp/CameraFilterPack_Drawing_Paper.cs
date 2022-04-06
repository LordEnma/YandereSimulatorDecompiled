using System;
using UnityEngine;

// Token: 0x0200019A RID: 410
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Paper")]
public class CameraFilterPack_Drawing_Paper : MonoBehaviour
{
	// Token: 0x1700029E RID: 670
	// (get) Token: 0x06000E5D RID: 3677 RVA: 0x0007A1FD File Offset: 0x000783FD
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

	// Token: 0x06000E5E RID: 3678 RVA: 0x0007A231 File Offset: 0x00078431
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Paper1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Paper");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E5F RID: 3679 RVA: 0x0007A268 File Offset: 0x00078468
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

	// Token: 0x06000E60 RID: 3680 RVA: 0x0007A3B7 File Offset: 0x000785B7
	private void Update()
	{
	}

	// Token: 0x06000E61 RID: 3681 RVA: 0x0007A3B9 File Offset: 0x000785B9
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012AA RID: 4778
	public Shader SCShader;

	// Token: 0x040012AB RID: 4779
	private float TimeX = 1f;

	// Token: 0x040012AC RID: 4780
	public Color Pencil_Color = new Color(0.156f, 0.3f, 0.738f, 1f);

	// Token: 0x040012AD RID: 4781
	[Range(0.0001f, 0.0022f)]
	public float Pencil_Size = 0.0008f;

	// Token: 0x040012AE RID: 4782
	[Range(0f, 2f)]
	public float Pencil_Correction = 0.76f;

	// Token: 0x040012AF RID: 4783
	[Range(0f, 1f)]
	public float Intensity = 1f;

	// Token: 0x040012B0 RID: 4784
	[Range(0f, 2f)]
	public float Speed_Animation = 1f;

	// Token: 0x040012B1 RID: 4785
	[Range(0f, 1f)]
	public float Corner_Lose = 0.5f;

	// Token: 0x040012B2 RID: 4786
	[Range(0f, 1f)]
	public float Fade_Paper_to_BackColor;

	// Token: 0x040012B3 RID: 4787
	[Range(0f, 1f)]
	public float Fade_With_Original = 1f;

	// Token: 0x040012B4 RID: 4788
	public Color Back_Color = new Color(1f, 1f, 1f, 1f);

	// Token: 0x040012B5 RID: 4789
	private Material SCMaterial;

	// Token: 0x040012B6 RID: 4790
	private Texture2D Texture2;
}
