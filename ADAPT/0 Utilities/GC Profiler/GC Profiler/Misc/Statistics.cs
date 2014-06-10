using System;

// From http://www.codeproject.com/KB/cs/csstatistics.aspx

namespace Samraksh.Profiling.DotNow.GCProfiler.Misc {

    /// <summary>
    /// 
    /// </summary>
    public class Statistics {

        private double[] _list;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public Statistics(params double[] list) {
            _list = list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public void Update(params double[] list) {
            _list = list;
        }

        /// <summary>
        /// 
        /// </summary>
        public int N { get { return _list.Length; } }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Mode() {
            try {
                var i = new double[_list.Length];
                _list.CopyTo(i, 0);
                Sort(i);
                double valMode = i[0], helpValMode = i[0];
                int oldCounter = 0, newCounter = 0;
                int j = 0;
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
        /// 
        /// </summary>
        /// <returns></returns>
        public int Length() {
            return _list.Length;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Min() {
            double minimum = double.PositiveInfinity;
            for (int i = 0; i <= _list.Length - 1; i++)
                if (_list[i] < minimum) minimum = _list[i];
            return minimum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Max() {
            double maximum = double.NegativeInfinity;
            for (int i = 0; i <= _list.Length - 1; i++)
                if (_list[i] > maximum) maximum = _list[i];
            return maximum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Q1() {
            return Qi(0.25);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Q2() {
            return Qi(0.5);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Q3() {
            return Qi(0.75);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Mean() {
            try {
                double sum = 0;
                for (int i = 0; i <= _list.Length - 1; i++)
                    sum += _list[i];
                return sum / _list.Length;
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Range() {
            double minimum = Min();
            double maximum = Max();
            return (maximum - minimum);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double IQ() {
            return Q3() - Q1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double MiddleOfRange() {
            double minimum = Min();
            double maximum = Max();
            return (minimum + maximum) / 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Variance() {
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
        /// 
        /// </summary>
        /// <returns></returns>
        public double Stdev() {
            return Math.Sqrt(Variance());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double YULE() {
            try {
                return ((Q3() - Q2()) - (Q2() - Q1())) / (Q3() - Q1());
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public double Z(double member) {
            try {
                if (exist(member)) return (member - Mean()) / Stdev();
                else return double.NaN;
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public double Cov(Statistics s) {
            try {
                if (this.Length() != s.Length()) return double.NaN;
                int len = this.Length();
                double sum_mul = 0;
                for (int i = 0; i <= len - 1; i++)
                    sum_mul += (this._list[i] * s._list[i]);
                return (sum_mul - len * this.Mean() * s.Mean()) / (len - 1);
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static double Cov(Statistics s1, Statistics s2) {
            try {
                if (s1.Length() != s2.Length()) return double.NaN;
                int len = s1.Length();
                double sum_mul = 0;
                for (int i = 0; i <= len - 1; i++)
                    sum_mul += (s1._list[i] * s2._list[i]);
                return (sum_mul - len * s1.Mean() * s2.Mean()) / (len - 1);
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="design"></param>
        /// <returns></returns>
        public double R(Statistics design) {
            try {
                return this.Cov(design) / (this.Stdev() * design.Stdev());
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="design1"></param>
        /// <param name="design2"></param>
        /// <returns></returns>
        public static double R(Statistics design1, Statistics design2) {
            try {
                return Cov(design1, design2) / (design1.Stdev() * design2.Stdev());
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="design"></param>
        /// <returns></returns>
        public double A(Statistics design) {
            try {
                return this.Cov(design) / (Math.Pow(design.Stdev(), 2));
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="design1"></param>
        /// <param name="design2"></param>
        /// <returns></returns>
        public static double A(Statistics design1, Statistics design2) {
            try {
                return Cov(design1, design2) / (Math.Pow(design2.Stdev(), 2));
            }
            catch (Exception) {
                return double.NaN;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="design"></param>
        /// <returns></returns>
        public double B(Statistics design) {
            return this.Mean() - this.A(design) * design.Mean();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="design1"></param>
        /// <param name="design2"></param>
        /// <returns></returns>
        public static double B(Statistics design1, Statistics design2) {
            return design1.Mean() - A(design1, design2) * design2.Mean();
        }

        private double Qi(double i) {
            try {
                double[] j = new double[_list.Length];
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
            double[] temp = new double[i.Length];
            MergeSort(i, temp, 0, i.Length - 1);
        }

        private void MergeSort(double[] source, double[] temp, int left, int right) {
            int mid;
            if (left < right) {
                mid = (left + right) / 2;
                MergeSort(source, temp, left, mid);
                MergeSort(source, temp, mid + 1, right);
                Merge(source, temp, left, mid + 1, right);
            }
        }

        private void Merge(double[] source, double[] temp, int left, int mid, int right) {
            int i, left_end, num_elements, tmp_pos;
            left_end = mid - 1;
            tmp_pos = left;
            num_elements = right - left + 1;
            while ((left <= left_end) && (mid <= right)) {
                if (source[left] <= source[mid]) {
                    temp[tmp_pos] = source[left];
                    tmp_pos++;
                    left++;
                }
                else {
                    temp[tmp_pos] = source[mid];
                    tmp_pos++;
                    mid++;
                }
            }
            while (left <= left_end) {
                temp[tmp_pos] = source[left];
                left++;
                tmp_pos++;
            }
            while (mid <= right) {
                temp[tmp_pos] = source[mid];
                mid++;
                tmp_pos++;
            }
            for (i = 1; i <= num_elements; i++) {
                source[right] = temp[right];
                right--;
            }
        }

        private bool exist(double member) {
            bool is_exist = false;
            int i = 0;
            while (i <= _list.Length - 1 && !is_exist) {
                is_exist = (_list[i] == member);
                i++;
            }
            return is_exist;
        }

    }

}

