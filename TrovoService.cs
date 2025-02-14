///----------------------------------------------------------------------------
///   Module:       Trovo Service
///   Author:       NuboHeimer (https://live.vkvideo.ru/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///----------------------------------------------------------------------------
 
///   Version:      0.1.1
using System;
using System.Collections.Generic;
public class CPHInline
{

    public bool SavePresentViewers(){

        if (!args.ContainsKey("users")) // защита от дурака с пустым аргументом списка пользователей.
            return false;

        var currentViewers = (List<Dictionary<string, object>>)args["users"]; // запоминаем текущий список зрителей из аргумента бота.

        if (currentViewers.Count == 0)
            return true; // выходим, если список зрителей всё же пустой.

        List<string> trovoPresentViewers = new List<string>(); // инициализируем переменную для списка ников зрителей.

        foreach (var viewer in currentViewers) // проходимся по зрителям в списке.
            {
                trovoPresentViewers.Add(viewer["userName"].ToString());
                CPH.SetGlobalVar("trovoPresentViewers", trovoPresentViewers, false);
            }

        return true;
    }
}