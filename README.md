# Лабораторные работы по C#

Этот репозиторий содержит несколько лабораторных работ по C#, каждая из которых направлена на изучение и применение различных аспектов объектно-ориентированного программирования (ООП), проектирования систем и принципов программирования.

## Содержание
- [Лабораторная 0: Isu](#lab0)
- [Лабораторная 1: Shops](#lab1)
- [Лабораторная 2: Isu.Extra](#lab2)
- [Лабораторная 3: Backups](#lab3)
- [Лабораторная 4: Banks](#lab4)
- [Лабораторная 5: Backups.Extra](#lab5)

## Лабораторная 0: Isu

### Цель
Ознакомиться с языком C# и базовыми механизмами ООП. Реализовать недостающие методы и написать тесты для проверки корректности работы системы.

### Предметная область
Часть информационной системы университета (ИСУ), ответственная за хранение актуальной информации о статусе студентов, учебных группах, курсах и факультетах, а также за перевод студентов между группами.

### Функциональность
- Хранение информации о студенте.
- Хранение информации о группе и её составе.
- Реализация функциональности для студента в группе.

### Техническое задание
Реализация интерфейса IIsuService, который описывает действия студентов и группы, а также написание соответствующих тестов для проверки функциональности.

### Примеры тестов
- Добавление студента в группу.
- Проверка превышения максимального количества студентов в группе.
- Проверка создания группы с некорректным названием.
- Перевод студента в другую группу.

## Лабораторная 1: Shops

### Цель
Продемонстрировать умение выделять сущности и проектировать классы.

### Прикладная область
Магазин, покупатель, доставка, пополнение и покупка товаров.

### Тест кейсы
- Поставка товаров в магазин.
- Установка и изменение цен на товары.
- Поиск самого дешёвого магазина для набора товаров.
- Покупка партии товаров в магазине.

### Пример теста
Пример теста для проверки покупки товаров, проверки изменения количества товара и баланса покупателя.

## Лабораторная 2: Isu.Extra

### Цель
Научиться выделять зоны ответственности разных сущностей и проектировать связи между ними.

### Предметная область
Система записи студентов на дополнительные занятия (ОГНП).

### Функциональность
- Добавление нового курса ОГНП.
- Запись студента на ОГНП.
- Снятие записи.
- Получение потоков по курсу.
- Получение списка студентов в группе ОГНП.
- Получение списка студентов, не записавшихся на курсы.

## Лабораторная 3: Backups

### Цель
Применить на практике принципы SOLID и GRASP.

### Предметная область
Система резервного копирования, включающая объекты для резервирования, точки восстановления, задачи резервного копирования, репозитории и хранилища.

### Функциональность
- Создание и управление задачами резервного копирования.
- Поддержка различных алгоритмов хранения (Split Storage и Single Storage).
- Тестирование с использованием InMemoryRepository.

### Тест кейсы
- Проверка создания точек восстановления.
- Проверка корректного хранения данных в различных форматах.

## Лабораторная 4: Banks

### Цель
Применить на практике принципы SOLID, GRASP и паттерны GoF.

### Предметная область
Финансовые услуги банков, включающие счета и клиентов.

### Функциональность
- Создание и управление счетами различных типов (дебетовый, депозитный, кредитный).
- Выплата процентов и вычет комиссии.
- Управление транзакциями и их отмена.
- Обновление условий счетов и уведомление клиентов.
- Консольный интерфейс для взаимодействия с банками.

### Примеры тестов
- Проверка начисления процентов.
- Проверка ограничения операций для сомнительных счетов.
- Проверка уведомлений об изменениях условий.

## Лабораторная 5: Backups.Extra

### Цель
Расширить функциональность системы резервного копирования.

### Функциональность
- Слияние нескольких Restore Point в один.
- Сохранение и загрузка данных.
- Алгоритмы очистки Restore Point.
- Реализация гибридных лимитов для очистки.
- Поддержка процесса Merge.
- Логирование событий.
- Восстановление данных из Restore Point.
