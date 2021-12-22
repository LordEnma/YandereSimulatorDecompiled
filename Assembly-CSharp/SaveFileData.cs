using System;
using System.Xml.Serialization;

// Token: 0x02000404 RID: 1028
[XmlRoot]
[Serializable]
public class SaveFileData
{
	// Token: 0x04003168 RID: 12648
	public ApplicationSaveData applicationData = new ApplicationSaveData();

	// Token: 0x04003169 RID: 12649
	public ClassSaveData classData = new ClassSaveData();

	// Token: 0x0400316A RID: 12650
	public ClubSaveData clubData = new ClubSaveData();

	// Token: 0x0400316B RID: 12651
	public CollectibleSaveData collectibleData = new CollectibleSaveData();

	// Token: 0x0400316C RID: 12652
	public ConversationSaveData conversationData = new ConversationSaveData();

	// Token: 0x0400316D RID: 12653
	public DateSaveData dateData = new DateSaveData();

	// Token: 0x0400316E RID: 12654
	public DatingSaveData datingData = new DatingSaveData();

	// Token: 0x0400316F RID: 12655
	public EventSaveData eventData = new EventSaveData();

	// Token: 0x04003170 RID: 12656
	public GameSaveData gameData = new GameSaveData();

	// Token: 0x04003171 RID: 12657
	public HomeSaveData homeData = new HomeSaveData();

	// Token: 0x04003172 RID: 12658
	public MissionModeSaveData missionModeData = new MissionModeSaveData();

	// Token: 0x04003173 RID: 12659
	public OptionSaveData optionData = new OptionSaveData();

	// Token: 0x04003174 RID: 12660
	public PlayerSaveData playerData = new PlayerSaveData();

	// Token: 0x04003175 RID: 12661
	public PoseModeSaveData poseModeData = new PoseModeSaveData();

	// Token: 0x04003176 RID: 12662
	public SaveFileSaveData saveFileData = new SaveFileSaveData();

	// Token: 0x04003177 RID: 12663
	public SchemeSaveData schemeData = new SchemeSaveData();

	// Token: 0x04003178 RID: 12664
	public SchoolSaveData schoolData = new SchoolSaveData();

	// Token: 0x04003179 RID: 12665
	public SenpaiSaveData senpaiData = new SenpaiSaveData();

	// Token: 0x0400317A RID: 12666
	public StudentSaveData studentData = new StudentSaveData();

	// Token: 0x0400317B RID: 12667
	public TaskSaveData taskData = new TaskSaveData();

	// Token: 0x0400317C RID: 12668
	public YanvaniaSaveData yanvaniaData = new YanvaniaSaveData();
}
