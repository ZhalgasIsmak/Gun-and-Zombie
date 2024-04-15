"""Выполнил Избасаров Диас
3. Наибольший Общий Делитель (НОД) - Найти НОД для списка пар чисел. """


def gcd(a, b):  # алгоритм евклида
    while b:
        a, b = b, a % b
    return a


def find_gcd(pair):
    return gcd(pair[0], pair[1])  # тут просто вычесляет нод по функции


def filter_pairs(pairs):
    return list(filter(lambda pair: pair[0] != 0 and pair[1] != 0, pairs))
    # тут лямба функция которая выполянет роль анонимной функции и фильтрует пары чисел, удаляя те, которые содержат ноль


pairs = [(48, 18)]
filtered_pairs = filter_pairs(pairs)
result = list(map(find_gcd, filtered_pairs)) #здесь используя map из двух списков делаем один иттреатор

print(result)
