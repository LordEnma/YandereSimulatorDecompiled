using System;
using UnityEngine;

// Token: 0x0200020E RID: 526
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/LED")]
public class CameraFilterPack_TV_LED : MonoBehaviour
{
	// Token: 0x17000313 RID: 787
	// (get) Token: 0x06001139 RID: 4409 RVA: 0x00086F57 File Offset: 0x00085157
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

	// Token: 0x0600113A RID: 4410 RVA: 0x00086F8B File Offset: 0x0008518B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_LED");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600113B RID: 4411 RVA: 0x00086FAC File Offset: 0x000851AC
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
			this.material.SetFloat("_Size", (float)this.Size);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600113C RID: 4412 RVA: 0x0008708F File Offset: 0x0008528F
	private void Update()
	{
	}

	// Token: 0x0600113D RID: 4413 RVA: 0x00087091 File Offset: 0x00085291
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015CE RID: 5582
	public Shader SCShader;

	// Token: 0x040015CF RID: 5583
	private float TimeX = 1f;

	// Token: 0x040015D0 RID: 5584
	[Range(0f, 1f)]
	public float Fade;

	// Token: 0x040015D1 RID: 5585
	[Range(1f, 10f)]
	private float Distortion = 1f;

	// Token: 0x040015D2 RID: 5586
	[Range(1f, 15f)]
	public int Size = 5;

	// Token: 0x040015D3 RID: 5587
	private Material SCMaterial;
}
