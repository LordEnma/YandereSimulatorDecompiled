using System;
using UnityEngine;

// Token: 0x0200017F RID: 383
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Noise")]
public class CameraFilterPack_Distortion_Noise : MonoBehaviour
{
	// Token: 0x17000283 RID: 643
	// (get) Token: 0x06000DB8 RID: 3512 RVA: 0x00077285 File Offset: 0x00075485
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

	// Token: 0x06000DB9 RID: 3513 RVA: 0x000772B9 File Offset: 0x000754B9
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Noise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DBA RID: 3514 RVA: 0x000772DC File Offset: 0x000754DC
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

	// Token: 0x06000DBB RID: 3515 RVA: 0x0007738B File Offset: 0x0007558B
	private void Update()
	{
	}

	// Token: 0x06000DBC RID: 3516 RVA: 0x0007738D File Offset: 0x0007558D
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011F8 RID: 4600
	public Shader SCShader;

	// Token: 0x040011F9 RID: 4601
	private float TimeX = 1f;

	// Token: 0x040011FA RID: 4602
	private Material SCMaterial;

	// Token: 0x040011FB RID: 4603
	[Range(0f, 3f)]
	public float Distortion = 1f;
}
