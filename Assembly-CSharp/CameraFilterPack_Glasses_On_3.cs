using System;
using UnityEngine;

// Token: 0x020001C8 RID: 456
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glasses/Night Glasses")]
public class CameraFilterPack_Glasses_On_3 : MonoBehaviour
{
	// Token: 0x170002CC RID: 716
	// (get) Token: 0x06000F70 RID: 3952 RVA: 0x0007E529 File Offset: 0x0007C729
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

	// Token: 0x06000F71 RID: 3953 RVA: 0x0007E55D File Offset: 0x0007C75D
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Glasses_On4") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Glasses_On");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F72 RID: 3954 RVA: 0x0007E594 File Offset: 0x0007C794
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

	// Token: 0x06000F73 RID: 3955 RVA: 0x0007E6F9 File Offset: 0x0007C8F9
	private void Update()
	{
	}

	// Token: 0x06000F74 RID: 3956 RVA: 0x0007E6FB File Offset: 0x0007C8FB
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013C8 RID: 5064
	public Shader SCShader;

	// Token: 0x040013C9 RID: 5065
	private float TimeX = 1f;

	// Token: 0x040013CA RID: 5066
	[Range(0f, 1f)]
	public float Fade = 0.3f;

	// Token: 0x040013CB RID: 5067
	[Range(0f, 0.1f)]
	public float VisionBlur = 0.005f;

	// Token: 0x040013CC RID: 5068
	public Color GlassesColor = new Color(0.7f, 0.7f, 0.7f, 1f);

	// Token: 0x040013CD RID: 5069
	public Color GlassesColor2 = new Color(1f, 1f, 1f, 1f);

	// Token: 0x040013CE RID: 5070
	[Range(0f, 1f)]
	public float GlassDistortion = 0.6f;

	// Token: 0x040013CF RID: 5071
	[Range(0f, 1f)]
	public float GlassAberration = 0.3f;

	// Token: 0x040013D0 RID: 5072
	[Range(0f, 1f)]
	public float UseFinalGlassColor;

	// Token: 0x040013D1 RID: 5073
	[Range(0f, 1f)]
	public float UseScanLine = 0.4f;

	// Token: 0x040013D2 RID: 5074
	[Range(1f, 512f)]
	public float UseScanLineSize = 358f;

	// Token: 0x040013D3 RID: 5075
	public Color GlassColor = new Color(0f, 0.5f, 0f, 1f);

	// Token: 0x040013D4 RID: 5076
	private Material SCMaterial;

	// Token: 0x040013D5 RID: 5077
	private Texture2D Texture2;
}
