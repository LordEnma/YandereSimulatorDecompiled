using System;
using UnityEngine;

// Token: 0x02000228 RID: 552
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Crystal")]
public class CameraFilterPack_Vision_Crystal : MonoBehaviour
{
	// Token: 0x1700032D RID: 813
	// (get) Token: 0x060011D5 RID: 4565 RVA: 0x00089533 File Offset: 0x00087733
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

	// Token: 0x060011D6 RID: 4566 RVA: 0x00089567 File Offset: 0x00087767
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Crystal");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011D7 RID: 4567 RVA: 0x00089588 File Offset: 0x00087788
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
			this.material.SetFloat("_Value2", this.X);
			this.material.SetFloat("_Value3", this.Y);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011D8 RID: 4568 RVA: 0x00089680 File Offset: 0x00087880
	private void Update()
	{
	}

	// Token: 0x060011D9 RID: 4569 RVA: 0x00089682 File Offset: 0x00087882
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001663 RID: 5731
	public Shader SCShader;

	// Token: 0x04001664 RID: 5732
	private float TimeX = 1f;

	// Token: 0x04001665 RID: 5733
	private Material SCMaterial;

	// Token: 0x04001666 RID: 5734
	[Range(-10f, 10f)]
	public float Value = 1f;

	// Token: 0x04001667 RID: 5735
	[Range(-1f, 1f)]
	public float X = 1f;

	// Token: 0x04001668 RID: 5736
	[Range(-1f, 1f)]
	public float Y = 1f;

	// Token: 0x04001669 RID: 5737
	[Range(-1f, 1f)]
	private float Value4 = 1f;
}
