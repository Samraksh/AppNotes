using System;
using System.Text;
using Microsoft.SPOT;

namespace TestStringBuilderClear {
    public class Program {
        public static void Main() {
            var sb = new StringBuilder();
            for (var i = 0; i < int.MaxValue; i++) {
                for (var j = 0; j < 6; j++) {
                    sb.Append('x');
                }
                if (i % 100 == 0) {
                    Debug.Print("iteration " + i);
                }
                sb.Clear();
            }
        }

    }
}
