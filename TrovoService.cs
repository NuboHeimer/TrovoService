///----------------------------------------------------------------------------
///   Module:       Trovo Service
///   Author:       NuboHeimer (https://live.vkvideo.ru/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///   Help:         https://t.me/nuboheimersb/49
///----------------------------------------------------------------------------

///   Version:      0.2.0
using System;
using System.Collections.Generic;
public class CPHInline
{

    public bool SavePresentViewers()
    {

        if (!args.ContainsKey("users")) // защита от дурака с пустым аргументом списка пользователей.
            return false;

        var currentViewers = (List<Dictionary<string, object>>)args["users"]; // запоминаем текущий список зрителей из аргумента бота.

        if (currentViewers.Count == 0)
            return true; // выходим, если список зрителей всё же пустой.

        List<string> trovoPresentViewers = new List<string>(); // инициализируем переменную для списка ников зрителей.

        foreach (var viewer in currentViewers) // проходимся по зрителям в списке.
        {
            trovoPresentViewers.Add(viewer["userName"].ToString());
        }

        CPH.SetGlobalVar("trovoPresentViewers", trovoPresentViewers, false);

        return true;
    }

    public bool GetRandomViewers()
    {

        if (CPH.GetGlobalVar<List<string>>("trovoPresentViewers", false) == null)
            return false;

        List<string> trovoPresentViewers = CPH.GetGlobalVar<List<string>>("trovoPresentViewers", true);

        if (!CPH.TryGetArg("usersCount", out int usersCount))
            usersCount = 1;

        if (usersCount > 1)
            if (usersCount > trovoPresentViewers.Count)
                usersCount = trovoPresentViewers.Count;

        for (int i = 0; i < usersCount; i++)
        {
            Random random = new Random();
            string userName = trovoPresentViewers[random.Next(trovoPresentViewers.Count)].ToString();
            trovoPresentViewers.Remove(userName);
            CPH.SetArgument($"userName{i}", userName);
        }

        return true;
    }
}