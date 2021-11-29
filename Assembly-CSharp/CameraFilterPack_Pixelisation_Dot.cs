using System;
using UnityEngine;

// Token: 0x020001F8 RID: 504
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixelisation/Dot")]
public class CameraFilterPack_Pixelisation_Dot : MonoBehaviour
{
	// Token: 0x170002FD RID: 765
	// (get) Token: 0x060010B4 RID: 4276 RVA: 0x0008494D File Offset: 0x00082B4D
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

	// Token: 0x060010B5 RID: 4277 RVA: 0x00084981 File Offset: 0x00082B81
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Pixelisation_Dot");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010B6 RID: 4278 RVA: 0x000849A4 File Offset: 0x00082BA4
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
			this.material.SetFloat("_Value2", this.LightBackGround);
			this.material.SetFloat("_Value3", this.Speed);
			this.material.SetFloat("_Value4", this.Size2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010B7 RID: 4279 RVA: 0x00084A9C File Offset: 0x00082C9C
	private void Update()
	{
	}

	// Token: 0x060010B8 RID: 4280 RVA: 0x00084A9E File Offset: 0x00082C9E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400153D RID: 5437
	public Shader SCShader;

	// Token: 0x0400153E RID: 5438
	private float TimeX = 1f;

	// Token: 0x0400153F RID: 5439
	private Material SCMaterial;

	// Token: 0x04001540 RID: 5440
	[Range(0.0001f, 0.5f)]
	public float Size = 0.005f;

	// Token: 0x04001541 RID: 5441
	[Range(0f, 1f)]
	public float LightBackGround = 0.3f;

	// Token: 0x04001542 RID: 5442
	[Range(0f, 10f)]
	private float Speed = 1f;

	// Token: 0x04001543 RID: 5443
	[Range(0f, 10f)]
	private float Size2 = 1f;
}
