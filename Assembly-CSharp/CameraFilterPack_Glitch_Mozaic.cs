using System;
using UnityEngine;

// Token: 0x020001CB RID: 459
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Mozaic")]
public class CameraFilterPack_Glitch_Mozaic : MonoBehaviour
{
	// Token: 0x170002D0 RID: 720
	// (get) Token: 0x06000F84 RID: 3972 RVA: 0x0007EA35 File Offset: 0x0007CC35
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

	// Token: 0x06000F85 RID: 3973 RVA: 0x0007EA69 File Offset: 0x0007CC69
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Glitch_Mozaic");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F86 RID: 3974 RVA: 0x0007EA8C File Offset: 0x0007CC8C
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
			this.material.SetFloat("_Value", this.Intensity);
			this.material.SetFloat("_Value2", this.Value2);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F87 RID: 3975 RVA: 0x0007EB84 File Offset: 0x0007CD84
	private void Update()
	{
	}

	// Token: 0x06000F88 RID: 3976 RVA: 0x0007EB86 File Offset: 0x0007CD86
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013EF RID: 5103
	public Shader SCShader;

	// Token: 0x040013F0 RID: 5104
	private float TimeX = 1f;

	// Token: 0x040013F1 RID: 5105
	private Material SCMaterial;

	// Token: 0x040013F2 RID: 5106
	[Range(0.001f, 10f)]
	public float Intensity = 1f;

	// Token: 0x040013F3 RID: 5107
	[Range(0f, 10f)]
	private float Value2 = 1f;

	// Token: 0x040013F4 RID: 5108
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x040013F5 RID: 5109
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
