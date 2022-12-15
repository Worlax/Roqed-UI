using UnityEngine;
using Zenject;

public class MainMenuInstaller : MonoInstaller
{
	[SerializeField] ViewFactory viewFactory;
	[SerializeField] WindowFactory windowFactory;

	public override void InstallBindings()
	{
		Container.Bind<ViewFactory>().FromComponentOn(viewFactory.gameObject).AsSingle();
		Container.Bind<WindowFactory>().FromComponentOn(windowFactory.gameObject).AsSingle();
	}
}
