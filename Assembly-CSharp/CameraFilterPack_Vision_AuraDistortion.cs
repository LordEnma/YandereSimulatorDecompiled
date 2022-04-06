using System;
using UnityEngine;

// Token: 0x02000226 RID: 550
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/AuraDistortion")]
public class CameraFilterPack_Vision_AuraDistortion : MonoBehaviour
{
	// Token: 0x1700032A RID: 810
	// (get) Token: 0x060011C9 RID: 4553 RVA: 0x00089A18 File Offset: 0x00087C18
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

	// Token: 0x060011CA RID: 4554 RVA: 0x00089A4C File Offset: 0x00087C4C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_AuraDistortion");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011CB RID: 4555 RVA: 0x00089A70 File Offset: 0x00087C70
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
			this.material.SetFloat("_Value", this.Twist);
			this.material.SetColor("_Value2", this.Color);
			this.material.SetFloat("_Value3", this.PosX);
			this.material.SetFloat("_Value4", this.PosY);
			this.material.SetFloat("_Value5", this.Speed);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011CC RID: 4556 RVA: 0x00089B7E File Offset: 0x00087D7E
	private void Update()
	{
	}

	// Token: 0x060011CD RID: 4557 RVA: 0x00089B80 File Offset: 0x00087D80
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001665 RID: 5733
	public Shader SCShader;

	// Token: 0x04001666 RID: 5734
	private float TimeX = 1f;

	// Token: 0x04001667 RID: 5735
	private Material SCMaterial;

	// Token: 0x04001668 RID: 5736
	[Range(0f, 2f)]
	public float Twist = 1f;

	// Token: 0x04001669 RID: 5737
	[Range(-4f, 4f)]
	public float Speed = 1f;

	// Token: 0x0400166A RID: 5738
	public Color Color = new Color(0.16f, 0.57f, 0.19f);

	// Token: 0x0400166B RID: 5739
	[Range(-1f, 2f)]
	public float PosX = 0.5f;

	// Token: 0x0400166C RID: 5740
	[Range(-1f, 2f)]
	public float PosY = 0.5f;
}
