using System;
using UnityEngine;

// Token: 0x020001DA RID: 474
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Light/Water")]
public class CameraFilterPack_Light_Water : MonoBehaviour
{
	// Token: 0x170002DF RID: 735
	// (get) Token: 0x06000FDE RID: 4062 RVA: 0x00080244 File Offset: 0x0007E444
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

	// Token: 0x06000FDF RID: 4063 RVA: 0x00080278 File Offset: 0x0007E478
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Light_Water");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FE0 RID: 4064 RVA: 0x0008029C File Offset: 0x0007E49C
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime * this.Speed;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Alpha", this.Alpha);
			this.material.SetFloat("_Distance", this.Distance);
			this.material.SetFloat("_Size", this.Size);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000FE1 RID: 4065 RVA: 0x00080385 File Offset: 0x0007E585
	private void Update()
	{
	}

	// Token: 0x06000FE2 RID: 4066 RVA: 0x00080387 File Offset: 0x0007E587
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400144B RID: 5195
	public Shader SCShader;

	// Token: 0x0400144C RID: 5196
	private float TimeX = 1f;

	// Token: 0x0400144D RID: 5197
	private Material SCMaterial;

	// Token: 0x0400144E RID: 5198
	[Range(0f, 1f)]
	public float Size = 4f;

	// Token: 0x0400144F RID: 5199
	[Range(0f, 2f)]
	public float Alpha = 0.07f;

	// Token: 0x04001450 RID: 5200
	[Range(0f, 32f)]
	public float Distance = 10f;

	// Token: 0x04001451 RID: 5201
	[Range(-2f, 2f)]
	public float Speed = 0.4f;
}
