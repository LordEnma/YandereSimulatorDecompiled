using System;
using UnityEngine;

// Token: 0x02000200 RID: 512
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Special/Bubble")]
public class CameraFilterPack_Special_Bubble : MonoBehaviour
{
	// Token: 0x17000305 RID: 773
	// (get) Token: 0x060010E5 RID: 4325 RVA: 0x0008574D File Offset: 0x0008394D
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

	// Token: 0x060010E6 RID: 4326 RVA: 0x00085781 File Offset: 0x00083981
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Special_Bubble");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010E7 RID: 4327 RVA: 0x000857A4 File Offset: 0x000839A4
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

	// Token: 0x060010E8 RID: 4328 RVA: 0x0008589C File Offset: 0x00083A9C
	private void Update()
	{
	}

	// Token: 0x060010E9 RID: 4329 RVA: 0x0008589E File Offset: 0x00083A9E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001570 RID: 5488
	public Shader SCShader;

	// Token: 0x04001571 RID: 5489
	private float TimeX = 1f;

	// Token: 0x04001572 RID: 5490
	private Material SCMaterial;

	// Token: 0x04001573 RID: 5491
	[Range(-4f, 4f)]
	public float X = 0.5f;

	// Token: 0x04001574 RID: 5492
	[Range(-4f, 4f)]
	public float Y = 0.5f;

	// Token: 0x04001575 RID: 5493
	[Range(0f, 5f)]
	public float Rate = 1f;

	// Token: 0x04001576 RID: 5494
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
