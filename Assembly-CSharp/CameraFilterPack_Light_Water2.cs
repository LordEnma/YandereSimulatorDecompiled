using System;
using UnityEngine;

// Token: 0x020001DB RID: 475
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Light/Water2")]
public class CameraFilterPack_Light_Water2 : MonoBehaviour
{
	// Token: 0x170002E0 RID: 736
	// (get) Token: 0x06000FE4 RID: 4068 RVA: 0x000803E0 File Offset: 0x0007E5E0
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

	// Token: 0x06000FE5 RID: 4069 RVA: 0x00080414 File Offset: 0x0007E614
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Light_Water2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FE6 RID: 4070 RVA: 0x00080438 File Offset: 0x0007E638
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
			this.material.SetFloat("_Value", this.Speed);
			this.material.SetFloat("_Value2", this.Speed_X);
			this.material.SetFloat("_Value3", this.Speed_Y);
			this.material.SetFloat("_Value4", this.Intensity);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000FE7 RID: 4071 RVA: 0x00080530 File Offset: 0x0007E730
	private void Update()
	{
	}

	// Token: 0x06000FE8 RID: 4072 RVA: 0x00080532 File Offset: 0x0007E732
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001452 RID: 5202
	public Shader SCShader;

	// Token: 0x04001453 RID: 5203
	private float TimeX = 1f;

	// Token: 0x04001454 RID: 5204
	private Material SCMaterial;

	// Token: 0x04001455 RID: 5205
	[Range(0f, 10f)]
	public float Speed = 0.2f;

	// Token: 0x04001456 RID: 5206
	[Range(0f, 10f)]
	public float Speed_X = 0.2f;

	// Token: 0x04001457 RID: 5207
	[Range(0f, 1f)]
	public float Speed_Y = 0.3f;

	// Token: 0x04001458 RID: 5208
	[Range(0f, 10f)]
	public float Intensity = 2.4f;
}
