using System;
using UnityEngine;

// Token: 0x0200017E RID: 382
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Noise")]
public class CameraFilterPack_Distortion_Noise : MonoBehaviour
{
	// Token: 0x17000283 RID: 643
	// (get) Token: 0x06000DB5 RID: 3509 RVA: 0x0007708D File Offset: 0x0007528D
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

	// Token: 0x06000DB6 RID: 3510 RVA: 0x000770C1 File Offset: 0x000752C1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Noise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DB7 RID: 3511 RVA: 0x000770E4 File Offset: 0x000752E4
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
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DB8 RID: 3512 RVA: 0x00077193 File Offset: 0x00075393
	private void Update()
	{
	}

	// Token: 0x06000DB9 RID: 3513 RVA: 0x00077195 File Offset: 0x00075395
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011F3 RID: 4595
	public Shader SCShader;

	// Token: 0x040011F4 RID: 4596
	private float TimeX = 1f;

	// Token: 0x040011F5 RID: 4597
	private Material SCMaterial;

	// Token: 0x040011F6 RID: 4598
	[Range(0f, 3f)]
	public float Distortion = 1f;
}
