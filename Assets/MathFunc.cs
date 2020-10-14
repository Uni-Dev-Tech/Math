using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MathFunc : MonoBehaviour
{
    [Header("Текстовое поле(задача первая)")] [SerializeField] 
    private Text resultFirstTask;

    [Header("Текстовое поле(задача вторая)")] [SerializeField] 
    private Text resultSecondTask;

    [Header("Текстовое поле(задача третья)")] [SerializeField] 
    private Text resultThirdTask;

    [Header("Текстовое поле(задача эйлера 1)")] [SerializeField] 
    private Text resultEulerFirst;

    [Header("Текстовое поле(задача эйлера 2)")] [SerializeField] 
    private Text resultEulerSecond;

    /// <summary>
    /// Выводит в консоль и в текстовое поле чётные цифры в интервале [1; 10).
    /// </summary>
    public void EvenNumbers()
    {
        Debug.Log(" Четные цифры интервала 1(включительно) и 10(не включительно):");

        if (resultFirstTask != null)
            resultFirstTask.text += $" Четные цифры интервала 1(включительно) и 10(не включительно):";

        for (int i = 1; i < 10; i++)
        {
            // Отбираем числа которые делятся нацело
            if((Convert.ToDouble(i) / 2) == i / 2)
            {
                Debug.Log(i);

                if (resultFirstTask != null)
                    resultFirstTask.text += $" {i} ";
            }
        }
    }

    /// <summary>
    /// Выводит в консоль и в текстовое поле полную таблицу умножения (от 1 до 10). 
    /// </summary>
    public void MultiplicationTable()
    {
        for (int i = 1; i < 11; i++)
        {
            for (int j = 1; j < 11; j++)
            {

                Debug.Log($"{i} * {j} = {i*j}");

                if (resultSecondTask != null)
                    resultSecondTask.text += $"\n{i} * {j} = {i * j}";
            }

            Debug.Log("");

            if (resultSecondTask != null)
                resultSecondTask.text += $"\n ";
        }
    }

    /// <summary>
    /// Выводит в консоль и в текстовое поле факториал входного параметра
    /// </summary>
    /// <param name="input">Инпут(вводмиое значение, > 0, < 21)</param>
    public void Factorial(InputField input)
    {
        // Проверяем является ли вводимое значение числом
        int n;
        bool isItNumber = int.TryParse(input.text, out n);
        if(isItNumber)
        {
            // Случай с 0
            if (n == 0)
            {
                Debug.Log($"Факториал числа {n} = 1");
                if (resultThirdTask != null)
                    resultThirdTask.text = $"Факториал числа {n} = 1";
            }

            // Ограничений до 21
            if (n > 20)
            {
                Debug.Log("Входной параметр (n) не должен быть больше 20");
                if (resultThirdTask != null)
                    resultThirdTask.text = "Входной параметр (n) не должен быть больше 20";
            }

            // Ограничения для отрицателныйх чисел
            if (n < 0)
            {
                Debug.Log("Входной параметр (n) не должен быть меньше 0");
                if (resultThirdTask != null)
                    resultThirdTask.text = "Входной параметр (n) не должен быть меньше 0";
            }

            if (n > 0 && n < 21)
            {
                //Разбиваем число на массив чисел от 1 до n(включительно),
                // но в обратном порядке ( от большего к меньшему)
                int[] numbers = new int[n];
                int factorialNumber = n;
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = factorialNumber;
                    factorialNumber--;
                }

                // Последнее значение массива (всегда 1) присваиваем переменной result,
                // и перемножаем все элементы массива по порядку (от большего к меньшему)
                ulong result = Convert.ToUInt64(numbers[numbers.Length - 1]);
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    result *= Convert.ToUInt64(numbers[i]);
                }

                // Вывод полученных данных
                if (resultThirdTask != null)
                    resultThirdTask.text = $"Факториал числа {n} = {result}";
                Debug.Log($"Факториал числа {n} = {result}");
            }
        }

        // Если вводимое значение не число или же вылазит за размер типа данных,
        // то придупреждаем об этом пользователя

        if(!isItNumber)
        {
            if (resultThirdTask != null)
                resultThirdTask.text = $"Убедитесь, что вы вводите число и что оно не слишком громоздкое";
        }
    }

    /// <summary>
    /// Выводит в консоль и в текстовое поле сумму всех чисел меньше 1000, кратных 3 и 5
    /// </summary>
    public void EulerTask_1()
    {
        int n = 1000;
        int multipleFirst = 3;
        int multipleSecond = 5;
        int result = 0;

        for(int i = 1; i < n; i++)
        {
            // В случае кратности 3 или 5, прибавляем к результату i
            if ((Convert.ToDouble(i) / multipleFirst) == i / multipleFirst ||
               (Convert.ToDouble(i) / multipleSecond) == i / multipleSecond)
                result += i;
        }

        // Вывод данных
        if (resultEulerFirst != null)
            resultEulerFirst.text = $"Ответ первой задачи Эйлера = {result}";
        Debug.Log($"Ответ первой задачи Эйлера = {result}");
    }

    /// <summary>
    /// Выводит в консоль и в текстовое поле сумму всех четных элементов ряда Фибоначчи, не привышающие 4 мил.
    /// </summary>
    public void EulerTask_2()
    {
        uint n = 4_000_000;

        // Присваиваем начальные значения (элементы) Фибоначи
        int firstFibNumber = 1;
        int secondFibNumber = 2;

        // Сразу присваиваем к результату четный элемент
        int result = secondFibNumber;
        do
        {
            //Считаем следующий элемент Фибоначи и проверяем его велечину
            int nextFibNumber = firstFibNumber + secondFibNumber;
            if (nextFibNumber > n)
                break;

            // Проверяем четный элемент или нет
            if ((Convert.ToDouble(nextFibNumber) / 2) == nextFibNumber / 2)
                result += nextFibNumber;

            // Переприсваиваем значения
            firstFibNumber = secondFibNumber;
            secondFibNumber = nextFibNumber;

        } while (true);

        // Вывод данных
        if (resultEulerSecond != null)
            resultEulerSecond.text = $"Ответ второй задачи Эйлера = {result}";
        Debug.Log($"Ответ второй задачи Эйлера = {result}");
    }
}
