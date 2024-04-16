"""Выполнил Избасаров Диас
7 - Рекурсивная Генерация Перестановок
 - Написать функцию для рекурсивной генерации всех возможных перестановок
заданного списка
"""
def change(): # новое изменение
    pass

def permutation(s):
    if len(s) == 1:
        return [s]

    perm_list = []  # resulting list
    for a in s:
        remaining_elements = [x for x in s if x != a]
        z = permutation(remaining_elements)  # permutations of sublist

        for t in z:
            perm_list.append([a] + t)

    return perm_list


arr = input("Введите элементы списка: ")
my_list = [int(x) for x in arr.split()]

for line in permutation(my_list):
    print(line)
