using System;
using UnityEngine;

// Token: 0x020001F9 RID: 505
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixelisation/Dot")]
public class CameraFilterPack_Pixelisation_Dot : MonoBehaviour
{
	// Token: 0x170002FD RID: 765
	// (get) Token: 0x060010B7 RID: 4279 RVA: 0x00084B45 File Offset: 0x00082D45
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

	// Token: 0x060010B8 RID: 4280 RVA: 0x00084B79 File Offset: 0x00082D79
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Pixelisation_Dot");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010B9 RID: 4281 RVA: 0x00084B9C File Offset: 0x00082D9C
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

	// Token: 0x060010BA RID: 4282 RVA: 0x00084C94 File Offset: 0x00082E94
	private void Update()
	{
	}

	// Token: 0x060010BB RID: 4283 RVA: 0x00084C96 File Offset: 0x00082E96
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001542 RID: 5442
	public Shader SCShader;

	// Token: 0x04001543 RID: 5443
	private float TimeX = 1f;

	// Token: 0x04001544 RID: 5444
	private Material SCMaterial;

	// Token: 0x04001545 RID: 5445
	[Range(0.0001f, 0.5f)]
	public float Size = 0.005f;

	// Token: 0x04001546 RID: 5446
	[Range(0f, 1f)]
	public float LightBackGround = 0.3f;

	// Token: 0x04001547 RID: 5447
	[Range(0f, 10f)]
	private float Speed = 1f;

	// Token: 0x04001548 RID: 5448
	[Range(0f, 10f)]
	private float Size2 = 1f;
}
