using System;

// Token: 0x020003F6 RID: 1014
[Serializable]
public class EventSaveData
{
	// Token: 0x06001BEB RID: 7147 RVA: 0x00143E37 File Offset: 0x00142037
	public static EventSaveData ReadFromGlobals()
	{
		return new EventSaveData
		{
			befriendConversation = EventGlobals.BefriendConversation,
			event1 = EventGlobals.Event1,
			event2 = EventGlobals.Event2,
			kidnapConversation = EventGlobals.KidnapConversation,
			livingRoom = EventGlobals.LivingRoom
		};
	}

	// Token: 0x06001BEC RID: 7148 RVA: 0x00143E75 File Offset: 0x00142075
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x040030FA RID: 12538
	public bool befriendConversation;

	// Token: 0x040030FB RID: 12539
	public bool event1;

	// Token: 0x040030FC RID: 12540
	public bool event2;

	// Token: 0x040030FD RID: 12541
	public bool kidnapConversation;

	// Token: 0x040030FE RID: 12542
	public bool livingRoom;
}
