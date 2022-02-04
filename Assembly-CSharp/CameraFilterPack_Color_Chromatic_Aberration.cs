using System;
using UnityEngine;

// Token: 0x0200015D RID: 349
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Chromatic_Aberration")]
public class CameraFilterPack_Color_Chromatic_Aberration : MonoBehaviour
{
	// Token: 0x17000261 RID: 609
	// (get) Token: 0x06000CEA RID: 3306 RVA: 0x00073DB6 File Offset: 0x00071FB6
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

	// Token: 0x06000CEB RID: 3307 RVA: 0x00073DEA File Offset: 0x00071FEA
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Chromatic_Aberration");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CEC RID: 3308 RVA: 0x00073E0C File Offset: 0x0007200C
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
			this.material.SetFloat("_Distortion", this.Offset);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CED RID: 3309 RVA: 0x00073EC2 File Offset: 0x000720C2
	private void Update()
	{
	}

	// Token: 0x06000CEE RID: 3310 RVA: 0x00073EC4 File Offset: 0x000720C4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400113D RID: 4413
	public Shader SCShader;

	// Token: 0x0400113E RID: 4414
	private float TimeX = 1f;

	// Token: 0x0400113F RID: 4415
	private Material SCMaterial;

	// Token: 0x04001140 RID: 4416
	[Range(-0.02f, 0.02f)]
	public float Offset = 0.02f;
}
