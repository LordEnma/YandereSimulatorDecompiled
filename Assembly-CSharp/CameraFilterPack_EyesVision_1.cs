using System;
using UnityEngine;

// Token: 0x020001A6 RID: 422
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Eyes 1")]
public class CameraFilterPack_EyesVision_1 : MonoBehaviour
{
	// Token: 0x170002AA RID: 682
	// (get) Token: 0x06000EA4 RID: 3748 RVA: 0x0007B104 File Offset: 0x00079304
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

	// Token: 0x06000EA5 RID: 3749 RVA: 0x0007B138 File Offset: 0x00079338
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_eyes_vision_1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/EyesVision_1");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EA6 RID: 3750 RVA: 0x0007B170 File Offset: 0x00079370
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
			this.material.SetFloat("_Value", this._EyeWave);
			this.material.SetFloat("_Value2", this._EyeSpeed);
			this.material.SetFloat("_Value3", this._EyeMove);
			this.material.SetFloat("_Value4", this._EyeBlink);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EA7 RID: 3751 RVA: 0x0007B251 File Offset: 0x00079451
	private void Update()
	{
	}

	// Token: 0x06000EA8 RID: 3752 RVA: 0x0007B253 File Offset: 0x00079453
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012F7 RID: 4855
	public Shader SCShader;

	// Token: 0x040012F8 RID: 4856
	private float TimeX = 1f;

	// Token: 0x040012F9 RID: 4857
	[Range(1f, 32f)]
	public float _EyeWave = 15f;

	// Token: 0x040012FA RID: 4858
	[Range(0f, 10f)]
	public float _EyeSpeed = 1f;

	// Token: 0x040012FB RID: 4859
	[Range(0f, 8f)]
	public float _EyeMove = 2f;

	// Token: 0x040012FC RID: 4860
	[Range(0f, 1f)]
	public float _EyeBlink = 1f;

	// Token: 0x040012FD RID: 4861
	private Material SCMaterial;

	// Token: 0x040012FE RID: 4862
	private Texture2D Texture2;
}
