using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice._01.Reading_an_array_of_numbers.src;

public class Solution
{
    public static int[] ParseNumbers(IEnumerable<string> lines)
    {
        return lines
            .Where(l => !string.IsNullOrEmpty(l))
            .Select(int.Parse)
            .ToArray();
    }
}

