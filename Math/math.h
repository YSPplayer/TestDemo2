/*
	创建人：神数不神
	创建日期：2024-10-20
*/
#include <initializer_list>
#include <type_traits>
#include <stdexcept>
#pragma once
namespace ZefraMath {
    /*
        数学最基础运算方法
        加减乘除，基本四大元素，数学的抽象底层
    */

    /*
       加法 | -- || -> |||
    */
    template<typename T>
    T Add(const std::initializer_list<T>& args) {
        static_assert(std::is_arithmetic<T>::value, "Only arithmetic types are allowed");
        T result = 0;
        for (const auto& val : args) {
            result += val;
        }
        return result;
    }

    /*
        减法 ||| -- || -> |
    */
    template<typename T>
    T Subtract(const std::initializer_list<T>& args) {
        static_assert(std::is_arithmetic<T>::value, "Only arithmetic types are allowed");
        auto it = args.begin();
        T result = *it++;  // 初始化为第一个元素
        for (; it != args.end(); ++it) {
            result -= *it;
        }
        return result;
    }

    /*
        乘法是加法的变种，是对加法的升维
        加法: 3 + 3 = 6
        乘法: 3 * 2 = 6
        其中乘法的2和3是两个不同维度上的量，而加法中的3和3是同一维度上的量
        加法是同一维度上的累加
        乘法是跨纬度之间的扩展和映射
        
        思考：对于如上乘法和加法的数在不同维度上有区分的性质，为什么古代数学家没有在符号上对不同维度的数
              进行区分以方便后人理解，不被概念混淆呢？
        Gpt：古代数学符号追求简化和使用
             维度的区分依赖语境而非符号
             现代数学通过矩阵、张量、单位来对维度进行区分
    */
    template<typename T>
    T Multiply(const std::initializer_list<T>& args) {
        static_assert(std::is_arithmetic<T>::value, "Only arithmetic types are allowed");
        T result = 1;
        for (const auto& val : args) {
            result *= val;
        }
        return result;
    }

    /*
       除法，维度理解同乘法
    */
    template<typename T>
    T Divide(const std::initializer_list<T>& args) {
        static_assert(std::is_arithmetic<T>::value, "Only arithmetic types are allowed");
        auto it = args.begin();
        T result = *it++;  // 初始化为第一个元素
        for (; it != args.end(); ++it) {
            if (*it == 0) {
                throw std::invalid_argument("Division by zero!");
            }
            result /= *it;
        }
        return result;
    }

}