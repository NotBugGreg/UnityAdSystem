using System;
using System.Threading.Tasks;

interface IGameInitializer
{
    Task InitGameAsync(Action onSuccess, Action onError);

}