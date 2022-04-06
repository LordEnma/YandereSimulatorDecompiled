using System;
using UnityEngine;

// Token: 0x020001D0 RID: 464
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Desert")]
public class CameraFilterPack_Gradients_Desert : MonoBehaviour
{
	// Token: 0x170002D4 RID: 724
	// (get) Token: 0x06000FA2 RID: 4002 RVA: 0x0007FCC0 File Offset: 0x0007DEC0
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

	// Token: 0x06000FA3 RID: 4003 RVA: 0x0007FCF4 File Offset: 0x0007DEF4
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FA4 RID: 4004 RVA: 0x0007FD18 File Offset: 0x0007DF18
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

	// Token: 0x06000FA5 RID: 4005 RVA: 0x0007FDE4 File Offset: 0x0007DFE4
	private void Update()
	{
	}

	// Token: 0x06000FA6 RID: 4006 RVA: 0x0007FDE6 File Offset: 0x0007DFE6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001425 RID: 5157
	public Shader SCShader;

	// Token: 0x04001426 RID: 5158
	private string ShaderName = "CameraFilterPack/Gradients_Desert";

	// Token: 0x04001427 RID: 5159
	private float TimeX = 1f;

	// Token: 0x04001428 RID: 5160
	private Material SCMaterial;

	// Token: 0x04001429 RID: 5161
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x0400142A RID: 5162
	[Range(0f, 1f)]
	public float Fade = 1f;
}
