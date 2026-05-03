using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Resource.Script.Core
{
	public class Util
	{
		public static long ConvertToNumber(string input)
		{
			if (string.IsNullOrEmpty(input)) return 0;

			// 跳过第一个字符，从索引1开始截取
			string numberPart = input.Substring(1);

			// 转换为数字
			if (long.TryParse(numberPart, out long result))
			{
				return result;
			}

			return 0;
		}
	}
}
