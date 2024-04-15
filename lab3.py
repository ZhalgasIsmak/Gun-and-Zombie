"""Выполнил Избасаров Диас
7. Ханойские Башни - Решить задачу о Ханойских башнях с использованием рекурсии.
"""

def sum_list(list):
    if len(list) == 0:
        return 0



def fact(n):
    if n == 1:
        return 1
    return fact(n - 1) * n


n = int(input("Введите количество дисков "))

print(fact(n))


