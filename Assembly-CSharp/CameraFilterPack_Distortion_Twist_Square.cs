using System;
using UnityEngine;

// Token: 0x02000183 RID: 387
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Twist_Square")]
public class CameraFilterPack_Distortion_Twist_Square : MonoBehaviour
{
	// Token: 0x17000287 RID: 647
	// (get) Token: 0x06000DD3 RID: 3539 RVA: 0x000780E0 File Offset: 0x000762E0
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

	// Token: 0x06000DD4 RID: 3540 RVA: 0x00078114 File Offset: 0x00076314
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Twist_Square");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DD5 RID: 3541 RVA: 0x00078138 File Offset: 0x00076338
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
			this.material.SetFloat("_Size", this.Size);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DD6 RID: 3542 RVA: 0x00078229 File Offset: 0x00076429
	private void Update()
	{
	}

	// Token: 0x06000DD7 RID: 3543 RVA: 0x0007822B File Offset: 0x0007642B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001224 RID: 4644
	public Shader SCShader;

	// Token: 0x04001225 RID: 4645
	private float TimeX = 1f;

	// Token: 0x04001226 RID: 4646
	private Material SCMaterial;

	// Token: 0x04001227 RID: 4647
	[Range(-2f, 2f)]
	public float CenterX = 0.5f;

	// Token: 0x04001228 RID: 4648
	[Range(-2f, 2f)]
	public float CenterY = 0.5f;

	// Token: 0x04001229 RID: 4649
	[Range(-3.14f, 3.14f)]
	public float Distortion = 0.5f;

	// Token: 0x0400122A RID: 4650
	[Range(-2f, 2f)]
	public float Size = 0.25f;
}
