using System;

// Token: 0x020000AC RID: 172
[Serializable]
public class UISpriteData
{
	// Token: 0x170001C8 RID: 456
	// (get) Token: 0x060008A4 RID: 2212 RVA: 0x00046D55 File Offset: 0x00044F55
	public bool hasBorder
	{
		get
		{
			return (this.borderLeft | this.borderRight | this.borderTop | this.borderBottom) != 0;
		}
	}

	// Token: 0x170001C9 RID: 457
	// (get) Token: 0x060008A5 RID: 2213 RVA: 0x00046D75 File Offset: 0x00044F75
	public bool hasPadding
	{
		get
		{
			return (this.paddingLeft | this.paddingRight | this.paddingTop | this.paddingBottom) != 0;
		}
	}

	// Token: 0x060008A6 RID: 2214 RVA: 0x00046D95 File Offset: 0x00044F95
	public void SetRect(int x, int y, int width, int height)
	{
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
	}

	// Token: 0x060008A7 RID: 2215 RVA: 0x00046DB4 File Offset: 0x00044FB4
	public void SetPadding(int left, int bottom, int right, int top)
	{
		this.paddingLeft = left;
		this.paddingBottom = bottom;
		this.paddingRight = right;
		this.paddingTop = top;
	}

	// Token: 0x060008A8 RID: 2216 RVA: 0x00046DD3 File Offset: 0x00044FD3
	public void SetBorder(int left, int bottom, int right, int top)
	{
		this.borderLeft = left;
		this.borderBottom = bottom;
		this.borderRight = right;
		this.borderTop = top;
	}

	// Token: 0x060008A9 RID: 2217 RVA: 0x00046DF4 File Offset: 0x00044FF4
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

	// Token: 0x060008AA RID: 2218 RVA: 0x00046E9D File Offset: 0x0004509D
	public void CopyBorderFrom(UISpriteData sd)
	{
		this.borderLeft = sd.borderLeft;
		this.borderRight = sd.borderRight;
		this.borderTop = sd.borderTop;
		this.borderBottom = sd.borderBottom;
	}

	// Token: 0x0400076A RID: 1898
	public string name = "Sprite";

	// Token: 0x0400076B RID: 1899
	public int x;

	// Token: 0x0400076C RID: 1900
	public int y;

	// Token: 0x0400076D RID: 1901
	public int width;

	// Token: 0x0400076E RID: 1902
	public int height;

	// Token: 0x0400076F RID: 1903
	public int borderLeft;

	// Token: 0x04000770 RID: 1904
	public int borderRight;

	// Token: 0x04000771 RID: 1905
	public int borderTop;

	// Token: 0x04000772 RID: 1906
	public int borderBottom;

	// Token: 0x04000773 RID: 1907
	public int paddingLeft;

	// Token: 0x04000774 RID: 1908
	public int paddingRight;

	// Token: 0x04000775 RID: 1909
	public int paddingTop;

	// Token: 0x04000776 RID: 1910
	public int paddingBottom;
}
