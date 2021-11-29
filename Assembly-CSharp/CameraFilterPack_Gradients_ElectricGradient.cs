using System;
using UnityEngine;

// Token: 0x020001D0 RID: 464
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Electric")]
public class CameraFilterPack_Gradients_ElectricGradient : MonoBehaviour
{
	// Token: 0x170002D5 RID: 725
	// (get) Token: 0x06000FA2 RID: 4002 RVA: 0x0007F414 File Offset: 0x0007D614
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

	// Token: 0x06000FA3 RID: 4003 RVA: 0x0007F448 File Offset: 0x0007D648
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FA4 RID: 4004 RVA: 0x0007F46C File Offset: 0x0007D66C
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

	// Token: 0x06000FA5 RID: 4005 RVA: 0x0007F538 File Offset: 0x0007D738
	private void Update()
	{
	}

	// Token: 0x06000FA6 RID: 4006 RVA: 0x0007F53A File Offset: 0x0007D73A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001413 RID: 5139
	public Shader SCShader;

	// Token: 0x04001414 RID: 5140
	private string ShaderName = "CameraFilterPack/Gradients_ElectricGradient";

	// Token: 0x04001415 RID: 5141
	private float TimeX = 1f;

	// Token: 0x04001416 RID: 5142
	private Material SCMaterial;

	// Token: 0x04001417 RID: 5143
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001418 RID: 5144
	[Range(0f, 1f)]
	public float Fade = 1f;
}
