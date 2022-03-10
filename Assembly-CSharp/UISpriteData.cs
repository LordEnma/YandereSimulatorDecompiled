using System;

// Token: 0x020000AC RID: 172
[Serializable]
public class UISpriteData
{
	// Token: 0x170001C8 RID: 456
	// (get) Token: 0x060008A4 RID: 2212 RVA: 0x00046E45 File Offset: 0x00045045
	public bool hasBorder
	{
		get
		{
			return (this.borderLeft | this.borderRight | this.borderTop | this.borderBottom) != 0;
		}
	}

	// Token: 0x170001C9 RID: 457
	// (get) Token: 0x060008A5 RID: 2213 RVA: 0x00046E65 File Offset: 0x00045065
	public bool hasPadding
	{
		get
		{
			return (this.paddingLeft | this.paddingRight | this.paddingTop | this.paddingBottom) != 0;
		}
	}

	// Token: 0x060008A6 RID: 2214 RVA: 0x00046E85 File Offset: 0x00045085
	public void SetRect(int x, int y, int width, int height)
	{
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
	}

	// Token: 0x060008A7 RID: 2215 RVA: 0x00046EA4 File Offset: 0x000450A4
	public void SetPadding(int left, int bottom, int right, int top)
	{
		this.paddingLeft = left;
		this.paddingBottom = bottom;
		this.paddingRight = right;
		this.paddingTop = top;
	}

	// Token: 0x060008A8 RID: 2216 RVA: 0x00046EC3 File Offset: 0x000450C3
	public void SetBorder(int left, int bottom, int right, int top)
	{
		this.borderLeft = left;
		this.borderBottom = bottom;
		this.borderRight = right;
		this.borderTop = top;
	}

	// Token: 0x060008A9 RID: 2217 RVA: 0x00046EE4 File Offset: 0x000450E4
	public void CopyFrom(UISpriteData sd)
	{
		this.name = sd.name;
		this.x = sd.x;
		this.y = sd.y;
		this.width = sd.width;
		this.height = sd.height;
		this.borderLeft = sd.borderLeft;
		this.borderRight = sd.borderRight;
		this.borderTop = sd.borderTop;
		this.borderBottom = sd.borderBottom;
		this.paddingLeft = sd.paddingLeft;
		this.paddingRight = sd.paddingRight;
		this.paddingTop = sd.paddingTop;
		this.paddingBottom = sd.paddingBottom;
	}

	// Token: 0x060008AA RID: 2218 RVA: 0x00046F8D File Offset: 0x0004518D
	public void CopyBorderFrom(UISpriteData sd)
	{
		this.borderLeft = sd.borderLeft;
		this.borderRight = sd.borderRight;
		this.borderTop = sd.borderTop;
		this.borderBottom = sd.borderBottom;
	}

	// Token: 0x04000775 RID: 1909
	public string name = "Sprite";

	// Token: 0x04000776 RID: 1910
	public int x;

	// Token: 0x04000777 RID: 1911
	public int y;

	// Token: 0x04000778 RID: 1912
	public int width;

	// Token: 0x04000779 RID: 1913
	public int height;

	// Token: 0x0400077A RID: 1914
	public int borderLeft;

	// Token: 0x0400077B RID: 1915
	public int borderRight;

	// Token: 0x0400077C RID: 1916
	public int borderTop;

	// Token: 0x0400077D RID: 1917
	public int borderBottom;

	// Token: 0x0400077E RID: 1918
	public int paddingLeft;

	// Token: 0x0400077F RID: 1919
	public int paddingRight;

	// Token: 0x04000780 RID: 1920
	public int paddingTop;

	// Token: 0x04000781 RID: 1921
	public int paddingBottom;
}
