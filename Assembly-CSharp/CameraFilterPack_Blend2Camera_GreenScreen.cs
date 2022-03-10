using System;
using UnityEngine;

// Token: 0x02000131 RID: 305
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Chroma Key/GreenScreen")]
public class CameraFilterPack_Blend2Camera_GreenScreen : MonoBehaviour
{
	// Token: 0x17000235 RID: 565
	// (get) Token: 0x06000BB9 RID: 3001 RVA: 0x0006E523 File Offset: 0x0006C723
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

	// Token: 0x06000BBA RID: 3002 RVA: 0x0006E558 File Offset: 0x0006C758
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

	// Token: 0x06000BBB RID: 3003 RVA: 0x0006E5CC File Offset: 0x0006C7CC
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

	// Token: 0x06000BBC RID: 3004 RVA: 0x0006E6FD File Offset: 0x0006C8FD
	private void Update()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
		bool isPlaying = Application.isPlaying;
	}

	// Token: 0x06000BBD RID: 3005 RVA: 0x0006E727 File Offset: 0x0006C927
	private void OnEnable()
	{
		this.Start();
		this.Update();
	}

	// Token: 0x06000BBE RID: 3006 RVA: 0x0006E738 File Offset: 0x0006C938
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

	// Token: 0x04000FF2 RID: 4082
	private string ShaderName = "CameraFilterPack/Blend2Camera_GreenScreen";

	// Token: 0x04000FF3 RID: 4083
	public Shader SCShader;

	// Token: 0x04000FF4 RID: 4084
	public Camera Camera2;

	// Token: 0x04000FF5 RID: 4085
	private float TimeX = 1f;

	// Token: 0x04000FF6 RID: 4086
	private Material SCMaterial;

	// Token: 0x04000FF7 RID: 4087
	[Range(0f, 1f)]
	public float BlendFX = 1f;

	// Token: 0x04000FF8 RID: 4088
	[Range(-0.2f, 0.2f)]
	public float Adjust;

	// Token: 0x04000FF9 RID: 4089
	[Range(-0.2f, 0.2f)]
	public float Precision;

	// Token: 0x04000FFA RID: 4090
	[Range(-0.2f, 0.2f)]
	public float Luminosity;

	// Token: 0x04000FFB RID: 4091
	[Range(-0.3f, 0.3f)]
	public float Change_Red;

	// Token: 0x04000FFC RID: 4092
	[Range(-0.3f, 0.3f)]
	public float Change_Green;

	// Token: 0x04000FFD RID: 4093
	[Range(-0.3f, 0.3f)]
	public float Change_Blue;

	// Token: 0x04000FFE RID: 4094
	private RenderTexture Camera2tex;

	// Token: 0x04000FFF RID: 4095
	private Vector2 ScreenSize;
}
