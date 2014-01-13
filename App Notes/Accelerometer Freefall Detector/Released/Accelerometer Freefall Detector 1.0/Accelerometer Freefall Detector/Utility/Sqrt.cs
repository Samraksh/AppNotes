namespace Samraksh {
    namespace AppNote {
        namespace Utility{

            /// <summary>
            /// Math class for Micro Framework
            /// </summary>
            /// <remarks>
            /// Thanks to http://highfieldtales.wordpress.com/2011/03/26/fast-calculation-of-the-square-root/
            /// </remarks>
            public static class Math
            {
                ///
                /// Returns the square root of a specified number using a modified Newton-Raphson method
                ///
                /// <param name="x">A positive real number</param>
                /// <returns>Square root of the argument</returns>
                public static float Sqrt(float x) {
                    // Cut off any special case
                    if (x <= 0.0f)
                        return 0.0f;

                    // Here is a kind of base-10 logarithm so that the argument will fall between 1 and 100, where the convergence is fast
                    var exp = 1.0f;

                    while (x < 1.0f) {
                        x *= 100.0f;
                        exp *= 0.1f;
                    }

                    while (x > 100.0f) {
                        x *= 0.01f;
                        exp *= 10.0f;
                    }

                    // Choose the best starting point upon the actual argument value
                    float prev;

                    if (x > 10f) {
                        // Decade (10..100)
                        prev = 5.51f;
                    }
                    else if (x == 1.0f) {
                        // Avoid useless iterations
                        return x * exp;
                    }
                    else {
                        //decade (1..10)
                        prev = 1.741f;
                    }

                    // Apply the Newton-Rhapson method just for three times.
                    // (See discussion in the link re accuracy)
                    prev = 0.5f * (prev + x / prev);
                    prev = 0.5f * (prev + x / prev);
                    prev = 0.5f * (prev + x / prev);

                    // Adjust the result, multiplying for the base being cut off before
                    return prev * exp;
                }
            }
        }
    }
}
