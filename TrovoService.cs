///----------------------------------------------------------------------------
///   Module:       Trovo Service
///   Author:       NuboHeimer (https://live.vkvideo.ru/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///   Help:         https://t.me/nuboheimersb/49
///----------------------------------------------------------------------------
 
///   Version:      1.0.0
using System;
using System.Collections.Generic;

public class CPHInline
{
    public bool SavePresentViewers()
    {
        if (!args.ContainsKey("users")) // защита от дурака с пустым аргументом списка пользователей.
        {
            return false;
        }

        var currentViewers = (List<Dictionary<string, object>>)args["users"]; // запоминаем текущий список зрителей из аргумента бота.

        if (currentViewers.Count == 0)
        {
            return false; // выходим, если список зрителей всё же пустой.
        }

        List<string> trovoTodayViewers = new List<string>(); // инициализируем переменную для списка "сегодняшних" зрителей.

        if (CPH.GetGlobalVar<List<string>>("trovoTodayViewers", false) != null) // если есть сохранённый ранее список записываем его.
        {
            trovoTodayViewers = CPH.GetGlobalVar<List<string>>("trovoTodayViewers", false);
        }

        foreach (var viewer in currentViewers) // проходимся по зрителям в списке.
        {
            string userName = viewer["userName"].ToString();
            if (!trovoTodayViewers.Contains(userName))
                trovoTodayViewers.Add(userName);
        }

        CPH.SetGlobalVar("trovoTodayViewers", trovoTodayViewers, false);
        return true;
    }

    public bool SaveChatters()
    {
        CPH.TryGetArg("userName", out string userName);
        List<string> trovoTodayChatters = new List<string>(); // инициализируем переменную для списка ников зрителей.

        if (CPH.GetGlobalVar<List<string>>("trovoTodayChatters", false) != null) // если есть сохранённый ранее список записываем его.
        {
            trovoTodayChatters = CPH.GetGlobalVar<List<string>>("trovoTodayChatters", false);
        }

        if (!trovoTodayChatters.Contains(userName))
        {
            trovoTodayChatters.Add(userName);
        }

        CPH.SetGlobalVar("trovoTodayChatters", trovoTodayChatters, false);
        return true;
    }

    public bool GetRandomViewers()
    {
        List<string> viewers = new List<string>();

        if (CPH.GetGlobalVar<List<string>>("trovoTodayViewers", false) != null)
        {
            viewers.AddRange(CPH.GetGlobalVar<List<string>>("trovoTodayViewers", false));
        }

        if (CPH.GetGlobalVar<List<string>>("trovoTodayChatters", false) != null)
        {
            foreach (string viewer in CPH.GetGlobalVar<List<string>>("trovoTodayChatters", false))
            {
                {
                    {
                        if (!viewers.Contains(viewer))
                            viewers.Add(viewer);
                    }
                }
            }
        }

        if (viewers.Count == 0)
        {
            CPH.LogError($"Списки зрителей отсутствуют!");
            return false;
        }

        Random random = new Random();
        string randomUserName = viewers[random.Next(viewers.Count)];
        
        if (viewers.Count > 1)
        {
            while (randomUserName.Equals(CPH.GetGlobalVar<string>("trovoLastRandomViewer", false)))
            {
                viewers.Remove(randomUserName);
                randomUserName = viewers[random.Next(viewers.Count)];
            }
        }

        CPH.SetArgument($"randomUserName0", randomUserName);
        CPH.SetGlobalVar("trovoLastRandomViewer", randomUserName, false);
        return true;
    }
}