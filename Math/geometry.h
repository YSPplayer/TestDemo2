/*
	�����ˣ���������
	�������ڣ�2024-10-20
*/
#pragma once
#include <vector>
namespace ZefraMath {
	namespace Geometry {
		namespace Euclidean {
			/*
				ŷ����ü���
				���壺�о���άƽ�����ά�ռ��е�ͼ�Σ��Ե㡤�߶Ρ���Ϊ��������
			*/

			/*
				�ܳ��ĸ��Χ��һ��ͼ�ν�����ܳ���
				����ζ��壺��������ֱ�߶���β���Χ�ɵķ��ͼ��
			*/

			/*
			  �����άƽ��ĵ�
			*/
			template<typename T>
			class Point2D {
			public:
				Point2D(T x, T y) {
					static_assert(std::is_arithmetic<T>::value, "Only arithmetic types are allowed");
					this->x = x;
					this->y = y;
				};
				T x;
				T y;
			};
			/*
				����������
			*/
			enum GeometryType {
				Triangle,//������
			};

			/*
				����������
			*/
			template<typename T>
			class Container {
			public:
				Container(GeometryType type) {
					if (type == GeometryType::Triangle) container.resize(3);//������ֻ����������
				};
				T& operator[](uint32_t index) {
					if (index >= container.size()) throw std::out_of_range("Array out of bounds.");
					return container[index];
				}
			private:
				std::vector<T> container;
			};
			/*
				�����ζ��壺������Ķ���Σ��������߶����
				���������ʣ�1.�����ε�����֮�ʹ��ڵ�����
							2.�����ε������ǵĽǶ�֮��Ϊ360��
			*/
			template<typename T>
			class Triangle {
			public:
				Triangle();
			private:
				Container<Point2D<T>> vertices;//��������ε���������ֵ
				Container<T> edges;//��������ε�������ֵ
			};
		}
		
	}

}