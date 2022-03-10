using System;
using UnityEngine;

// Token: 0x020001D1 RID: 465
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Electric")]
public class CameraFilterPack_Gradients_ElectricGradient : MonoBehaviour
{
	// Token: 0x170002D5 RID: 725
	// (get) Token: 0x06000FA6 RID: 4006 RVA: 0x0007F9B8 File Offset: 0x0007DBB8
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

	// Token: 0x06000FA7 RID: 4007 RVA: 0x0007F9EC File Offset: 0x0007DBEC
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FA8 RID: 4008 RVA: 0x0007FA10 File Offset: 0x0007DC10
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

	// Token: 0x06000FA9 RID: 4009 RVA: 0x0007FADC File Offset: 0x0007DCDC
	private void Update()
	{
	}

	// Token: 0x06000FAA RID: 4010 RVA: 0x0007FADE File Offset: 0x0007DCDE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001424 RID: 5156
	public Shader SCShader;

	// Token: 0x04001425 RID: 5157
	private string ShaderName = "CameraFilterPack/Gradients_ElectricGradient";

	// Token: 0x04001426 RID: 5158
	private float TimeX = 1f;

	// Token: 0x04001427 RID: 5159
	private Material SCMaterial;

	// Token: 0x04001428 RID: 5160
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001429 RID: 5161
	[Range(0f, 1f)]
	public float Fade = 1f;
}
