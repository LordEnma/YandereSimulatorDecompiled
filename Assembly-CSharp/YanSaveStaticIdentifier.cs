using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000513 RID: 1299
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x0400492C RID: 18732
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x0400492D RID: 18733
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x0400492E RID: 18734
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
