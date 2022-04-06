using System;
using UnityEngine;

// Token: 0x020001C6 RID: 454
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glasses/Classic Glasses")]
public class CameraFilterPack_Glasses_On : MonoBehaviour
{
	// Token: 0x170002CA RID: 714
	// (get) Token: 0x06000F66 RID: 3942 RVA: 0x0007E459 File Offset: 0x0007C659
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

	// Token: 0x06000F67 RID: 3943 RVA: 0x0007E48D File Offset: 0x0007C68D
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

	// Token: 0x06000F68 RID: 3944 RVA: 0x0007E4C4 File Offset: 0x0007C6C4
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

	// Token: 0x06000F69 RID: 3945 RVA: 0x0007E629 File Offset: 0x0007C829
	private void Update()
	{
	}

	// Token: 0x06000F6A RID: 3946 RVA: 0x0007E62B File Offset: 0x0007C82B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013B3 RID: 5043
	public Shader SCShader;

	// Token: 0x040013B4 RID: 5044
	private float TimeX = 1f;

	// Token: 0x040013B5 RID: 5045
	[Range(0f, 1f)]
	public float Fade = 0.2f;

	// Token: 0x040013B6 RID: 5046
	[Range(0f, 0.1f)]
	public float VisionBlur = 0.0095f;

	// Token: 0x040013B7 RID: 5047
	public Color GlassesColor = new Color(0f, 0f, 0f, 1f);

	// Token: 0x040013B8 RID: 5048
	public Color GlassesColor2 = new Color(0.25f, 0.25f, 0.25f, 0.25f);

	// Token: 0x040013B9 RID: 5049
	[Range(0f, 1f)]
	public float GlassDistortion = 0.45f;

	// Token: 0x040013BA RID: 5050
	[Range(0f, 1f)]
	public float GlassAberration = 0.5f;

	// Token: 0x040013BB RID: 5051
	[Range(0f, 1f)]
	public float UseFinalGlassColor;

	// Token: 0x040013BC RID: 5052
	[Range(0f, 1f)]
	public float UseScanLine;

	// Token: 0x040013BD RID: 5053
	[Range(1f, 512f)]
	public float UseScanLineSize = 1f;

	// Token: 0x040013BE RID: 5054
	public Color GlassColor = new Color(0f, 0f, 0f, 1f);

	// Token: 0x040013BF RID: 5055
	private Material SCMaterial;

	// Token: 0x040013C0 RID: 5056
	private Texture2D Texture2;
}
