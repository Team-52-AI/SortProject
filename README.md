# SortProject

## Описание проекта
Проект представляет собой реализацию различных алгоритмов сортировки на C#, включая тестовое приложение и визуализатор работы алгоритмов. Состоит из трех основных компонентов:

1. **SortLibrary** - Основная библиотека с реализацией алгоритмов
2. **SortTest** - Консольное приложение для тестирования
3. **SortView** - Графический интерфейс для визуализации

## Структура проекта
```
SortProject/
├── SortLibrary/
│ ├── Properties/
│ ├── References/
│ ├── EfficientSorts.cs // Эффективные сортировки
│ ├── LinearSorts.cs // Линейные сортировки
│ └── SimpleSorts.cs // Простые сортировки
├── SortTest/
│ ├── Properties/
│ ├── References/
│ ├── App.config
│ └── Program.cs // Тесты алгоритмов
└── SortView/
├── Properties/
├── References/
├── App.config
├── Form1.cs // Визуализация
└── Program.cs
```

## Реализованные алгоритмы

### Простые сортировки (O(n²))
1. **Сортировка пузырьком**
   - Попарное сравнение элементов
   - Сложность: O(n²)

2. **Сортировка вставками**
   - Постепенное построение отсортированного массива
   - Эффективна для почти упорядоченных данных

### Эффективные сортировки (O(n log n))
1. **Сортировка слиянием**
   - Рекурсивное деление массива
   - Гарантированная сложность O(n log n)

2. **Быстрая сортировка (Хоара)**
   - Опорный элемент (pivot)
   - В среднем O(n log n)

### Линейные сортировки
1. **Блочная сортировка (Bucket Sort)**
   - Требует дополнительной памяти
   - Сложность O(n)

### Специальные сортировки
1. **Сортировка для N=2 элементов**
   - Простое сравнение двух элементов

2. **Голландский флаг (N=3)**
   - Задача Дейкстры о разделении на три части

3. **Сортировочная шляпа (N=4)**
   - Распределение по 4 категориям

## Использование
Для тестирования алгоритмов используйте проект SortTest. Для визуализации - SortView.

