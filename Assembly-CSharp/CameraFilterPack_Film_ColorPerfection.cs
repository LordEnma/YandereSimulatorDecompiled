using System;
using UnityEngine;

// Token: 0x020001C3 RID: 451
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Film/ColorPerfection")]
public class CameraFilterPack_Film_ColorPerfection : MonoBehaviour
{
	// Token: 0x170002C7 RID: 711
	// (get) Token: 0x06000F54 RID: 3924 RVA: 0x0007DF94 File Offset: 0x0007C194
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

	// Token: 0x06000F55 RID: 3925 RVA: 0x0007DFC8 File Offset: 0x0007C1C8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Film_ColorPerfection");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F56 RID: 3926 RVA: 0x0007DFEC File Offset: 0x0007C1EC
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
			this.material.SetFloat("_Value", this.Gamma);
			this.material.SetFloat("_Value2", this.Value2);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F57 RID: 3927 RVA: 0x0007E0E4 File Offset: 0x0007C2E4
	private void Update()
	{
	}

	// Token: 0x06000F58 RID: 3928 RVA: 0x0007E0E6 File Offset: 0x0007C2E6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013A0 RID: 5024
	public Shader SCShader;

	// Token: 0x040013A1 RID: 5025
	private float TimeX = 1f;

	// Token: 0x040013A2 RID: 5026
	private Material SCMaterial;

	// Token: 0x040013A3 RID: 5027
	[Range(0f, 4f)]
	public float Gamma = 0.55f;

	// Token: 0x040013A4 RID: 5028
	[Range(0f, 10f)]
	private float Value2 = 1f;

	// Token: 0x040013A5 RID: 5029
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x040013A6 RID: 5030
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
