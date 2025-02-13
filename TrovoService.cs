///----------------------------------------------------------------------------
///   Module:       Trovo Service
///   Author:       NuboHeimer (https://live.vkvideo.ru/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///----------------------------------------------------------------------------
 
///   Version:      0.1.0
using System;
using System.Collections.Generic;
public class CPHInline
{

    public bool SavePresentViewers(){

        if (!args.ContainsKey("users")) // защита от дурака с пустым аргументом списка пользователей.
            return false;

        var currentViewers = (List<Dictionary<string, object>>)args["users"];

        if (currentViewers.Count == 0)
            return true; // выходим, если список зрителей всё же пустой.

        List<string> currentViewersNameList = new List<string>();

        foreach (var viewer in currentViewers) // проходимся по зрителям в списке.
            {
                currentViewersNameList.Add(viewer["userName"].ToString());
                CPH.SetGlobalVar("currentTrovoViewersNameList", currentViewersNameList, true);
            }

        return true;
    }
}