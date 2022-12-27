using System.Collections.Generic;
using UnityEngine;

public class InstrumentList : ViewListSynchronized<InstrumentData>
{
	protected override List<IDataContainer<InstrumentData>> CreateAllItems(Transform parent)
	{
		throw new System.NotImplementedException();
	}

	protected override IDataContainer<InstrumentData> CreateItem(Data data, Transform parent)
	{
		throw new System.NotImplementedException();
	}

	protected override bool NeededOnScene()
	{
		return true;
	}
}