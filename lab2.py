"""Выполнил Избасаров Диас
7. Калькулятор Налогов
 - Написать функцию, которая рассчитывает налоги на основе дохода, не изменяя
исходные данные
"""


def nalog_ex(x, rate):
    nalog = x * rate
    return nalog


income = int(input("Введите свой доход: "))
rate = float(input())

print(nalog_ex(income,rate))
