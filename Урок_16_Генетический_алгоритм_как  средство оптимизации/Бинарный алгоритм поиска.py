from random import randint

# num = randint(0, 100)
# num_client = int(input('Введите число: '))
# count = 1
# while num != num_client:
#     if num < num_client:
#         print('Загаданное число меньше вашего')
#     else:
#         print('Загаданное число больше вашего') 
#     count+=1
#     num_client = int(input('Введите число: '))
# print('Что бы отгадать загаданное число ', num, ' вам потребовалось', count, ' попыток')

num_min = 0
num_max = 1000000
num = randint(num_min, num_max)
num_client = int(input('Введите число: '))
count = 1
while num != num_client:
    if num_client > num:
        num_time = num_client
        num_client = ((num_client - num_min) // 2) + num_min
        if num_client > num:
            num_max = num_client
            count += 1
        else:
            num_max = num_time
            num_min = num_client
            count += 1
    else:
        num_time2 = num_client
        num_client = ((num_max - num_client) // 2) + num_client
        if num_client > num:
            num_min = num_time2
            num_max = num_client
            count += 1
        else:
            num_min = num_client
            count += 1
print(bool(num == num_client)) # проверяет одинаковые ли значения, которое загадал рандом и то, что мы отгадали
print('Для того, что бы отгадать загаданное число ', num, ' потребовалось ', count, ' итераций')

