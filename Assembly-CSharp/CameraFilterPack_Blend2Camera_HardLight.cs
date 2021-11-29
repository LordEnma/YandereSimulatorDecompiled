using System;
using UnityEngine;

// Token: 0x02000131 RID: 305
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/HardLight")]
public class CameraFilterPack_Blend2Camera_HardLight : MonoBehaviour
{
	// Token: 0x17000236 RID: 566
	// (get) Token: 0x06000BBC RID: 3004 RVA: 0x0006E20F File Offset: 0x0006C40F
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

	// Token: 0x06000BBD RID: 3005 RVA: 0x0006E244 File Offset: 0x0006C444
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000BBE RID: 3006 RVA: 0x0006E2A8 File Offset: 0x0006C4A8
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
			this.material.SetFloat("_Value2", this.SwitchCameraToCamera2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000BBF RID: 3007 RVA: 0x0006E398 File Offset: 0x0006C598
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BC0 RID: 3008 RVA: 0x0006E3D0 File Offset: 0x0006C5D0
	private void Update()
	{
	}

	// Token: 0x06000BC1 RID: 3009 RVA: 0x0006E3D2 File Offset: 0x0006C5D2
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BC2 RID: 3010 RVA: 0x0006E40A File Offset: 0x0006C60A
	private void OnDisable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2.targetTexture = null;
		}
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000FEF RID: 4079
	private string ShaderName = "CameraFilterPack/Blend2Camera_HardLight";

	// Token: 0x04000FF0 RID: 4080
	public Shader SCShader;

	// Token: 0x04000FF1 RID: 4081
	public Camera Camera2;

	// Token: 0x04000FF2 RID: 4082
	private float TimeX = 1f;

	// Token: 0x04000FF3 RID: 4083
	private Material SCMaterial;

	// Token: 0x04000FF4 RID: 4084
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FF5 RID: 4085
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FF6 RID: 4086
	private RenderTexture Camera2tex;
}
