using UnityEngine;
using Zenject;

public class GlobalInjector : MonoInstaller
{
	ViewFactory viewFactory;
	WindowFactory windowFactory;
	SceneLoader sceneLoader;

	const string SERVICES_ROOT = "-- SERVICES --";

	public override void InstallBindings()
	{
		FindReferencesOnScene();

		BindFactories();
		BindServices();
	}

	private void FindReferencesOnScene()
	{
		GameObject services = GameObject.Find(SERVICES_ROOT);

		viewFactory = services.GetComponentInChildren<ViewFactory>();
		windowFactory = services.GetComponentInChildren<WindowFactory>();
		sceneLoader = services.GetComponentInChildren<SceneLoader>();
	}

	private void BindFactories()
	{
		Container.Bind<ViewFactory>().FromComponentOn(viewFactory.gameObject).AsSingle();
		Container.Bind<WindowFactory>().FromComponentOn(windowFactory.gameObject).AsSingle();
	}

	private void BindServices()
	{
		Container.Bind<Database>().FromNew().AsSingle();
		Container.Bind<SceneLoader>().FromComponentOn(sceneLoader.gameObject).AsSingle();
	}
}
