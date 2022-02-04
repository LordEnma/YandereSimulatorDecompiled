using System;
using UnityEngine;

// Token: 0x020001D5 RID: 469
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Rainbow")]
public class CameraFilterPack_Gradients_Rainbow : MonoBehaviour
{
	// Token: 0x170002D9 RID: 729
	// (get) Token: 0x06000FBD RID: 4029 RVA: 0x0007FBDC File Offset: 0x0007DDDC
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

	// Token: 0x06000FBE RID: 4030 RVA: 0x0007FC10 File Offset: 0x0007DE10
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FBF RID: 4031 RVA: 0x0007FC34 File Offset: 0x0007DE34
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

	// Token: 0x06000FC0 RID: 4032 RVA: 0x0007FD00 File Offset: 0x0007DF00
	private void Update()
	{
	}

	// Token: 0x06000FC1 RID: 4033 RVA: 0x0007FD02 File Offset: 0x0007DF02
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001430 RID: 5168
	public Shader SCShader;

	// Token: 0x04001431 RID: 5169
	private string ShaderName = "CameraFilterPack/Gradients_Rainbow";

	// Token: 0x04001432 RID: 5170
	private float TimeX = 1f;

	// Token: 0x04001433 RID: 5171
	private Material SCMaterial;

	// Token: 0x04001434 RID: 5172
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001435 RID: 5173
	[Range(0f, 1f)]
	public float Fade = 1f;
}
