﻿Fatal - События, требующие немедленного внимания системного администратора, например, приложение или система вышли из строя или перестали отвечать.

Error - повод для внимания разработчиков. Тут интересно окружение конкретного места ошибки.
	События, указывающие на проблемы или ошибки, которые следует изучить и исправить, например, неожиданные исключения.

Warning - неожиданные параметры вызова, странный формат запроса, использование дефолтных значений в замен не корректных. Вообще все, что может свидетельствовать о не штатном использовании.
	События, предупреждающие о потенциальных проблемах, или данные, которые можно собирать и анализировать с течением времени, чтобы выявить тенденции проблем.

Info - разовые операции, которые повторяются крайне редко, но не регулярно. (загрузка конфига, плагина, запуск бэкапа)
	События, которые передают некритическую информацию администратору, например запуск, остановку сервера или другое важное (но нечастое) событие.
	Для регистрации и отслеживания каждой операции, выполняемой приложением, например каждая транзакция или каждое обработанное сообщение.

Debug - журналирование моментов вызова «крупных» операций. Старт/остановка потока, запрос пользователя и т.п.
	Полезно в первую очередь для помощи разработчикам в отладке низкоуровневых сбоев кода, однако не должно давать больше деталей, чем можно обработать.

Trace - вывод всего подряд. На тот случай, если Debug не позволяет локализовать ошибку. В нем полезно отмечать вызовы разнообразных блокирующих и асинхронных операций.
	Полезно для трассировок, которые, вероятно, будут иметь большой объем, особенно для информации, которая не требуется для всех сценариев отладки.