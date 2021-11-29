using System;
using UnityEngine;

// Token: 0x02000226 RID: 550
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Blood")]
public class CameraFilterPack_Vision_Blood : MonoBehaviour
{
	// Token: 0x1700032B RID: 811
	// (get) Token: 0x060011C9 RID: 4553 RVA: 0x000891E0 File Offset: 0x000873E0
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

	// Token: 0x060011CA RID: 4554 RVA: 0x00089214 File Offset: 0x00087414
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Blood");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011CB RID: 4555 RVA: 0x00089238 File Offset: 0x00087438
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
			this.material.SetFloat("_Value", this.HoleSize);
			this.material.SetFloat("_Value2", this.HoleSmooth);
			this.material.SetFloat("_Value3", this.Color1);
			this.material.SetFloat("_Value4", this.Color2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011CC RID: 4556 RVA: 0x00089330 File Offset: 0x00087530
	private void Update()
	{
	}

	// Token: 0x060011CD RID: 4557 RVA: 0x00089332 File Offset: 0x00087532
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001655 RID: 5717
	public Shader SCShader;

	// Token: 0x04001656 RID: 5718
	private float TimeX = 1f;

	// Token: 0x04001657 RID: 5719
	private Material SCMaterial;

	// Token: 0x04001658 RID: 5720
	[Range(0.01f, 1f)]
	public float HoleSize = 0.6f;

	// Token: 0x04001659 RID: 5721
	[Range(-1f, 1f)]
	public float HoleSmooth = 0.3f;

	// Token: 0x0400165A RID: 5722
	[Range(-2f, 2f)]
	public float Color1 = 0.2f;

	// Token: 0x0400165B RID: 5723
	[Range(-2f, 2f)]
	public float Color2 = 0.9f;
}
