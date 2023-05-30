using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EulerMethodKoshi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.Click += chart1_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SolveAndPlot();
        }

        private void SolveAndPlot()
        {
            double a = 0; // Начальное значение x
            double b = 3; // Конечное значение x
            int n = 1000; // Количество точек для построения графика
            double h = (b - a) / n; // Шаг

            double[] y = new double[n + 1]; // Массив значений y
            double[] x = new double[n + 1]; // Массив значений x

            // Начальные условия
            y[0] = 0; // Значение y(0)
            double dy = 1; // Значение y'(0)
            y[1] = dy * h + y[0];// Значение y(1)

            for (int i = 0; i <= n; i++)
            {
                x[i] = a + i * h; // Вычисление текущего значения x

                if (i > 1)
                {
                    double z = DifFunction(x[i]); // Вычисление значения функции z(x)
                    y[i] = SolveNextStep(y[i - 1], y[i - 2], z, h); // Решение следующего шага методом Эйлера
                }
            }

            PlotGraph(x, y);
        }

        private double SolveNextStep(double yk1, double yk, double z, double h)
        {
            // Метод Эйлера для решения уравнения y'' + y = z
            return z*h*h +2*yk1 - yk*(1+h*h);//y(k+2) = z*h^2 + 2*y(k+1) - y(k)*(1+h*h), расписанный разностный аналог
        }

        private double DifFunction(double x)
        {
            // Здесь вычисляется значение функции z(x)
            // Замените этот код на свою функцию z(x)
            // Примеры:
            // Функция 0: return 0;
            // Функция sin(2t): return Math.Sin(2 * x);
            // Функция sh(t): return Math.Sinh(x);

            return Math.Sinh(x); // По умолчанию возвращаем sin(2x)
        }

        private void PlotGraph(double[] x, double[] y)
        {
            chart1.Series["Series1"].Points.Clear();

            // Добавление точек на график
            for (int i = 0; i < x.Length; i++)
            {
                chart1.Series["Series1"].Points.AddXY(x[i], y[i]);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            SolveAndPlot();
        }
    }
}
