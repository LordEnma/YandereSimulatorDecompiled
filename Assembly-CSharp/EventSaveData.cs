using System;

// Token: 0x020003FC RID: 1020
[Serializable]
public class EventSaveData
{
	// Token: 0x06001C16 RID: 7190 RVA: 0x001480EB File Offset: 0x001462EB
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

	// Token: 0x06001C17 RID: 7191 RVA: 0x00148129 File Offset: 0x00146329
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x0400316F RID: 12655
	public bool befriendConversation;

	// Token: 0x04003170 RID: 12656
	public bool event1;

	// Token: 0x04003171 RID: 12657
	public bool event2;

	// Token: 0x04003172 RID: 12658
	public bool kidnapConversation;

	// Token: 0x04003173 RID: 12659
	public bool livingRoom;
}
