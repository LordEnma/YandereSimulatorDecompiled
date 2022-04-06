using System;
using UnityEngine;

// Token: 0x020001A6 RID: 422
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Eyes 1")]
public class CameraFilterPack_EyesVision_1 : MonoBehaviour
{
	// Token: 0x170002AA RID: 682
	// (get) Token: 0x06000EA6 RID: 3750 RVA: 0x0007B580 File Offset: 0x00079780
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

	// Token: 0x06000EA7 RID: 3751 RVA: 0x0007B5B4 File Offset: 0x000797B4
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

	// Token: 0x06000EA8 RID: 3752 RVA: 0x0007B5EC File Offset: 0x000797EC
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

	// Token: 0x06000EA9 RID: 3753 RVA: 0x0007B6CD File Offset: 0x000798CD
	private void Update()
	{
	}

	// Token: 0x06000EAA RID: 3754 RVA: 0x0007B6CF File Offset: 0x000798CF
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012FE RID: 4862
	public Shader SCShader;

	// Token: 0x040012FF RID: 4863
	private float TimeX = 1f;

	// Token: 0x04001300 RID: 4864
	[Range(1f, 32f)]
	public float _EyeWave = 15f;

	// Token: 0x04001301 RID: 4865
	[Range(0f, 10f)]
	public float _EyeSpeed = 1f;

	// Token: 0x04001302 RID: 4866
	[Range(0f, 8f)]
	public float _EyeMove = 2f;

	// Token: 0x04001303 RID: 4867
	[Range(0f, 1f)]
	public float _EyeBlink = 1f;

	// Token: 0x04001304 RID: 4868
	private Material SCMaterial;

	// Token: 0x04001305 RID: 4869
	private Texture2D Texture2;
}
