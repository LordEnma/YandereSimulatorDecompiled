using System;
using UnityEngine;

// Token: 0x020001DB RID: 475
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Light/Water")]
public class CameraFilterPack_Light_Water : MonoBehaviour
{
	// Token: 0x170002DF RID: 735
	// (get) Token: 0x06000FE4 RID: 4068 RVA: 0x00080C64 File Offset: 0x0007EE64
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

	// Token: 0x06000FE5 RID: 4069 RVA: 0x00080C98 File Offset: 0x0007EE98
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Light_Water");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FE6 RID: 4070 RVA: 0x00080CBC File Offset: 0x0007EEBC
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

	// Token: 0x06000FE7 RID: 4071 RVA: 0x00080DA5 File Offset: 0x0007EFA5
	private void Update()
	{
	}

	// Token: 0x06000FE8 RID: 4072 RVA: 0x00080DA7 File Offset: 0x0007EFA7
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001463 RID: 5219
	public Shader SCShader;

	// Token: 0x04001464 RID: 5220
	private float TimeX = 1f;

	// Token: 0x04001465 RID: 5221
	private Material SCMaterial;

	// Token: 0x04001466 RID: 5222
	[Range(0f, 1f)]
	public float Size = 4f;

	// Token: 0x04001467 RID: 5223
	[Range(0f, 2f)]
	public float Alpha = 0.07f;

	// Token: 0x04001468 RID: 5224
	[Range(0f, 32f)]
	public float Distance = 10f;

	// Token: 0x04001469 RID: 5225
	[Range(-2f, 2f)]
	public float Speed = 0.4f;
}
