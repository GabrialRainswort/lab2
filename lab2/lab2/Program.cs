using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vertex> vertices = new List<Vertex>
            {
                new Vertex("name1", 1), 
                new Vertex("name2", 2),
                new Vertex("name3", 3),
                new Vertex("name4", 4),
                new Vertex("name5", 5),
                new Vertex("name6", 6),
                new Vertex("name7", 7)
            };

            ////создание массива данных, запись каждой дуги вручную
            List<Arc> arcs = new List<Arc>
            {
                new Arc(vertices[0], vertices[1], 1),
                new Arc(vertices[0], vertices[2], 1),
                new Arc(vertices[2], vertices[3], 1),
                new Arc(vertices[2], vertices[4], 1),
                new Arc(vertices[1], vertices[5], 1),
                new Arc(vertices[4], vertices[1], 1),
                new Arc(vertices[5], vertices[6], 1),
                new Arc(vertices[4], vertices[6], 1),
                new Arc(vertices[4], vertices[3], 1),
                new Arc(vertices[3], vertices[6], 1)
            };

            //List<Arc> arcs = new List<Arc>
            //{
            //    new Arc(vertices[0], vertices[6], 1),
            //    new Arc(vertices[0], vertices[3], 1),
            //    new Arc(vertices[3], vertices[5], 1),
            //    new Arc(vertices[5], vertices[6], 1),
            //    new Arc(vertices[6], vertices[1], 1),
            //    new Arc(vertices[4], vertices[6], 1),
            //    new Arc(vertices[4], vertices[2], 1),
            //    new Arc(vertices[2], vertices[1], 1),
            //};

            Graph graph = new Graph(arcs, vertices); //создание графа, экземпляра класса граф


            Console.WriteLine("Вы хотите вызвыть какую-либо функцию для работы с графом?");
            Console.WriteLine("Если да, введите YES, если нет, введите NO.");
            string want = Console.ReadLine();

            while (want == "YES")
            {
                Console.WriteLine("Какую функцию вы хотите вызвать: ");
                Console.WriteLine("- FIRST" + "\n" + "- NEXT" + "\n" + "- VERTEX");
                Console.WriteLine("- ADD_V" + "\n" + "- ADD_E" + "\n" + "- DEL_V");
                Console.WriteLine("- DEL_E" + "\n" + "- EDID_V" + "\n" + "- EDID_E");

                string answer = Console.ReadLine();

                if (answer == "FIRST")
                {
                    Console.WriteLine("Подсказка: функция FIRST возвращает индекс первой вершины, смежной с вершиной v. Если вершина v не имеет смежных вершин, то возвращается 0.");

                    Console.WriteLine("Введите индекс вершины v: ");
                    int v = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(graph.FIRST(v));

                    Console.WriteLine("Вы хотите продолжить вызов каких-либо функций?" + "\n" + "Если да, введите YES, если нет, введите NO.");
                    want = Console.ReadLine();
                }

                if (answer == "NEXT")
                {
                    Console.WriteLine("Подсказка: функция NEXT возвращает индекс вершины, смежной вершиной v, следующий за индексом i. Если i индекс последней вершины, смежной с v, то возвращается 0.");

                    Console.WriteLine("Введите индекс вершины v: ");
                    int v = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите индекс вершины i: ");
                    int i = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(graph.NEXT(v, i));

                    Console.WriteLine("Вы хотите продолжить вызов каких-либо функций?" + "\n" + "Если да, введите YES, если нет, введите NO.");
                    want = Console.ReadLine();
                }

                if (answer == "VERTEX")
                {
                    Console.WriteLine("Подсказка: функция VERTEX возвращает вершину с индексом i из множества вершин, смежных с v.");

                    Console.WriteLine("Введите индекс вершины v: ");
                    int v = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите индекс вершины i: ");
                    int i = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(graph.VERTEX(v, i));

                    Console.WriteLine("Вы хотите продолжить вызов каких-либо функций?" + "\n" + "Если да, введите YES, если нет, введите NO.");
                    want = Console.ReadLine();
                }

                if (answer == "ADD_V")
                {
                    Console.WriteLine("Подсказка: функция ADD_V добавляет узел.");

                    Console.WriteLine("Введите имя узла:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Введите метку узла:");
                    int mark = Convert.ToInt32(Console.ReadLine());
                    graph.ADD_V(name, mark);

                    Console.WriteLine("Вы хотите продолжить вызов каких-либо функций?" + "\n" + "Если да, введите YES, если нет, введите NO.");
                    want = Console.ReadLine();
                }

                if (answer == "ADD_E")
                {
                    Console.WriteLine("Подсказка: функция ADD_E добавляет дугу.");

                    Console.WriteLine("Введите вершину v:");
                    int v = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите вершину w:");
                    int w = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите вес дуги:");
                    int c = Convert.ToInt32(Console.ReadLine());

                    graph.ADD_E(v, w, c);

                    Console.WriteLine("Вы хотите продолжить вызов каких-либо функций?" + "\n" + "Если да, введите YES, если нет, введите NO.");
                    want = Console.ReadLine();
                }

                if (answer == "DEL_V")
                {
                    Console.WriteLine("Подсказка: функция DEL_V удаляет узел.");

                    Console.WriteLine("Введите имя? узла:");
                    string name = Console.ReadLine();

                    graph.DEL_V(name);

                    Console.WriteLine("Вы хотите продолжить вызов каких-либо функций?" + "\n" + "Если да, введите YES, если нет, введите NO.");
                    want = Console.ReadLine();
                }

                if (answer == "DEL_E")
                {
                    Console.WriteLine("Подсказка: функция DEL_Е удаляет дугу.");

                    Console.WriteLine("Введите вершину v:");
                    int v = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите вершину w:");
                    int w = Convert.ToInt32(Console.ReadLine());

                    graph.DEL_E(v, w);

                    Console.WriteLine("Вы хотите продолжить вызов каких-либо функций?" + "\n" + "Если да, введите YES, если нет, введите NO.");
                    want = Console.ReadLine();
                }

                if (answer == "EDID_V")
                {
                    Console.WriteLine("Подсказка: функция EDIT_V изменяет метку узла.");

                    Console.WriteLine("Введите имя? узла:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Введите метку? узла:");
                    int mark = Convert.ToInt32(Console.ReadLine());

                    graph.EDID_V(name, mark);

                    Console.WriteLine("Вы хотите продолжить вызов каких-либо функций?" + "\n" + "Если да, введите YES, если нет, введите NO.");
                    want = Console.ReadLine();
                }

                if (answer == "EDIT_E")
                {
                    Console.WriteLine("Подсказка: функция EDIT_E изменяет вес дуги.");

                    Console.WriteLine("Введите вершину v:");
                    int v = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите вершину w:");
                    int w = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите новый вес дуги c:");
                    int c = Convert.ToInt32(Console.ReadLine());

                    graph.EDID_E(v, w, c);

                    Console.WriteLine("Вы хотите продолжить вызов каких-либо функций?" + "\n" + "Если да, введите YES, если нет, введите NO.");
                    want = Console.ReadLine();
                }
            }


            Console.WriteLine("Вы хотите вызвыть функцию вывода всех путей из вершины v в вершину w?");
            Console.WriteLine("Если да, введите YES, если нет, введите NO.");
            want = Console.ReadLine();

            while (want == "YES")
            {
                Console.WriteLine("Введите индекс вершины v: ");
                int from = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите индекс вершины w: ");
                int to = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Все пути из вершины " + from + " в вершину " + to + ":"); ;
                graph.FindAllPaths(from, to);

                Console.WriteLine("Вы хотите продолжить вызов функции вывода всех путей из вершины v в вершину w?" + "\n" + "Если да, введите YES, если нет, введите NO.");
                want = Console.ReadLine();
            }
        }

        //добавить вывод всего массива дуг в ф-иях с изменениями

    }
}
