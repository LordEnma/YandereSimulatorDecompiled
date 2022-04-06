using System;
using UnityEngine;

// Token: 0x0200012E RID: 302
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Difference")]
public class CameraFilterPack_Blend2Camera_Difference : MonoBehaviour
{
	// Token: 0x17000232 RID: 562
	// (get) Token: 0x06000BA3 RID: 2979 RVA: 0x0006E297 File Offset: 0x0006C497
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

	// Token: 0x06000BA4 RID: 2980 RVA: 0x0006E2CC File Offset: 0x0006C4CC
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

	// Token: 0x06000BA5 RID: 2981 RVA: 0x0006E330 File Offset: 0x0006C530
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

	// Token: 0x06000BA6 RID: 2982 RVA: 0x0006E420 File Offset: 0x0006C620
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BA7 RID: 2983 RVA: 0x0006E458 File Offset: 0x0006C658
	private void Update()
	{
	}

	// Token: 0x06000BA8 RID: 2984 RVA: 0x0006E45A File Offset: 0x0006C65A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BA9 RID: 2985 RVA: 0x0006E492 File Offset: 0x0006C692
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

	// Token: 0x04000FE1 RID: 4065
	private string ShaderName = "CameraFilterPack/Blend2Camera_Difference";

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
	public float SwitchCameraToCamera2;

	// Token: 0x04000FE7 RID: 4071
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FE8 RID: 4072
	private RenderTexture Camera2tex;
}
