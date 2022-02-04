using System;
using UnityEngine;

// Token: 0x02000227 RID: 551
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Blood")]
public class CameraFilterPack_Vision_Blood : MonoBehaviour
{
	// Token: 0x1700032B RID: 811
	// (get) Token: 0x060011CC RID: 4556 RVA: 0x000893D8 File Offset: 0x000875D8
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

	// Token: 0x060011CD RID: 4557 RVA: 0x0008940C File Offset: 0x0008760C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Blood");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011CE RID: 4558 RVA: 0x00089430 File Offset: 0x00087630
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

	// Token: 0x060011CF RID: 4559 RVA: 0x00089528 File Offset: 0x00087728
	private void Update()
	{
	}

	// Token: 0x060011D0 RID: 4560 RVA: 0x0008952A File Offset: 0x0008772A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400165A RID: 5722
	public Shader SCShader;

	// Token: 0x0400165B RID: 5723
	private float TimeX = 1f;

	// Token: 0x0400165C RID: 5724
	private Material SCMaterial;

	// Token: 0x0400165D RID: 5725
	[Range(0.01f, 1f)]
	public float HoleSize = 0.6f;

	// Token: 0x0400165E RID: 5726
	[Range(-1f, 1f)]
	public float HoleSmooth = 0.3f;

	// Token: 0x0400165F RID: 5727
	[Range(-2f, 2f)]
	public float Color1 = 0.2f;

	// Token: 0x04001660 RID: 5728
	[Range(-2f, 2f)]
	public float Color2 = 0.9f;
}
