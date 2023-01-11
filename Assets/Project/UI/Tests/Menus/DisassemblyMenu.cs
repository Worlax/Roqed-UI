using UnityEngine;

public class DisassemblyMenu : ButtonMenu
{
	protected override bool NeededOnScene()
	{
		return database.ActiveCourse.ObjectsData != null;
	}

	// Events
	protected override void Clicked()
	{
		
	}
}