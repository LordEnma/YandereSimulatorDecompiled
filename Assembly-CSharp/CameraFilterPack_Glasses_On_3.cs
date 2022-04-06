using System;
using UnityEngine;

// Token: 0x020001C8 RID: 456
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glasses/Night Glasses")]
public class CameraFilterPack_Glasses_On_3 : MonoBehaviour
{
	// Token: 0x170002CC RID: 716
	// (get) Token: 0x06000F72 RID: 3954 RVA: 0x0007E9A5 File Offset: 0x0007CBA5
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

	// Token: 0x06000F73 RID: 3955 RVA: 0x0007E9D9 File Offset: 0x0007CBD9
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

	// Token: 0x06000F74 RID: 3956 RVA: 0x0007EA10 File Offset: 0x0007CC10
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

	// Token: 0x06000F75 RID: 3957 RVA: 0x0007EB75 File Offset: 0x0007CD75
	private void Update()
	{
	}

	// Token: 0x06000F76 RID: 3958 RVA: 0x0007EB77 File Offset: 0x0007CD77
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013CF RID: 5071
	public Shader SCShader;

	// Token: 0x040013D0 RID: 5072
	private float TimeX = 1f;

	// Token: 0x040013D1 RID: 5073
	[Range(0f, 1f)]
	public float Fade = 0.3f;

	// Token: 0x040013D2 RID: 5074
	[Range(0f, 0.1f)]
	public float VisionBlur = 0.005f;

	// Token: 0x040013D3 RID: 5075
	public Color GlassesColor = new Color(0.7f, 0.7f, 0.7f, 1f);

	// Token: 0x040013D4 RID: 5076
	public Color GlassesColor2 = new Color(1f, 1f, 1f, 1f);

	// Token: 0x040013D5 RID: 5077
	[Range(0f, 1f)]
	public float GlassDistortion = 0.6f;

	// Token: 0x040013D6 RID: 5078
	[Range(0f, 1f)]
	public float GlassAberration = 0.3f;

	// Token: 0x040013D7 RID: 5079
	[Range(0f, 1f)]
	public float UseFinalGlassColor;

	// Token: 0x040013D8 RID: 5080
	[Range(0f, 1f)]
	public float UseScanLine = 0.4f;

	// Token: 0x040013D9 RID: 5081
	[Range(1f, 512f)]
	public float UseScanLineSize = 358f;

	// Token: 0x040013DA RID: 5082
	public Color GlassColor = new Color(0f, 0.5f, 0f, 1f);

	// Token: 0x040013DB RID: 5083
	private Material SCMaterial;

	// Token: 0x040013DC RID: 5084
	private Texture2D Texture2;
}
