using System;
using UnityEngine;

// Token: 0x020001B1 RID: 433
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Earth Quake")]
public class CameraFilterPack_FX_EarthQuake : MonoBehaviour
{
	// Token: 0x170002B5 RID: 693
	// (get) Token: 0x06000EE8 RID: 3816 RVA: 0x0007C78F File Offset: 0x0007A98F
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

	// Token: 0x06000EE9 RID: 3817 RVA: 0x0007C7C3 File Offset: 0x0007A9C3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_EarthQuake");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EEA RID: 3818 RVA: 0x0007C7E4 File Offset: 0x0007A9E4
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
			this.material.SetFloat("_Value", this.Speed);
			this.material.SetFloat("_Value2", this.X);
			this.material.SetFloat("_Value3", this.Y);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EEB RID: 3819 RVA: 0x0007C8DC File Offset: 0x0007AADC
	private void Update()
	{
	}

	// Token: 0x06000EEC RID: 3820 RVA: 0x0007C8DE File Offset: 0x0007AADE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400134D RID: 4941
	public Shader SCShader;

	// Token: 0x0400134E RID: 4942
	private float TimeX = 1f;

	// Token: 0x0400134F RID: 4943
	private Material SCMaterial;

	// Token: 0x04001350 RID: 4944
	[Range(0f, 100f)]
	public float Speed = 15f;

	// Token: 0x04001351 RID: 4945
	[Range(0f, 0.2f)]
	public float X = 0.008f;

	// Token: 0x04001352 RID: 4946
	[Range(0f, 0.2f)]
	public float Y = 0.008f;

	// Token: 0x04001353 RID: 4947
	[Range(0f, 0.2f)]
	private float Value4 = 1f;
}
