using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000097 RID: 151
public interface INGUIAtlas
{
	// Token: 0x170000D6 RID: 214
	// (get) Token: 0x06000603 RID: 1539
	// (set) Token: 0x06000604 RID: 1540
	Material spriteMaterial { get; set; }

	// Token: 0x170000D7 RID: 215
	// (get) Token: 0x06000605 RID: 1541
	// (set) Token: 0x06000606 RID: 1542
	List<UISpriteData> spriteList { get; set; }

	// Token: 0x170000D8 RID: 216
	// (get) Token: 0x06000607 RID: 1543
	Texture texture { get; }

	// Token: 0x170000D9 RID: 217
	// (get) Token: 0x06000608 RID: 1544
	// (set) Token: 0x06000609 RID: 1545
	float pixelSize { get; set; }

	// Token: 0x170000DA RID: 218
	// (get) Token: 0x0600060A RID: 1546
	bool premultipliedAlpha { get; }

	// Token: 0x170000DB RID: 219
	// (get) Token: 0x0600060B RID: 1547
	// (set) Token: 0x0600060C RID: 1548
	INGUIAtlas replacement { get; set; }

	// Token: 0x0600060D RID: 1549
	UISpriteData GetSprite(string name);

	// Token: 0x0600060E RID: 1550
	BetterList<string> GetListOfSprites();

	// Token: 0x0600060F RID: 1551
	BetterList<string> GetListOfSprites(string match);

	// Token: 0x06000610 RID: 1552
	bool References(INGUIAtlas atlas);

	// Token: 0x06000611 RID: 1553
	void MarkAsChanged();

	// Token: 0x06000612 RID: 1554
	void SortAlphabetically();
}
