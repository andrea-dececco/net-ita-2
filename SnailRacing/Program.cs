
using Microsoft.Extensions.DependencyInjection;
using SnailRacing.BusinessLogic;
using SnailRacing.BusinessLogic.Interfaces;
using SnailRacing.Repository;
using SnailRacing.Repository.Interfaces;
using SnailRacing.View;
using SnailRacing.View.Interfaces;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IRaceLogic, RaceLogic>()
    .AddSingleton<IHomePage, HomePage>()
    .AddSingleton<IRacePage, RacePage>()
    .AddSingleton<IRaceRepository, RaceRepository>()
    .BuildServiceProvider();

serviceProvider.GetRequiredService<IHomePage>().View();
