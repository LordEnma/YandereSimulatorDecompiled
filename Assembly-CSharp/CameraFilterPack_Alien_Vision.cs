using System;
using UnityEngine;

// Token: 0x0200011F RID: 287
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Alien/Vision")]
public class CameraFilterPack_Alien_Vision : MonoBehaviour
{
	// Token: 0x17000223 RID: 547
	// (get) Token: 0x06000B3A RID: 2874 RVA: 0x0006C0AC File Offset: 0x0006A2AC
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

	// Token: 0x06000B3B RID: 2875 RVA: 0x0006C0E0 File Offset: 0x0006A2E0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Alien_Vision");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B3C RID: 2876 RVA: 0x0006C104 File Offset: 0x0006A304
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

	// Token: 0x06000B3D RID: 2877 RVA: 0x0006C1FC File Offset: 0x0006A3FC
	private void Update()
	{
	}

	// Token: 0x06000B3E RID: 2878 RVA: 0x0006C1FE File Offset: 0x0006A3FE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F4F RID: 3919
	public Shader SCShader;

	// Token: 0x04000F50 RID: 3920
	private float TimeX = 1f;

	// Token: 0x04000F51 RID: 3921
	private Material SCMaterial;

	// Token: 0x04000F52 RID: 3922
	[Range(0f, 0.5f)]
	public float Therma_Variation = 0.5f;

	// Token: 0x04000F53 RID: 3923
	[Range(0f, 1f)]
	public float Speed = 0.5f;

	// Token: 0x04000F54 RID: 3924
	[Range(0f, 4f)]
	private float Burn;

	// Token: 0x04000F55 RID: 3925
	[Range(0f, 16f)]
	private float SceneCut = 1f;
}
