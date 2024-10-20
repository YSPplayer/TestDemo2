/*
	创建人：神数不神
	创建日期：2024-10-20
*/
#pragma once
#include <vector>
namespace ZefraMath {
	namespace Geometry {
		namespace Euclidean {
			/*
				欧几里得几何
				定义：研究二维平面和三维空间中的图形，以点·线段·角为基础概念
			*/

			/*
				周长的概念：围绕一个图形界面的总长度
				多边形定义：由若干条直线段首尾相接围成的封闭图形
			*/

			/*
			  定义二维平面的点
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
				几何体类型
			*/
			enum GeometryType {
				Triangle,//三角形
			};

			/*
				容器管理类
			*/
			template<typename T>
			class Container {
			public:
				Container(GeometryType type) {
					if (type == GeometryType::Triangle) container.resize(3);//三角形只有三个顶点
				};
				T& operator[](uint32_t index) {
					if (index >= container.size()) throw std::out_of_range("Array out of bounds.");
					return container[index];
				}
			private:
				std::vector<T> container;
			};
			/*
				三角形定义：最基础的多边形，由三条线段组成
				三角形性质：1.三角形的两边之和大于第三边
							2.三角形的三个角的角度之后为360度
			*/
			template<typename T>
			class Triangle {
			public:
				Triangle();
			private:
				Container<Point2D<T>> vertices;//存放三角形的三个顶点值
				Container<T> edges;//存放三角形的三个边值
			};
		}
		
	}

}