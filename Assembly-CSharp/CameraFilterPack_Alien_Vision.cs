using System;
using UnityEngine;

// Token: 0x0200011E RID: 286
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Alien/Vision")]
public class CameraFilterPack_Alien_Vision : MonoBehaviour
{
	// Token: 0x17000223 RID: 547
	// (get) Token: 0x06000B34 RID: 2868 RVA: 0x0006B68C File Offset: 0x0006988C
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

	// Token: 0x06000B35 RID: 2869 RVA: 0x0006B6C0 File Offset: 0x000698C0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Alien_Vision");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B36 RID: 2870 RVA: 0x0006B6E4 File Offset: 0x000698E4
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
			this.material.SetFloat("_Value", this.Therma_Variation);
			this.material.SetFloat("_Value2", this.Speed);
			this.material.SetFloat("_Value3", this.Burn);
			this.material.SetFloat("_Value4", this.SceneCut);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B37 RID: 2871 RVA: 0x0006B7DC File Offset: 0x000699DC
	private void Update()
	{
	}

	// Token: 0x06000B38 RID: 2872 RVA: 0x0006B7DE File Offset: 0x000699DE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F37 RID: 3895
	public Shader SCShader;

	// Token: 0x04000F38 RID: 3896
	private float TimeX = 1f;

	// Token: 0x04000F39 RID: 3897
	private Material SCMaterial;

	// Token: 0x04000F3A RID: 3898
	[Range(0f, 0.5f)]
	public float Therma_Variation = 0.5f;

	// Token: 0x04000F3B RID: 3899
	[Range(0f, 1f)]
	public float Speed = 0.5f;

	// Token: 0x04000F3C RID: 3900
	[Range(0f, 4f)]
	private float Burn;

	// Token: 0x04000F3D RID: 3901
	[Range(0f, 16f)]
	private float SceneCut = 1f;
}
