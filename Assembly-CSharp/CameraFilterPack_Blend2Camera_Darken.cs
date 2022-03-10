using System;
using UnityEngine;

// Token: 0x0200012C RID: 300
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Darken")]
public class CameraFilterPack_Blend2Camera_Darken : MonoBehaviour
{
	// Token: 0x17000230 RID: 560
	// (get) Token: 0x06000B91 RID: 2961 RVA: 0x0006D96B File Offset: 0x0006BB6B
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

	// Token: 0x06000B92 RID: 2962 RVA: 0x0006D9A0 File Offset: 0x0006BBA0
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

	// Token: 0x06000B93 RID: 2963 RVA: 0x0006DA04 File Offset: 0x0006BC04
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

	// Token: 0x06000B94 RID: 2964 RVA: 0x0006DAF4 File Offset: 0x0006BCF4
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B95 RID: 2965 RVA: 0x0006DB2C File Offset: 0x0006BD2C
	private void Update()
	{
	}

	// Token: 0x06000B96 RID: 2966 RVA: 0x0006DB2E File Offset: 0x0006BD2E
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B97 RID: 2967 RVA: 0x0006DB66 File Offset: 0x0006BD66
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

	// Token: 0x04000FCA RID: 4042
	private string ShaderName = "CameraFilterPack/Blend2Camera_Darken";

	// Token: 0x04000FCB RID: 4043
	public Shader SCShader;

	// Token: 0x04000FCC RID: 4044
	public Camera Camera2;

	// Token: 0x04000FCD RID: 4045
	private float TimeX = 1f;

	// Token: 0x04000FCE RID: 4046
	private Material SCMaterial;

	// Token: 0x04000FCF RID: 4047
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FD0 RID: 4048
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FD1 RID: 4049
	private RenderTexture Camera2tex;
}
