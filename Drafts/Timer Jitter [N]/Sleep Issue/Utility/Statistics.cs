using System;
using Microsoft.SPOT;
using Math = System.Math;

namespace Samraksh.AppNote.Utility {

    /// <summary>
    /// Computational Statistics Class
    /// </summary>
    /// <remarks>Yossi Rozenberg, 19 Nov 2013</remarks>
    /// <remarks>http://www.codeproject.com/Tips/8750/A-computational-statistics-class</remarks>
    public class Statistics {

        private double[] _list;

        /// <summary>
        /// Calculate statistics
        /// </summary>
        /// <param name="list">Data for calculation</param>
        public Statistics(params double[] list) {
            _list = list;
        }

        /// <summary>
        /// Associate a new set of data
        /// </summary>
        /// <param name="list">Data for calculation</param>
        public void Update(params double[] list) {
            _list = list;
        }

        /// <summary>
        /// Calculate mode
        /// </summary>
        /// <returns>Mode value</returns>
        public double Mode() {
            try {
                var i = new double[_list.Length];
                _list.CopyTo(i, 0);
                Sort(i);
                double valMode = i[0], helpValMode = i[0];
                int oldCounter = 0, newCounter = 0;
                var j = 0;
                for (; j <= i.Length - 1; j++)
                    if (i[j] == helpValMode) newCounter++;
                    else if (newCounter > oldCounter) {
                        oldCounter = newCounter;
                        newCounter = 1;
                        helpValMode = i[j];
                        valMode = i[j - 1];
                    }
                    else if (newCounter == oldCounter) {
                        valMode = double.NaN;
                        helpValMode = i[j];
                        newCounter = 1;
                    }
                    else {
                        helpValMode = i[j];
                        newCounter = 1;
                    }
                if (newCounter > oldCounter) valMode = i[j - 1];
                else if (newCounter == oldCounter) valMode = double.NaN;
                return valMode;
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// Get the number of data items
        /// </summary>
        public int Length {
            get { return _list.Length; }
        }

        /// <summary>
        /// Calculate the min
        /// </summary>
        /// <returns>Min value</returns>
        public double Min() {
            try {
                var minimum = double.PositiveInfinity;
                for (var i = 0; i <= _list.Length - 1; i++)
                    if (_list[i] < minimum) minimum = _list[i];
                return minimum;
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// Calculate the max
        /// </summary>
        /// <returns>Max value</returns>
        public double Max() {
            try {
                var maximum = double.NegativeInfinity;
                for (var i = 0; i <= _list.Length - 1; i++)
                    if (_list[i] > maximum) maximum = _list[i];
                return maximum;
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// Calculate first quartile
        /// </summary>
        /// <returns></returns>
        public double Q1() {
            return Qi(0.25);
        }

        /// <summary>
        /// Calculate the second quartile (median)
        /// </summary>
        /// <returns></returns>
        public double Q2() {
            return Qi(0.5);
        }

        /// <summary>
        /// Calculate the third quartile
        /// </summary>
        /// <returns></returns>
        public double Q3() {
            return Qi(0.75);
        }

        /// <summary>
        /// Calculate the mean
        /// </summary>
        /// <returns></returns>
        public double Mean() {
            try {
                double sum = 0;
                for (var i = 0; i <= _list.Length - 1; i++) {
                    sum += _list[i];
                }
                return sum / _list.Length;
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// Calculate the range
        /// </summary>
        /// <returns></returns>
        public double Range() {
            var minimum = Min();
            var maximum = Max();
            return (maximum - minimum);
        }

        /// <summary>
        /// Calculate the difference between the 3rd and 1st quartile values
        /// </summary>
        /// <returns></returns>
        public double IQ() {
            return Q3() - Q1();
        }

        /// <summary>
        /// Calculate the middle of the range
        /// </summary>
        /// <returns></returns>
        public double MiddleOfRange() {
            var minimum = Min();
            var maximum = Max();
            return (minimum + maximum) / 2;
        }

        /// <summary>
        /// Calculate the variance
        /// </summary>
        /// <returns></returns>
        public double Var() {
            try {
                double s = 0;
                for (var i = 0; i <= _list.Length - 1; i++)
                    s += Math.Pow(_list[i], 2);
                return (s - _list.Length * Math.Pow(Mean(), 2)) / (_list.Length - 1);
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// Calculate the standard deviation
        /// </summary>
        /// <returns></returns>
        public double S() {
            return Math.Sqrt(Var());
        }

        /// <summary>
        /// Calculate the Yule coefficient
        /// </summary>
        /// <returns></returns>
        public double Yule() {
            try {
                return ((Q3() - Q2()) - (Q2() - Q1())) / (Q3() - Q1());
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// Calculate the standard score (Z value)
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public double Z(double member) {
            try {
                if (Exist(member)) { return (member - Mean()) / S(); }
                return double.NaN;
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// Calculate the covariance with respect to another set of data
        /// </summary>
        /// <param name="s">Other data</param>
        /// <returns></returns>
        public double Cov(Statistics s) {
            try {
                if (Length != s.Length) { return double.NaN; }
                var len = Length;
                double sumMul = 0;
                for (var i = 0; i <= len - 1; i++)
                    sumMul += (_list[i] * s._list[i]);
                return (sumMul - len * Mean() * s.Mean()) / (len - 1);
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// Calculate the covariance with respect to two specified sets of data
        /// </summary>
        /// <param name="s1">Data 1</param>
        /// <param name="s2">Data 2</param>
        /// <returns></returns>
        public static double Cov(Statistics s1, Statistics s2) {
            try {
                if (s1.Length != s2.Length) return double.NaN;
                var len = s1.Length;
                double sumMul = 0;
                for (var i = 0; i <= len - 1; i++)
                    sumMul += (s1._list[i] * s2._list[i]);
                return (sumMul - len * s1.Mean() * s2.Mean()) / (len - 1);
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// Calculate the Pearson r
        /// </summary>
        /// <param name="design"></param>
        /// <returns></returns>
        public double R(Statistics design) {
            try {
                return Cov(design) / (S() * design.S());
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// Calculate the Pearson r with respect to two sets of data
        /// </summary>
        /// <param name="design1"></param>
        /// <param name="design2"></param>
        /// <returns></returns>
        public static double R(Statistics design1, Statistics design2) {
            try {
                return Cov(design1, design2) / (design1.S() * design2.S());
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// Calculate the "a" factor of the linear function of design
        /// </summary>
        /// <param name="design"></param>
        /// <returns></returns>
        public double A(Statistics design) {
            try {
                return Cov(design) / (Math.Pow(design.S(), 2));
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// Calculate the "a" factor of the linear function of two designs
        /// </summary>
        /// <param name="design1"></param>
        /// <param name="design2"></param>
        /// <returns></returns>
        public static double A(Statistics design1, Statistics design2) {
            try {
                return Cov(design1, design2) / (Math.Pow(design2.S(), 2));
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// Calculate the "b" factor of the linear function of design
        /// </summary>
        /// <param name="design"></param>
        /// <returns></returns>
        public double B(Statistics design) {
            return Mean() - A(design) * design.Mean();
        }

        /// <summary>
        /// Calculate the "b" factor of the linear function of two designs
        /// </summary>
        /// <param name="design1"></param>
        /// <param name="design2"></param>
        /// <returns></returns>
        public static double B(Statistics design1, Statistics design2) {
            return design1.Mean() - A(design1, design2) * design2.Mean();
        }

        private double Qi(double i) {
            try {
                var j = new double[_list.Length];
                _list.CopyTo(j, 0);
                Sort(j);
                if (Math.Ceiling(_list.Length * i) == _list.Length * i) return (j[(int)(_list.Length * i - 1)] + j[(int)(_list.Length * i)]) / 2;
                else return j[((int)(Math.Ceiling(_list.Length * i))) - 1];
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        private void Sort(double[] i) {
            var temp = new double[i.Length];
            Merge_sort(i, temp, 0, i.Length - 1);
        }

        /// <summary>
        /// Merge sort
        /// </summary>
        /// <param name="source"></param>
        /// <param name="temp"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public void Merge_sort(double[] source, double[] temp, int left, int right) {
            if (left >= right) return;
            var mid = (left + right) / 2;
            Merge_sort(source, temp, left, mid);
            Merge_sort(source, temp, mid + 1, right);
            Merge(source, temp, left, mid + 1, right);

        }

        private static void Merge(double[] source, double[] temp, int left, int mid, int right) {
            int i;
            var leftEnd = mid - 1;
            var tmpPos = left;
            var numElements = right - left + 1;
            while ((left <= leftEnd) && (mid <= right)) {
                if (source[left] <= source[mid]) {
                    temp[tmpPos] = source[left];
                    tmpPos++;
                    left++;
                }
                else {
                    temp[tmpPos] = source[mid];
                    tmpPos++;
                    mid++;
                }
            }
            while (left <= leftEnd) {
                temp[tmpPos] = source[left];
                left++;
                tmpPos++;
            }
            while (mid <= right) {
                temp[tmpPos] = source[mid];
                mid++;
                tmpPos++;
            }
            for (i = 1; i <= numElements; i++) {
                source[right] = temp[right];
                right--;
            }
        }

        private bool Exist(double member) {
            var isExist = false;
            var i = 0;
            while (i <= _list.Length - 1 && !isExist) {
                isExist = (_list[i] == member);
                i++;
            }
            return isExist;
        }

    }

}
