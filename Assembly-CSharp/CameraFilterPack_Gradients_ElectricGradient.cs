using System;
using UnityEngine;

// Token: 0x020001D1 RID: 465
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Electric")]
public class CameraFilterPack_Gradients_ElectricGradient : MonoBehaviour
{
	// Token: 0x170002D5 RID: 725
	// (get) Token: 0x06000FA8 RID: 4008 RVA: 0x0007FE34 File Offset: 0x0007E034
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

	// Token: 0x06000FA9 RID: 4009 RVA: 0x0007FE68 File Offset: 0x0007E068
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FAA RID: 4010 RVA: 0x0007FE8C File Offset: 0x0007E08C
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
			this.material.SetFloat("_Value", this.Switch);
			this.material.SetFloat("_Value2", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000FAB RID: 4011 RVA: 0x0007FF58 File Offset: 0x0007E158
	private void Update()
	{
	}

	// Token: 0x06000FAC RID: 4012 RVA: 0x0007FF5A File Offset: 0x0007E15A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400142B RID: 5163
	public Shader SCShader;

	// Token: 0x0400142C RID: 5164
	private string ShaderName = "CameraFilterPack/Gradients_ElectricGradient";

	// Token: 0x0400142D RID: 5165
	private float TimeX = 1f;

	// Token: 0x0400142E RID: 5166
	private Material SCMaterial;

	// Token: 0x0400142F RID: 5167
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001430 RID: 5168
	[Range(0f, 1f)]
	public float Fade = 1f;
}
