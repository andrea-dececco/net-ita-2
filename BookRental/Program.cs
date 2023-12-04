using BookRental;
using BookRental.Logger;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<LibraryViewManager>()
    .AddSingleton<LibraryLogicManager>()
    .AddSingleton<ILibraryRepositoryManager, WriterRepositoryManager>()
    .AddSingleton<IMyLogger, FileLogger>()
    .BuildServiceProvider();

LibraryViewManager viewManager = serviceProvider.GetRequiredService<LibraryViewManager>();

while (true)
{
    viewManager.WelcomeMenu();
}





