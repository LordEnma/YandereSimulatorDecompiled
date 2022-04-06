using System;
using UnityEngine;

// Token: 0x02000131 RID: 305
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Chroma Key/GreenScreen")]
public class CameraFilterPack_Blend2Camera_GreenScreen : MonoBehaviour
{
	// Token: 0x17000235 RID: 565
	// (get) Token: 0x06000BBB RID: 3003 RVA: 0x0006E99F File Offset: 0x0006CB9F
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

	// Token: 0x06000BBC RID: 3004 RVA: 0x0006E9D4 File Offset: 0x0006CBD4
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

	// Token: 0x06000BBD RID: 3005 RVA: 0x0006EA48 File Offset: 0x0006CC48
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

	// Token: 0x06000BBE RID: 3006 RVA: 0x0006EB79 File Offset: 0x0006CD79
	private void Update()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
		bool isPlaying = Application.isPlaying;
	}

	// Token: 0x06000BBF RID: 3007 RVA: 0x0006EBA3 File Offset: 0x0006CDA3
	private void OnEnable()
	{
		this.Start();
		this.Update();
	}

	// Token: 0x06000BC0 RID: 3008 RVA: 0x0006EBB4 File Offset: 0x0006CDB4
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

	// Token: 0x04000FF9 RID: 4089
	private string ShaderName = "CameraFilterPack/Blend2Camera_GreenScreen";

	// Token: 0x04000FFA RID: 4090
	public Shader SCShader;

	// Token: 0x04000FFB RID: 4091
	public Camera Camera2;

	// Token: 0x04000FFC RID: 4092
	private float TimeX = 1f;

	// Token: 0x04000FFD RID: 4093
	private Material SCMaterial;

	// Token: 0x04000FFE RID: 4094
	[Range(0f, 1f)]
	public float BlendFX = 1f;

	// Token: 0x04000FFF RID: 4095
	[Range(-0.2f, 0.2f)]
	public float Adjust;

	// Token: 0x04001000 RID: 4096
	[Range(-0.2f, 0.2f)]
	public float Precision;

	// Token: 0x04001001 RID: 4097
	[Range(-0.2f, 0.2f)]
	public float Luminosity;

	// Token: 0x04001002 RID: 4098
	[Range(-0.3f, 0.3f)]
	public float Change_Red;

	// Token: 0x04001003 RID: 4099
	[Range(-0.3f, 0.3f)]
	public float Change_Green;

	// Token: 0x04001004 RID: 4100
	[Range(-0.3f, 0.3f)]
	public float Change_Blue;

	// Token: 0x04001005 RID: 4101
	private RenderTexture Camera2tex;

	// Token: 0x04001006 RID: 4102
	private Vector2 ScreenSize;
}
