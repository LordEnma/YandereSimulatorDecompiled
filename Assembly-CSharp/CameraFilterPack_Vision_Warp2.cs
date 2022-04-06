using System;
using UnityEngine;

// Token: 0x02000232 RID: 562
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Warp2")]
public class CameraFilterPack_Vision_Warp2 : MonoBehaviour
{
	// Token: 0x17000336 RID: 822
	// (get) Token: 0x06001211 RID: 4625 RVA: 0x0008B033 File Offset: 0x00089233
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

	// Token: 0x06001212 RID: 4626 RVA: 0x0008B067 File Offset: 0x00089267
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Warp2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001213 RID: 4627 RVA: 0x0008B088 File Offset: 0x00089288
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
			this.material.SetFloat("_Value3", this.Intensity);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001214 RID: 4628 RVA: 0x0008B180 File Offset: 0x00089380
	private void Update()
	{
	}

	// Token: 0x06001215 RID: 4629 RVA: 0x0008B182 File Offset: 0x00089382
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040016C7 RID: 5831
	public Shader SCShader;

	// Token: 0x040016C8 RID: 5832
	private float TimeX = 1f;

	// Token: 0x040016C9 RID: 5833
	private Material SCMaterial;

	// Token: 0x040016CA RID: 5834
	[Range(0f, 1f)]
	public float Value = 0.5f;

	// Token: 0x040016CB RID: 5835
	[Range(0f, 1f)]
	public float Value2 = 0.2f;

	// Token: 0x040016CC RID: 5836
	[Range(-1f, 2f)]
	public float Intensity = 1f;

	// Token: 0x040016CD RID: 5837
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
