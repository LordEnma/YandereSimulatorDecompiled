using System;
using UnityEngine;

// Token: 0x02000231 RID: 561
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Warp")]
public class CameraFilterPack_Vision_Warp : MonoBehaviour
{
	// Token: 0x17000335 RID: 821
	// (get) Token: 0x06001209 RID: 4617 RVA: 0x0008A8C7 File Offset: 0x00088AC7
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

	// Token: 0x0600120A RID: 4618 RVA: 0x0008A8FB File Offset: 0x00088AFB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Warp");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600120B RID: 4619 RVA: 0x0008A91C File Offset: 0x00088B1C
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
			this.material.SetFloat("_Value", this.Value);
			this.material.SetFloat("_Value2", this.Value2);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600120C RID: 4620 RVA: 0x0008AA14 File Offset: 0x00088C14
	private void Update()
	{
	}

	// Token: 0x0600120D RID: 4621 RVA: 0x0008AA16 File Offset: 0x00088C16
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040016B0 RID: 5808
	public Shader SCShader;

	// Token: 0x040016B1 RID: 5809
	private float TimeX = 1f;

	// Token: 0x040016B2 RID: 5810
	private Material SCMaterial;

	// Token: 0x040016B3 RID: 5811
	[Range(0f, 1f)]
	public float Value = 0.6f;

	// Token: 0x040016B4 RID: 5812
	[Range(0f, 1f)]
	public float Value2 = 0.6f;

	// Token: 0x040016B5 RID: 5813
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x040016B6 RID: 5814
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
