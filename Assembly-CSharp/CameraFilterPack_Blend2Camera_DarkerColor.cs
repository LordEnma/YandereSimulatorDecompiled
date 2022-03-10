using System;
using UnityEngine;

// Token: 0x0200012D RID: 301
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/DarkerColor")]
public class CameraFilterPack_Blend2Camera_DarkerColor : MonoBehaviour
{
	// Token: 0x17000231 RID: 561
	// (get) Token: 0x06000B99 RID: 2969 RVA: 0x0006DBC3 File Offset: 0x0006BDC3
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

	// Token: 0x06000B9A RID: 2970 RVA: 0x0006DBF8 File Offset: 0x0006BDF8
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

	// Token: 0x06000B9B RID: 2971 RVA: 0x0006DC5C File Offset: 0x0006BE5C
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

	// Token: 0x06000B9C RID: 2972 RVA: 0x0006DD4C File Offset: 0x0006BF4C
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B9D RID: 2973 RVA: 0x0006DD84 File Offset: 0x0006BF84
	private void Update()
	{
	}

	// Token: 0x06000B9E RID: 2974 RVA: 0x0006DD86 File Offset: 0x0006BF86
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B9F RID: 2975 RVA: 0x0006DDBE File Offset: 0x0006BFBE
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

	// Token: 0x04000FD2 RID: 4050
	private string ShaderName = "CameraFilterPack/Blend2Camera_DarkerColor";

	// Token: 0x04000FD3 RID: 4051
	public Shader SCShader;

	// Token: 0x04000FD4 RID: 4052
	public Camera Camera2;

	// Token: 0x04000FD5 RID: 4053
	private float TimeX = 1f;

	// Token: 0x04000FD6 RID: 4054
	private Material SCMaterial;

	// Token: 0x04000FD7 RID: 4055
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FD8 RID: 4056
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FD9 RID: 4057
	private RenderTexture Camera2tex;
}
