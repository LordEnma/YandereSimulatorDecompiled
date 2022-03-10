using System;
using UnityEngine;

// Token: 0x020001A7 RID: 423
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Eyes 2")]
public class CameraFilterPack_EyesVision_2 : MonoBehaviour
{
	// Token: 0x170002AB RID: 683
	// (get) Token: 0x06000EAA RID: 3754 RVA: 0x0007B2AC File Offset: 0x000794AC
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

	// Token: 0x06000EAB RID: 3755 RVA: 0x0007B2E0 File Offset: 0x000794E0
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_eyes_vision_2") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/EyesVision_2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EAC RID: 3756 RVA: 0x0007B318 File Offset: 0x00079518
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

	// Token: 0x06000EAD RID: 3757 RVA: 0x0007B3F9 File Offset: 0x000795F9
	private void Update()
	{
	}

	// Token: 0x06000EAE RID: 3758 RVA: 0x0007B3FB File Offset: 0x000795FB
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012FF RID: 4863
	public Shader SCShader;

	// Token: 0x04001300 RID: 4864
	private float TimeX = 1f;

	// Token: 0x04001301 RID: 4865
	[Range(1f, 32f)]
	public float _EyeWave = 15f;

	// Token: 0x04001302 RID: 4866
	[Range(0f, 10f)]
	public float _EyeSpeed = 1f;

	// Token: 0x04001303 RID: 4867
	[Range(0f, 8f)]
	public float _EyeMove = 2f;

	// Token: 0x04001304 RID: 4868
	[Range(0f, 1f)]
	public float _EyeBlink = 1f;

	// Token: 0x04001305 RID: 4869
	private Material SCMaterial;

	// Token: 0x04001306 RID: 4870
	private Texture2D Texture2;
}
