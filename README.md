# TrovoService
Дополнительный функционал [streamer.bot](https://streamer.bot/), для trovo.

## Disclamer
PresentViwers для Trovo, так же как и для YouTube не получает список текущих зрителей трансляции (в отличие от твича). Он получает список **активных за выбранный период** зрителей. Так как, по [словам](https://discord.com/channels/834650675224248362/834650675740540941/1339880791991124028) поддержки сб "*trovo's api actually doesn't give user id in their viewers api, sooo there is no way to "link" just the nickname to a user..*".

Соответственно все интерактивы завязанные на список текущих зрителей становятся невозможными. Мой модуль сохраняет список всех зрителей, которые были "пойманы" триггером PresentViewers (%trovoTodayViewers%) и запоминает его до перезапуска бота. Так же он запоминает список всех, кто писал в чат, по триггеру First Words (%trovoTodayChatters%). И так же очищает список при перезапуске бота.
Кэш First Words надо сбрасывать отдельно.

## Функционал, экшены и их настройка
При импорте у вас появится группа **\[Services] Trovo**
- **\[Trovo] Code** -- основной код.
- **\[Trovo] Get Random Viewers** -- экшен получения случайных зрителей. На данный момент, получает одного зрителя и записывает его ник в аргумент **%randomUserName0%**. Список зрителей составляется из списка чаттеров и списка Present Viewers. Так же случайный зритель попадает в глобальную переменную **trovoLastRandomViewer**. Переменная очищается при закрытии бота. Это сделано для того, чтобы бот не выбирал подряд дважды одного и того же зрителя. Если зритель всего один -- штож, тогда выбирать особо не из кого.
- **\[Trovo] Save Chatters** -- сохраняет список всех, кто написал в чат, в глобальную переменную **trovoTodayChatters**. Переменная очищается при закрытии бота. Работает по триггеру Trovo -> General -> First Words.
- **\[Trovo] Save Present Viewers** -- сохраняет список всех, кто попал в триггер Present Viewers, в глобальную переменную **trovoTodayViewers**. Переменная очищается при закрытии бота.

## License
This project is licensed under the [Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License](https://creativecommons.org/licenses/by-nc-sa/4.0/).  
**You are free to:**
- Share — copy and redistribute the code.
- Adapt — modify, transform, and build upon the code.

**Under the following terms:**
- Attribution — You must give appropriate credit.
- NonCommercial — You may not use the material for commercial purposes.
- ShareAlike — If you remix or modify the code, you must distribute your contributions under the same license.

See the [LICENSE](LICENSE) file for the full legal text.