using BookRental;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<LibraryViewManager>()
    .AddSingleton<LibraryLogicManager>()
    .AddSingleton<ILibraryRepositoryManager,WriterRepositoryManager>()
    .BuildServiceProvider();

LibraryViewManager viewManager = serviceProvider.GetRequiredService<LibraryViewManager>();

while (true)
{
    viewManager.WelcomeMenu();
}

// Riconsegna libro

// Dona libro





