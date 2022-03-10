using System;
using UnityEngine;

// Token: 0x02000229 RID: 553
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Crystal")]
public class CameraFilterPack_Vision_Crystal : MonoBehaviour
{
	// Token: 0x1700032D RID: 813
	// (get) Token: 0x060011D9 RID: 4569 RVA: 0x00089AD7 File Offset: 0x00087CD7
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

	// Token: 0x060011DA RID: 4570 RVA: 0x00089B0B File Offset: 0x00087D0B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Crystal");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011DB RID: 4571 RVA: 0x00089B2C File Offset: 0x00087D2C
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

	// Token: 0x060011DC RID: 4572 RVA: 0x00089C24 File Offset: 0x00087E24
	private void Update()
	{
	}

	// Token: 0x060011DD RID: 4573 RVA: 0x00089C26 File Offset: 0x00087E26
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001674 RID: 5748
	public Shader SCShader;

	// Token: 0x04001675 RID: 5749
	private float TimeX = 1f;

	// Token: 0x04001676 RID: 5750
	private Material SCMaterial;

	// Token: 0x04001677 RID: 5751
	[Range(-10f, 10f)]
	public float Value = 1f;

	// Token: 0x04001678 RID: 5752
	[Range(-1f, 1f)]
	public float X = 1f;

	// Token: 0x04001679 RID: 5753
	[Range(-1f, 1f)]
	public float Y = 1f;

	// Token: 0x0400167A RID: 5754
	[Range(-1f, 1f)]
	private float Value4 = 1f;
}
