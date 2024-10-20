/*
	�����ˣ���������
	�������ڣ�2024-10-20
*/
#include <initializer_list>
#include <type_traits>
#include <stdexcept>
#pragma once
namespace ZefraMath {
    /*
        ��ѧ��������㷽��
        �Ӽ��˳��������Ĵ�Ԫ�أ���ѧ�ĳ���ײ�
    */

    /*
       �ӷ� | -- || -> |||
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
        ���� ||| -- || -> |
    */
    template<typename T>
    T Subtract(const std::initializer_list<T>& args) {
        static_assert(std::is_arithmetic<T>::value, "Only arithmetic types are allowed");
        auto it = args.begin();
        T result = *it++;  // ��ʼ��Ϊ��һ��Ԫ��
        for (; it != args.end(); ++it) {
            result -= *it;
        }
        return result;
    }

    /*
        �˷��Ǽӷ��ı��֣��ǶԼӷ�����ά
        �ӷ�: 3 + 3 = 6
        �˷�: 3 * 2 = 6
        ���г˷���2��3��������ͬά���ϵ��������ӷ��е�3��3��ͬһά���ϵ���
        �ӷ���ͬһά���ϵ��ۼ�
        �˷��ǿ�γ��֮�����չ��ӳ��
        
        ˼�����������ϳ˷��ͼӷ������ڲ�ͬά���������ֵ����ʣ�Ϊʲô�Ŵ���ѧ��û���ڷ����϶Բ�ͬά�ȵ���
              ���������Է��������⣬������������أ�
        Gpt���Ŵ���ѧ����׷��򻯺�ʹ��
             ά�ȵ����������ﾳ���Ƿ���
             �ִ���ѧͨ��������������λ����ά�Ƚ�������
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
       ������ά�����ͬ�˷�
    */
    template<typename T>
    T Divide(const std::initializer_list<T>& args) {
        static_assert(std::is_arithmetic<T>::value, "Only arithmetic types are allowed");
        auto it = args.begin();
        T result = *it++;  // ��ʼ��Ϊ��һ��Ԫ��
        for (; it != args.end(); ++it) {
            if (*it == 0) {
                throw std::invalid_argument("Division by zero!");
            }
            result /= *it;
        }
        return result;
    }

}