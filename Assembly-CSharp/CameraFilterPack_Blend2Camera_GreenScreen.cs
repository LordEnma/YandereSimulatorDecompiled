using System;
using UnityEngine;

// Token: 0x02000131 RID: 305
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Chroma Key/GreenScreen")]
public class CameraFilterPack_Blend2Camera_GreenScreen : MonoBehaviour
{
	// Token: 0x17000235 RID: 565
	// (get) Token: 0x06000BB8 RID: 3000 RVA: 0x0006E177 File Offset: 0x0006C377
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

	// Token: 0x06000BB9 RID: 3001 RVA: 0x0006E1AC File Offset: 0x0006C3AC
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

	// Token: 0x06000BBA RID: 3002 RVA: 0x0006E220 File Offset: 0x0006C420
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

	// Token: 0x06000BBB RID: 3003 RVA: 0x0006E351 File Offset: 0x0006C551
	private void Update()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
		bool isPlaying = Application.isPlaying;
	}

	// Token: 0x06000BBC RID: 3004 RVA: 0x0006E37B File Offset: 0x0006C57B
	private void OnEnable()
	{
		this.Start();
		this.Update();
	}

	// Token: 0x06000BBD RID: 3005 RVA: 0x0006E38C File Offset: 0x0006C58C
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

	// Token: 0x04000FE6 RID: 4070
	private string ShaderName = "CameraFilterPack/Blend2Camera_GreenScreen";

	// Token: 0x04000FE7 RID: 4071
	public Shader SCShader;

	// Token: 0x04000FE8 RID: 4072
	public Camera Camera2;

	// Token: 0x04000FE9 RID: 4073
	private float TimeX = 1f;

	// Token: 0x04000FEA RID: 4074
	private Material SCMaterial;

	// Token: 0x04000FEB RID: 4075
	[Range(0f, 1f)]
	public float BlendFX = 1f;

	// Token: 0x04000FEC RID: 4076
	[Range(-0.2f, 0.2f)]
	public float Adjust;

	// Token: 0x04000FED RID: 4077
	[Range(-0.2f, 0.2f)]
	public float Precision;

	// Token: 0x04000FEE RID: 4078
	[Range(-0.2f, 0.2f)]
	public float Luminosity;

	// Token: 0x04000FEF RID: 4079
	[Range(-0.3f, 0.3f)]
	public float Change_Red;

	// Token: 0x04000FF0 RID: 4080
	[Range(-0.3f, 0.3f)]
	public float Change_Green;

	// Token: 0x04000FF1 RID: 4081
	[Range(-0.3f, 0.3f)]
	public float Change_Blue;

	// Token: 0x04000FF2 RID: 4082
	private RenderTexture Camera2tex;

	// Token: 0x04000FF3 RID: 4083
	private Vector2 ScreenSize;
}
