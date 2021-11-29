using System;
using UnityEngine;

// Token: 0x020001C5 RID: 453
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glasses/Classic Glasses")]
public class CameraFilterPack_Glasses_On : MonoBehaviour
{
	// Token: 0x170002CA RID: 714
	// (get) Token: 0x06000F60 RID: 3936 RVA: 0x0007DA39 File Offset: 0x0007BC39
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

	// Token: 0x06000F61 RID: 3937 RVA: 0x0007DA6D File Offset: 0x0007BC6D
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Glasses_On2") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Glasses_On");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F62 RID: 3938 RVA: 0x0007DAA4 File Offset: 0x0007BCA4
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
			this.material.SetFloat("UseFinalGlassColor", this.UseFinalGlassColor);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetFloat("VisionBlur", this.VisionBlur);
			this.material.SetFloat("GlassDistortion", this.GlassDistortion);
			this.material.SetFloat("GlassAberration", this.GlassAberration);
			this.material.SetColor("GlassesColor", this.GlassesColor);
			this.material.SetColor("GlassesColor2", this.GlassesColor2);
			this.material.SetColor("GlassColor", this.GlassColor);
			this.material.SetFloat("UseScanLineSize", this.UseScanLineSize);
			this.material.SetFloat("UseScanLine", this.UseScanLine);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F63 RID: 3939 RVA: 0x0007DC09 File Offset: 0x0007BE09
	private void Update()
	{
	}

	// Token: 0x06000F64 RID: 3940 RVA: 0x0007DC0B File Offset: 0x0007BE0B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400139B RID: 5019
	public Shader SCShader;

	// Token: 0x0400139C RID: 5020
	private float TimeX = 1f;

	// Token: 0x0400139D RID: 5021
	[Range(0f, 1f)]
	public float Fade = 0.2f;

	// Token: 0x0400139E RID: 5022
	[Range(0f, 0.1f)]
	public float VisionBlur = 0.0095f;

	// Token: 0x0400139F RID: 5023
	public Color GlassesColor = new Color(0f, 0f, 0f, 1f);

	// Token: 0x040013A0 RID: 5024
	public Color GlassesColor2 = new Color(0.25f, 0.25f, 0.25f, 0.25f);

	// Token: 0x040013A1 RID: 5025
	[Range(0f, 1f)]
	public float GlassDistortion = 0.45f;

	// Token: 0x040013A2 RID: 5026
	[Range(0f, 1f)]
	public float GlassAberration = 0.5f;

	// Token: 0x040013A3 RID: 5027
	[Range(0f, 1f)]
	public float UseFinalGlassColor;

	// Token: 0x040013A4 RID: 5028
	[Range(0f, 1f)]
	public float UseScanLine;

	// Token: 0x040013A5 RID: 5029
	[Range(1f, 512f)]
	public float UseScanLineSize = 1f;

	// Token: 0x040013A6 RID: 5030
	public Color GlassColor = new Color(0f, 0f, 0f, 1f);

	// Token: 0x040013A7 RID: 5031
	private Material SCMaterial;

	// Token: 0x040013A8 RID: 5032
	private Texture2D Texture2;
}
