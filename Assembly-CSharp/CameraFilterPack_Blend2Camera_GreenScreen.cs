using System;
using UnityEngine;

// Token: 0x02000130 RID: 304
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Chroma Key/GreenScreen")]
public class CameraFilterPack_Blend2Camera_GreenScreen : MonoBehaviour
{
	// Token: 0x17000235 RID: 565
	// (get) Token: 0x06000BB5 RID: 2997 RVA: 0x0006DF7F File Offset: 0x0006C17F
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

	// Token: 0x06000BB6 RID: 2998 RVA: 0x0006DFB4 File Offset: 0x0006C1B4
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture((int)this.ScreenSize.x, (int)this.ScreenSize.y, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000BB7 RID: 2999 RVA: 0x0006E028 File Offset: 0x0006C228
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			if (this.Camera2 != null)
			{
				this.material.SetTexture("_MainTex2", this.Camera2tex);
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.BlendFX);
			this.material.SetFloat("_Value2", this.Adjust);
			this.material.SetFloat("_Value3", this.Precision);
			this.material.SetFloat("_Value4", this.Luminosity);
			this.material.SetFloat("_Value5", this.Change_Red);
			this.material.SetFloat("_Value6", this.Change_Green);
			this.material.SetFloat("_Value7", this.Change_Blue);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000BB8 RID: 3000 RVA: 0x0006E159 File Offset: 0x0006C359
	private void Update()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
		bool isPlaying = Application.isPlaying;
	}

	// Token: 0x06000BB9 RID: 3001 RVA: 0x0006E183 File Offset: 0x0006C383
	private void OnEnable()
	{
		this.Start();
		this.Update();
	}

	// Token: 0x06000BBA RID: 3002 RVA: 0x0006E194 File Offset: 0x0006C394
	private void OnDisable()
	{
		if (this.Camera2 != null && this.Camera2.targetTexture != null)
		{
			this.Camera2.targetTexture = null;
		}
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000FE1 RID: 4065
	private string ShaderName = "CameraFilterPack/Blend2Camera_GreenScreen";

	// Token: 0x04000FE2 RID: 4066
	public Shader SCShader;

	// Token: 0x04000FE3 RID: 4067
	public Camera Camera2;

	// Token: 0x04000FE4 RID: 4068
	private float TimeX = 1f;

	// Token: 0x04000FE5 RID: 4069
	private Material SCMaterial;

	// Token: 0x04000FE6 RID: 4070
	[Range(0f, 1f)]
	public float BlendFX = 1f;

	// Token: 0x04000FE7 RID: 4071
	[Range(-0.2f, 0.2f)]
	public float Adjust;

	// Token: 0x04000FE8 RID: 4072
	[Range(-0.2f, 0.2f)]
	public float Precision;

	// Token: 0x04000FE9 RID: 4073
	[Range(-0.2f, 0.2f)]
	public float Luminosity;

	// Token: 0x04000FEA RID: 4074
	[Range(-0.3f, 0.3f)]
	public float Change_Red;

	// Token: 0x04000FEB RID: 4075
	[Range(-0.3f, 0.3f)]
	public float Change_Green;

	// Token: 0x04000FEC RID: 4076
	[Range(-0.3f, 0.3f)]
	public float Change_Blue;

	// Token: 0x04000FED RID: 4077
	private RenderTexture Camera2tex;

	// Token: 0x04000FEE RID: 4078
	private Vector2 ScreenSize;
}
