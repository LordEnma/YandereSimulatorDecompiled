using System;
using UnityEngine;

// Token: 0x020001C8 RID: 456
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glasses/Night Glasses")]
public class CameraFilterPack_Glasses_On_3 : MonoBehaviour
{
	// Token: 0x170002CC RID: 716
	// (get) Token: 0x06000F6F RID: 3951 RVA: 0x0007E17D File Offset: 0x0007C37D
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

	// Token: 0x06000F70 RID: 3952 RVA: 0x0007E1B1 File Offset: 0x0007C3B1
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

	// Token: 0x06000F71 RID: 3953 RVA: 0x0007E1E8 File Offset: 0x0007C3E8
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

	// Token: 0x06000F72 RID: 3954 RVA: 0x0007E34D File Offset: 0x0007C54D
	private void Update()
	{
	}

	// Token: 0x06000F73 RID: 3955 RVA: 0x0007E34F File Offset: 0x0007C54F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013BC RID: 5052
	public Shader SCShader;

	// Token: 0x040013BD RID: 5053
	private float TimeX = 1f;

	// Token: 0x040013BE RID: 5054
	[Range(0f, 1f)]
	public float Fade = 0.3f;

	// Token: 0x040013BF RID: 5055
	[Range(0f, 0.1f)]
	public float VisionBlur = 0.005f;

	// Token: 0x040013C0 RID: 5056
	public Color GlassesColor = new Color(0.7f, 0.7f, 0.7f, 1f);

	// Token: 0x040013C1 RID: 5057
	public Color GlassesColor2 = new Color(1f, 1f, 1f, 1f);

	// Token: 0x040013C2 RID: 5058
	[Range(0f, 1f)]
	public float GlassDistortion = 0.6f;

	// Token: 0x040013C3 RID: 5059
	[Range(0f, 1f)]
	public float GlassAberration = 0.3f;

	// Token: 0x040013C4 RID: 5060
	[Range(0f, 1f)]
	public float UseFinalGlassColor;

	// Token: 0x040013C5 RID: 5061
	[Range(0f, 1f)]
	public float UseScanLine = 0.4f;

	// Token: 0x040013C6 RID: 5062
	[Range(1f, 512f)]
	public float UseScanLineSize = 358f;

	// Token: 0x040013C7 RID: 5063
	public Color GlassColor = new Color(0f, 0.5f, 0f, 1f);

	// Token: 0x040013C8 RID: 5064
	private Material SCMaterial;

	// Token: 0x040013C9 RID: 5065
	private Texture2D Texture2;
}
