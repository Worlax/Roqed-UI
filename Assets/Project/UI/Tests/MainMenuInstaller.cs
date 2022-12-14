using UnityEngine;
using Zenject;

public class MainMenuInstaller : MonoInstaller
{
	[SerializeField] ViewFactory viewFactory;

	public override void InstallBindings()
	{
		Container.Bind<ViewFactory>().FromComponentOn(viewFactory.gameObject).AsSingle();
	}
}
