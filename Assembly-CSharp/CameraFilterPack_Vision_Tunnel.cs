using System;
using UnityEngine;

// Token: 0x0200022F RID: 559
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Tunnel")]
public class CameraFilterPack_Vision_Tunnel : MonoBehaviour
{
	// Token: 0x17000334 RID: 820
	// (get) Token: 0x060011FF RID: 4607 RVA: 0x0008A2C0 File Offset: 0x000884C0
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

	// Token: 0x06001200 RID: 4608 RVA: 0x0008A2F4 File Offset: 0x000884F4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Tunnel");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001201 RID: 4609 RVA: 0x0008A318 File Offset: 0x00088518
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

	// Token: 0x06001202 RID: 4610 RVA: 0x0008A410 File Offset: 0x00088610
	private void Update()
	{
	}

	// Token: 0x06001203 RID: 4611 RVA: 0x0008A412 File Offset: 0x00088612
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040016A1 RID: 5793
	public Shader SCShader;

	// Token: 0x040016A2 RID: 5794
	private float TimeX = 1f;

	// Token: 0x040016A3 RID: 5795
	private Material SCMaterial;

	// Token: 0x040016A4 RID: 5796
	[Range(0f, 1f)]
	public float Value = 0.6f;

	// Token: 0x040016A5 RID: 5797
	[Range(0f, 1f)]
	public float Value2 = 0.4f;

	// Token: 0x040016A6 RID: 5798
	[Range(0f, 1f)]
	public float Intensity = 1f;

	// Token: 0x040016A7 RID: 5799
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
