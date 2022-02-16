using System;
using UnityEngine;

// Token: 0x020001DB RID: 475
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Light/Water")]
public class CameraFilterPack_Light_Water : MonoBehaviour
{
	// Token: 0x170002DF RID: 735
	// (get) Token: 0x06000FE2 RID: 4066 RVA: 0x0008058C File Offset: 0x0007E78C
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

	// Token: 0x06000FE3 RID: 4067 RVA: 0x000805C0 File Offset: 0x0007E7C0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Light_Water");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FE4 RID: 4068 RVA: 0x000805E4 File Offset: 0x0007E7E4
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

	// Token: 0x06000FE5 RID: 4069 RVA: 0x000806CD File Offset: 0x0007E8CD
	private void Update()
	{
	}

	// Token: 0x06000FE6 RID: 4070 RVA: 0x000806CF File Offset: 0x0007E8CF
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001453 RID: 5203
	public Shader SCShader;

	// Token: 0x04001454 RID: 5204
	private float TimeX = 1f;

	// Token: 0x04001455 RID: 5205
	private Material SCMaterial;

	// Token: 0x04001456 RID: 5206
	[Range(0f, 1f)]
	public float Size = 4f;

	// Token: 0x04001457 RID: 5207
	[Range(0f, 2f)]
	public float Alpha = 0.07f;

	// Token: 0x04001458 RID: 5208
	[Range(0f, 32f)]
	public float Distance = 10f;

	// Token: 0x04001459 RID: 5209
	[Range(-2f, 2f)]
	public float Speed = 0.4f;
}
