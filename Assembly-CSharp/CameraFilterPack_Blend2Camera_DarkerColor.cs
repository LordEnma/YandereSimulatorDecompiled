using System;
using UnityEngine;

// Token: 0x0200012D RID: 301
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/DarkerColor")]
public class CameraFilterPack_Blend2Camera_DarkerColor : MonoBehaviour
{
	// Token: 0x17000231 RID: 561
	// (get) Token: 0x06000B98 RID: 2968 RVA: 0x0006D817 File Offset: 0x0006BA17
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

	// Token: 0x06000B99 RID: 2969 RVA: 0x0006D84C File Offset: 0x0006BA4C
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

	// Token: 0x06000B9A RID: 2970 RVA: 0x0006D8B0 File Offset: 0x0006BAB0
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

	// Token: 0x06000B9B RID: 2971 RVA: 0x0006D9A0 File Offset: 0x0006BBA0
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B9C RID: 2972 RVA: 0x0006D9D8 File Offset: 0x0006BBD8
	private void Update()
	{
	}

	// Token: 0x06000B9D RID: 2973 RVA: 0x0006D9DA File Offset: 0x0006BBDA
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B9E RID: 2974 RVA: 0x0006DA12 File Offset: 0x0006BC12
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

	// Token: 0x04000FC6 RID: 4038
	private string ShaderName = "CameraFilterPack/Blend2Camera_DarkerColor";

	// Token: 0x04000FC7 RID: 4039
	public Shader SCShader;

	// Token: 0x04000FC8 RID: 4040
	public Camera Camera2;

	// Token: 0x04000FC9 RID: 4041
	private float TimeX = 1f;

	// Token: 0x04000FCA RID: 4042
	private Material SCMaterial;

	// Token: 0x04000FCB RID: 4043
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FCC RID: 4044
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FCD RID: 4045
	private RenderTexture Camera2tex;
}
