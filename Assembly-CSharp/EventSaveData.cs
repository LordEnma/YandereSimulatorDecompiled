using System;

// Token: 0x020003FB RID: 1019
[Serializable]
public class EventSaveData
{
	// Token: 0x06001C09 RID: 7177 RVA: 0x00147247 File Offset: 0x00145447
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

	// Token: 0x06001C0A RID: 7178 RVA: 0x00147285 File Offset: 0x00145485
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x0400313B RID: 12603
	public bool befriendConversation;

	// Token: 0x0400313C RID: 12604
	public bool event1;

	// Token: 0x0400313D RID: 12605
	public bool event2;

	// Token: 0x0400313E RID: 12606
	public bool kidnapConversation;

	// Token: 0x0400313F RID: 12607
	public bool livingRoom;
}
