using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000099 RID: 153
public interface INGUIFont
{
	// Token: 0x170000E2 RID: 226
	// (get) Token: 0x06000625 RID: 1573
	// (set) Token: 0x06000626 RID: 1574
	BMFont bmFont { get; set; }

	// Token: 0x170000E3 RID: 227
	// (get) Token: 0x06000627 RID: 1575
	// (set) Token: 0x06000628 RID: 1576
	int texWidth { get; set; }

	// Token: 0x170000E4 RID: 228
	// (get) Token: 0x06000629 RID: 1577
	// (set) Token: 0x0600062A RID: 1578
	int texHeight { get; set; }

	// Token: 0x170000E5 RID: 229
	// (get) Token: 0x0600062B RID: 1579
	bool hasSymbols { get; }

	// Token: 0x170000E6 RID: 230
	// (get) Token: 0x0600062C RID: 1580
	// (set) Token: 0x0600062D RID: 1581
	List<BMSymbol> symbols { get; set; }

	// Token: 0x170000E7 RID: 231
	// (get) Token: 0x0600062E RID: 1582
	// (set) Token: 0x0600062F RID: 1583
	INGUIAtlas atlas { get; set; }

	// Token: 0x06000630 RID: 1584
	UISpriteData GetSprite(string spriteName);

	// Token: 0x170000E8 RID: 232
	// (get) Token: 0x06000631 RID: 1585
	// (set) Token: 0x06000632 RID: 1586
	Material material { get; set; }

	// Token: 0x170000E9 RID: 233
	// (get) Token: 0x06000633 RID: 1587
	bool premultipliedAlphaShader { get; }

	// Token: 0x170000EA RID: 234
	// (get) Token: 0x06000634 RID: 1588
	bool packedFontShader { get; }

	// Token: 0x170000EB RID: 235
	// (get) Token: 0x06000635 RID: 1589
	Texture2D texture { get; }

	// Token: 0x170000EC RID: 236
	// (get) Token: 0x06000636 RID: 1590
	// (set) Token: 0x06000637 RID: 1591
	Rect uvRect { get; set; }

	// Token: 0x170000ED RID: 237
	// (get) Token: 0x06000638 RID: 1592
	// (set) Token: 0x06000639 RID: 1593
	string spriteName { get; set; }

	// Token: 0x170000EE RID: 238
	// (get) Token: 0x0600063A RID: 1594
	bool isValid { get; }

	// Token: 0x170000EF RID: 239
	// (get) Token: 0x0600063B RID: 1595
	// (set) Token: 0x0600063C RID: 1596
	int defaultSize { get; set; }

	// Token: 0x170000F0 RID: 240
	// (get) Token: 0x0600063D RID: 1597
	UISpriteData sprite { get; }

	// Token: 0x170000F1 RID: 241
	// (get) Token: 0x0600063E RID: 1598
	// (set) Token: 0x0600063F RID: 1599
	INGUIFont replacement { get; set; }

	// Token: 0x170000F2 RID: 242
	// (get) Token: 0x06000640 RID: 1600
	INGUIFont finalFont { get; }

	// Token: 0x170000F3 RID: 243
	// (get) Token: 0x06000641 RID: 1601
	bool isDynamic { get; }

	// Token: 0x170000F4 RID: 244
	// (get) Token: 0x06000642 RID: 1602
	// (set) Token: 0x06000643 RID: 1603
	Font dynamicFont { get; set; }

	// Token: 0x170000F5 RID: 245
	// (get) Token: 0x06000644 RID: 1604
	// (set) Token: 0x06000645 RID: 1605
	FontStyle dynamicFontStyle { get; set; }

	// Token: 0x06000646 RID: 1606
	bool References(INGUIFont font);

	// Token: 0x06000647 RID: 1607
	void MarkAsChanged();

	// Token: 0x06000648 RID: 1608
	void UpdateUVRect();

	// Token: 0x06000649 RID: 1609
	BMSymbol MatchSymbol(string text, int offset, int textLength);

	// Token: 0x0600064A RID: 1610
	void AddSymbol(string sequence, string spriteName);

	// Token: 0x0600064B RID: 1611
	void RemoveSymbol(string sequence);

	// Token: 0x0600064C RID: 1612
	void RenameSymbol(string before, string after);

	// Token: 0x0600064D RID: 1613
	bool UsesSprite(string s);
}
