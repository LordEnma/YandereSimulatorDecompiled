using System;
using UnityEngine;

// Token: 0x02000201 RID: 513
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Special/Bubble")]
public class CameraFilterPack_Special_Bubble : MonoBehaviour
{
	// Token: 0x17000305 RID: 773
	// (get) Token: 0x060010EB RID: 4331 RVA: 0x0008616D File Offset: 0x0008436D
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

	// Token: 0x060010EC RID: 4332 RVA: 0x000861A1 File Offset: 0x000843A1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Special_Bubble");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010ED RID: 4333 RVA: 0x000861C4 File Offset: 0x000843C4
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
			this.material.SetFloat("_Value", this.X);
			this.material.SetFloat("_Value2", this.Y);
			this.material.SetFloat("_Value3", this.Rate);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010EE RID: 4334 RVA: 0x000862BC File Offset: 0x000844BC
	private void Update()
	{
	}

	// Token: 0x060010EF RID: 4335 RVA: 0x000862BE File Offset: 0x000844BE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001588 RID: 5512
	public Shader SCShader;

	// Token: 0x04001589 RID: 5513
	private float TimeX = 1f;

	// Token: 0x0400158A RID: 5514
	private Material SCMaterial;

	// Token: 0x0400158B RID: 5515
	[Range(-4f, 4f)]
	public float X = 0.5f;

	// Token: 0x0400158C RID: 5516
	[Range(-4f, 4f)]
	public float Y = 0.5f;

	// Token: 0x0400158D RID: 5517
	[Range(0f, 5f)]
	public float Rate = 1f;

	// Token: 0x0400158E RID: 5518
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
