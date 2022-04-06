using System;
using UnityEngine;

// Token: 0x02000144 RID: 324
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Subtract")]
public class CameraFilterPack_Blend2Camera_Subtract : MonoBehaviour
{
	// Token: 0x17000248 RID: 584
	// (get) Token: 0x06000C53 RID: 3155 RVA: 0x00071A41 File Offset: 0x0006FC41
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

	// Token: 0x06000C54 RID: 3156 RVA: 0x00071A78 File Offset: 0x0006FC78
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

	// Token: 0x06000C55 RID: 3157 RVA: 0x00071ADC File Offset: 0x0006FCDC
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

	// Token: 0x06000C56 RID: 3158 RVA: 0x00071BCC File Offset: 0x0006FDCC
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C57 RID: 3159 RVA: 0x00071C04 File Offset: 0x0006FE04
	private void Update()
	{
	}

	// Token: 0x06000C58 RID: 3160 RVA: 0x00071C06 File Offset: 0x0006FE06
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C59 RID: 3161 RVA: 0x00071C3E File Offset: 0x0006FE3E
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

	// Token: 0x040010A8 RID: 4264
	private string ShaderName = "CameraFilterPack/Blend2Camera_Subtract";

	// Token: 0x040010A9 RID: 4265
	public Shader SCShader;

	// Token: 0x040010AA RID: 4266
	public Camera Camera2;

	// Token: 0x040010AB RID: 4267
	private float TimeX = 1f;

	// Token: 0x040010AC RID: 4268
	private Material SCMaterial;

	// Token: 0x040010AD RID: 4269
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x040010AE RID: 4270
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x040010AF RID: 4271
	private RenderTexture Camera2tex;
}
