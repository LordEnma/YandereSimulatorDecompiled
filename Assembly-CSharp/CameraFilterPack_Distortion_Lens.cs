using System;
using UnityEngine;

// Token: 0x0200017E RID: 382
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Lens")]
public class CameraFilterPack_Distortion_Lens : MonoBehaviour
{
	// Token: 0x17000282 RID: 642
	// (get) Token: 0x06000DB3 RID: 3507 RVA: 0x0007737C File Offset: 0x0007557C
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

	// Token: 0x06000DB4 RID: 3508 RVA: 0x000773B0 File Offset: 0x000755B0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Lens");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DB5 RID: 3509 RVA: 0x000773D4 File Offset: 0x000755D4
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
			this.material.SetFloat("_CenterX", this.CenterX);
			this.material.SetFloat("_CenterY", this.CenterY);
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DB6 RID: 3510 RVA: 0x000774AF File Offset: 0x000756AF
	private void Update()
	{
	}

	// Token: 0x06000DB7 RID: 3511 RVA: 0x000774B1 File Offset: 0x000756B1
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011F5 RID: 4597
	public Shader SCShader;

	// Token: 0x040011F6 RID: 4598
	private float TimeX = 1f;

	// Token: 0x040011F7 RID: 4599
	private Material SCMaterial;

	// Token: 0x040011F8 RID: 4600
	[Range(-1f, 1f)]
	public float CenterX;

	// Token: 0x040011F9 RID: 4601
	[Range(-1f, 1f)]
	public float CenterY;

	// Token: 0x040011FA RID: 4602
	[Range(0f, 3f)]
	public float Distortion = 1f;
}
