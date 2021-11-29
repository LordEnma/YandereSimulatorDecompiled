using System;
using UnityEngine;

// Token: 0x0200015D RID: 349
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Chromatic_Plus")]
public class CameraFilterPack_Color_Chromatic_Plus : MonoBehaviour
{
	// Token: 0x17000262 RID: 610
	// (get) Token: 0x06000CED RID: 3309 RVA: 0x00073D04 File Offset: 0x00071F04
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

	// Token: 0x06000CEE RID: 3310 RVA: 0x00073D38 File Offset: 0x00071F38
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Chromatic_Plus");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CEF RID: 3311 RVA: 0x00073D5C File Offset: 0x00071F5C
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
			this.material.SetFloat("_Value", this.Size);
			this.material.SetFloat("_Value2", this.Smooth);
			this.material.SetFloat("_Distortion", this.Offset);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CF0 RID: 3312 RVA: 0x00073E3E File Offset: 0x0007203E
	private void Update()
	{
	}

	// Token: 0x06000CF1 RID: 3313 RVA: 0x00073E40 File Offset: 0x00072040
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400113C RID: 4412
	public Shader SCShader;

	// Token: 0x0400113D RID: 4413
	private float TimeX = 1f;

	// Token: 0x0400113E RID: 4414
	private Material SCMaterial;

	// Token: 0x0400113F RID: 4415
	[Range(0f, 0.8f)]
	public float Size = 0.55f;

	// Token: 0x04001140 RID: 4416
	[Range(0.01f, 0.4f)]
	public float Smooth = 0.26f;

	// Token: 0x04001141 RID: 4417
	[Range(-0.02f, 0.02f)]
	public float Offset = 0.005f;
}
